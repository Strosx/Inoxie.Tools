using Inoxie.Tools.DataProcessor.Abstractions.Interfaces;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.Example.Api.Core.Models;

namespace Inoxie.Tools.Example.Api.Services.FilterProviders;

public class CustomersFilterProvider : IDataProcessorFilterProvider<CustomerEntity, BaseSearchableFilterModel>
{
    public Func<BaseSearchableFilterModel, (IQueryable<CustomerEntity> query, int count)> GetFunc(IQueryable<CustomerEntity> queryable)
    {
        return filter =>
        {
            var query = queryable;

            if (!string.IsNullOrWhiteSpace(filter.SearchValue))
            {
                query = query.Where(x => x.Email.Contains(filter.SearchValue));
            }

            return (queryable
                .Skip(filter.Skip)
                .Take(filter.Take), queryable.Count());
        };
    }
}
