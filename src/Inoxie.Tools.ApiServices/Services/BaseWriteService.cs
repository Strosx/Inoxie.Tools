using AutoMapper;
using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.ApiServices.Utilities;
using Inoxie.Tools.Core.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Inoxie.Tools.ApiServices.Services;

/// <summary>
/// Provides a fundamental implementation for write operations on entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <remarks>
/// This service caters to the creation, update, and deletion of entities. It incorporates <see cref="IBaseWriteRepository{TEntity, TId}"/>, <see cref="IBaseReadRepository{TEntity, TId}"/>, <see cref="IMapper"/>, <see cref="IBaseWriteAuthorizationService{TInDto, TId}"/>, and <see cref="IDbSaveChanges"/> to conduct its operations.
/// </remarks>
public class BaseWriteService<TEntity, TInDto, TId> : IBaseWriteService<TInDto, TId>
    where TEntity : IBaseDataEntity<TId>
{
    private readonly IDbSaveChanges dbSaveChanges;
    private readonly IMapper mapper;
    private readonly IBaseReadRepository<TEntity, TId> readRepository;
    private readonly IBaseWriteAuthorizationService<TInDto, TId> writeAuthorizationService;
    private readonly IBaseWriteRepository<TEntity, TId> writeRepository;

    public BaseWriteService(
        IBaseWriteRepository<TEntity, TId> writeRepository,
        IBaseReadRepository<TEntity, TId> readRepository,
        IMapper mapper,
        IBaseWriteAuthorizationService<TInDto, TId> writeAuthorizationService,
        IDbSaveChanges dbSaveChanges)
    {
        this.writeRepository = writeRepository;
        this.readRepository = readRepository;
        this.mapper = mapper;
        this.writeAuthorizationService = writeAuthorizationService;
        this.dbSaveChanges = dbSaveChanges;
    }


    public virtual async Task<TId> CreateAsync(TInDto inDto, bool saveChanges = true)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDto))
        {
            throw new UnauthorizedAccessException($"Access denied for creating an entity of type {typeof(TEntity).Name}.");
        }

        var mappedEntity = mapper.Map<TEntity>(inDto);
        return await writeRepository.CreateAsync(mappedEntity, null, saveChanges);
    }

    public virtual async Task CreateManyAsync(List<TInDto> inDtos, bool saveChanges = true)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDtos))
        {
            throw new UnauthorizedAccessException($"Access denied for creating multiple entities of type {typeof(TEntity).Name}.");
        }

        var mappedList = mapper.Map<List<TEntity>>(inDtos);
        await writeRepository.CreateManyAsync(mappedList, saveChanges);
    }

    public virtual async Task DeleteAsync(TId id, bool saveChanges = true)
    {
        if (!await writeAuthorizationService.AuthorizeDeleteAsync(id))
        {
            throw new UnauthorizedAccessException($"Access denied for deleting the entity of type {typeof(TEntity).Name} with ID '{id}'.");
        }

        await writeRepository.DeleteAsync(id, saveChanges);
    }

    public virtual TId GetLastAddedId()
    {
        return writeRepository.GetLastAddedId();
    }

    public virtual async Task UpdateAsync(TInDto inDto, TId id, bool saveChanges = true)
    {
        if (!await writeAuthorizationService.AuthorizeAsync(inDto))
        {
            throw new UnauthorizedAccessException($"Access denied for updating the entity of type {typeof(TEntity).Name} with ID '{id}'.");
        }

        var entity = await readRepository.AsQueryable(true).FirstAsync(f => Equals(f.Id, id));
        entity.MapPropertiesFrom<TEntity, TInDto, TId>(inDto);

        if (saveChanges)
        {
            await dbSaveChanges.SaveChangesAsync();
        }
    }
}