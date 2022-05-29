using Inoxie.Tools.ApiServices.GuidId.DI;
using Inoxie.Tools.DataProcessor.Abstractions.Models;
using Inoxie.Tools.Emails.DI;
using Inoxie.Tools.Example.Api.Core;
using Inoxie.Tools.Example.Api.Core.Models;
using Inoxie.Tools.Example.Api.Domain.Customers;
using Inoxie.Tools.Example.Api.Exceptions.MessageProvider;
using Inoxie.Tools.Example.Api.Services.AuthorizationExpressionaProviders;
using Inoxie.Tools.Example.Api.Services.FilterProviders;
using Inoxie.Tools.Example.Api.Services.PdfTemplating.ConfigurationProviders;
using Inoxie.Tools.Example.Api.Services.PdfTemplating.Models;
using Inoxie.Tools.Example.Api.Services.PostProcessor;
using Inoxie.Tools.Example.Api.Services.WriteAuthorizationServices;
using Inoxie.Tools.Exceptions.DI;
using Inoxie.Tools.JwtAuth.DI;
using Inoxie.Tools.Logging.DI;
using Inoxie.Tools.PdfTemplating.DI;
using Inoxie.Tools.PdfTemplating.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPdfTemplating();
builder.Services.AddScoped<IPdfTemplateConfigurationProvider<ExamplePdfTemplateModel>, ExamplePdfTemplateModelConfigurationProvider>();

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inoxie tools
builder.Services.AddInoxieApiServicesGuidId<DatabaseContext>();
builder.Services.AddInoxieExceptions<ErrorCodeMessageProvider>();
builder.Services.AddInoxieEmailsTool(builder.Configuration);
builder.Services.AddInoxieJwtAuth(builder.Configuration);
builder.Services.AddInoxieToolsLogging();

//write services
builder.Services.AddFilteredReadService<CustomerEntity, CustomerOutDto, BaseSearchableFilterModel, CustomersFilterProvider,
    CustomersReadAuthorizationService, CustomersReadServicePostProcessor>();

//read services
builder.Services.AddWriteService<CustomerEntity, CustomerInDto, CustomersWriteAuthorizationService>();

//mapping
builder.Services.AddAutoMapper(typeof(Program));

//sql
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql"), providerOptions =>
    {
        providerOptions.CommandTimeout(600);
        providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseInoxieJwtAuth();
app.UseInoxieExceptions();
app.MapControllers();

app.Run();