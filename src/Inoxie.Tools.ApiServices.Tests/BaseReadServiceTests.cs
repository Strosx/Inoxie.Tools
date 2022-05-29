using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.Abstractions;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;

namespace Inoxie.Tools.ApiServices.Tests;

internal class BaseReadServiceTests
{
    private Mock<IMapper> mapper;
    private Mock<IBaseReadAuthorizationService<ExampleEntity, Guid>> readAuthorizationService;
    private Mock<IBaseReadRepository<ExampleEntity, Guid>> readRepository;
    private Mock<IReadServicePostProcessor<ExampleOutDto>> readServicePostProcessor;

    [SetUp]
    public void Setup()
    {
        mapper = new Mock<IMapper>();
        readAuthorizationService = new Mock<IBaseReadAuthorizationService<ExampleEntity, Guid>>();
        readServicePostProcessor = new Mock<IReadServicePostProcessor<ExampleOutDto>>();
        readRepository = new Mock<IBaseReadRepository<ExampleEntity, Guid>>();
    }

    [Test]
    public async Task GetAsync_WhenEntityExists_ReturnEntity()
    {
        // Arrange
        var guidId = Guid.NewGuid();
        var exampleEntities = new List<ExampleEntity> { new() { Id = guidId } }.AsQueryable().BuildMock();
        readRepository.Setup(x => x.AsQueryable(It.IsAny<bool>())).Returns(exampleEntities);

        var exampleOutDto = new ExampleOutDto() { Id = guidId };
        var exampleOutDtoQuery = new List<ExampleOutDto> { exampleOutDto }.AsQueryable().BuildMock();
        mapper.Setup(x => x.ProjectTo<ExampleOutDto>(It.IsAny<IQueryable<ExampleEntity>>(), It.IsAny<object>())).Returns(exampleOutDtoQuery);

        readServicePostProcessor.Setup(x => x.ProcessAsync(It.IsAny<ExampleOutDto>())).Returns(Task.FromResult(exampleOutDto));

        readAuthorizationService.Setup(x => x.Get()).ReturnsAsync(a => true);

        var service = new BaseReadService<ExampleEntity, ExampleOutDto, Guid>(readRepository.Object, mapper.Object, readAuthorizationService.Object, readServicePostProcessor.Object);

        // Act
        var outDto = await service.GetAsync(guidId);

        // Assert
        Assert.AreEqual(guidId, outDto.Id);
    }


    [Test]
    public void GetAsync_WhenEntityIsNull_ThrowForbidden()
    {
        // Arrange
        var guidId = Guid.NewGuid();
        var exampleEntities = new List<ExampleEntity> { new() { Id = guidId } }.AsQueryable().BuildMock();
        readRepository.Setup(x => x.AsQueryable(It.IsAny<bool>())).Returns(exampleEntities);

        var exampleOutDto = new List<ExampleOutDto>().AsQueryable().BuildMock();
        mapper.Setup(x => x.ProjectTo<ExampleOutDto>(It.IsAny<IQueryable<ExampleEntity>>(), It.IsAny<object>())).Returns(exampleOutDto);

        readAuthorizationService.Setup(x => x.Get()).ReturnsAsync(a => true);

        var service = new BaseReadService<ExampleEntity, ExampleOutDto, Guid>(readRepository.Object, mapper.Object, readAuthorizationService.Object, readServicePostProcessor.Object);

        // Act
        var exception = Assert.ThrowsAsync<Exception>(async () => await service.GetAsync(guidId));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("Forbidden"));
    }


    [Test]
    public void GetAsync_WhenEntityIsNull_ThrowNotFound()
    {
        // Arrange
        var exampleEntities = new List<ExampleEntity>().AsQueryable().BuildMock();
        readRepository.Setup(x => x.AsQueryable(It.IsAny<bool>())).Returns(exampleEntities);

        var exampleOutDto = new List<ExampleOutDto>().AsQueryable().BuildMock();
        mapper.Setup(x => x.ProjectTo<ExampleOutDto>(It.IsAny<IQueryable<ExampleEntity>>(), It.IsAny<object>())).Returns(exampleOutDto);

        readAuthorizationService.Setup(x => x.Get()).ReturnsAsync(a => true);

        var service = new BaseReadService<ExampleEntity, ExampleOutDto, Guid>(readRepository.Object, mapper.Object, readAuthorizationService.Object, readServicePostProcessor.Object);

        // Act
        var exception = Assert.ThrowsAsync<Exception>(async () => await service.GetAsync(Guid.NewGuid()));

        // Assert
        Assert.That(exception?.Message, Is.EqualTo("NotFound"));
    }

    [Test]
    public async Task GetAllAsync_When10ElementsInDataBase_Return10Elements()
    {
        // Arrange
        var exampleEntities = new List<ExampleEntity>().AsQueryable().BuildMock();
        readRepository.Setup(x => x.AsQueryable(It.IsAny<bool>())).Returns(exampleEntities);

        var exampleOutDtos = new List<ExampleOutDto>();

        for (var i = 0; i < 10; i++)
        {
            exampleOutDtos.Add(new ExampleOutDto { Id = Guid.NewGuid() });
        }

        var exampleOutDtosQuery = exampleOutDtos.AsQueryable().BuildMock();
        mapper.Setup(x => x.ProjectTo<ExampleOutDto>(It.IsAny<IQueryable<ExampleEntity>>(), It.IsAny<object>())).Returns(exampleOutDtosQuery);

        readAuthorizationService.Setup(x => x.Get()).ReturnsAsync(a => true);

        readServicePostProcessor.Setup(x => x.ProcessCollectionAsync(It.IsAny<List<ExampleOutDto>>())).ReturnsAsync(exampleOutDtos);

        var service = new BaseReadService<ExampleEntity, ExampleOutDto, Guid>(readRepository.Object, mapper.Object, readAuthorizationService.Object, readServicePostProcessor.Object);

        // Act
        var outDtos = await service.GetAllAsync();

        // Assert
        Assert.AreEqual(10, outDtos.Count);
    }
}