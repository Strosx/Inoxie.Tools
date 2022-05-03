using Inoxie.Tools.Example.Api.Core.Models;
using System.Linq.Expressions;
using Inoxie.Tools.ApiServices.GuidId.Abstractions;

namespace Inoxie.Tools.Example.Api.Services.AuthorizationExpressionaProviders;

public class CustomersReadAuthorizationService : IReadAuthorizationService<CustomerEntity>
{
    public Expression<Func<CustomerEntity, bool>> Get()
    {
        return x => true;
    }
}
