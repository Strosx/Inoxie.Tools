using Inoxie.Tools.Example.Api.Core.Models;
using System.Linq.Expressions;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;

namespace Inoxie.Tools.Example.Api.Services.AuthorizationExpressionaProviders;

public class CustomersReadAuthorizationService : IReadAuthorizationService<CustomerEntity>
{
    public Task<Expression<Func<CustomerEntity, bool>>> Get()
    {
        return Task.FromResult<Expression<Func<CustomerEntity, bool>>>(x => true);
    }
}
