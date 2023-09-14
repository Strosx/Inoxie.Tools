namespace Inoxie.Tools.ApiServices.Abstractions.Interfaces
{
    /// <summary>
    /// Defines methods for write authorization. In the default services, these methods are executed before performing operations on the database.
    /// </summary>
    /// <remarks>
    /// Implementing classes should contain only authorization logic, specifically determining if an account has access to a given resource.
    /// </remarks>
    public interface IBaseWriteAuthorizationService<TInDto, in TId>
    {
        /// <summary>
        /// Determines if the given DTO is authorized for writing. This check is performed prior to create and update database operation.
        /// </summary>
        Task<bool> AuthorizeAsync(TInDto dto);
        
        /// <summary>
        /// Determines if the given collection of DTOs are authorized for writing.
        /// </summary>
        /// <remarks>
        /// The default implementation invokes the authorization check for each DTO in the collection and returns true only if all are authorized. 
        /// In most cases, overriding this is not necessary.
        /// </remarks>
        async Task<bool> AuthorizeAsync(List<TInDto> collection)
        {
            var tasks = collection.Select(AuthorizeAsync);
            var processed = await Task.WhenAll(tasks);
            return processed.All(x => x);
        }

        /// <summary>
        /// Determines if the provided ID is authorized for deletion. This check is performed prior to the deletion operation in the database.
        /// </summary>
        Task<bool> AuthorizeDeleteAsync(TId id);
    }
}