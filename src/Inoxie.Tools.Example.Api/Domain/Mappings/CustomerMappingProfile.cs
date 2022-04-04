using AutoMapper;
using Inoxie.Tools.Example.Api.Core.Models;
using Inoxie.Tools.Example.Api.Domain.Customers;

namespace Inoxie.Tools.Example.Api.Domain.Mappings;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerEntity, CustomerOutDto>();
        CreateMap<CustomerInDto, CustomerEntity>();
    }
}
