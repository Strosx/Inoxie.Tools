using Inoxie.Tools.ApiServices.Abstractions.Interfaces;
using Inoxie.Tools.Example.Api.Core.Models;
using System.Linq.Expressions;

namespace Inoxie.Tools.Example.Api.Services.AuthorizationExpressionaProviders;

public class CustomersReadAuthorizationService : IReadAuthorizationService<CustomerEntity>
{
    public Expression<Func<CustomerEntity, bool>> Get()
    {
        return x => true;
    }
}
