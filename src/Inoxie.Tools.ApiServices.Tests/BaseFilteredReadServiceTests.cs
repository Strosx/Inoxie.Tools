using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Services;
using Inoxie.Tools.Core.Repository.Abstractions;
using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;

namespace Inoxie.Tools.ApiServices.Tests;

internal class BaseFilteredReadServiceTests
{
    private Mock<IDataProcessor<ExampleEntity, ExampleFilter>> dataProcessor;
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
        dataProcessor = new Mock<IDataProcessor<ExampleEntity, ExampleFilter>>();
    }

    [Test]
    public async Task FilterAsync_WhenAllDataProper_ReturnCollection()
    {
        // Arrange
        readAuthorizationService.Setup(x => x.Get()).ReturnsAsync(a => true);
        var exampleEntitiesQuery = new List<ExampleEntity>().AsQueryable().BuildMock();
        readRepository.Setup(x => x.AsQueryable(It.IsAny<bool>())).Returns(exampleEntitiesQuery);

        dataProcessor.Setup(x => x.ProcessQueryable(It.IsAny<ExampleFilter>(), It.IsAny<IQueryable<ExampleEntity>>()))
            .Returns(new QueryablePagedDataResponse<ExampleEntity> { Total = exampleEntitiesQuery.Count(), Collection = exampleEntitiesQuery });

        var exampleOutDtos = new List<ExampleOutDto>();
        for (var i = 0; i < 10; i++)
        {
            exampleOutDtos.Add(new ExampleOutDto { Id = Guid.NewGuid() });
        }

        var exampleOutDtosQuery = exampleOutDtos.AsQueryable().BuildMock();
        mapper.Setup(x => x.ProjectTo<ExampleOutDto>(It.IsAny<IQueryable<ExampleEntity>>(), It.IsAny<object>())).Returns(exampleOutDtosQuery);

        readServicePostProcessor.Setup(x => x.ProcessCollectionAsync(It.IsAny<List<ExampleOutDto>>())).ReturnsAsync(exampleOutDtos);

        var service = new BaseFilteredReadService<ExampleEntity, ExampleOutDto, ExampleFilter, Guid>(readRepository.Object, mapper.Object, dataProcessor.Object, readAuthorizationService.Object,
            readServicePostProcessor.Object);

        // Act
        var pagedDataResponse = await service.FilterAsync(new ExampleFilter());

        // Assert
        Assert.AreEqual(exampleOutDtos, pagedDataResponse.Collection);
    }
}