using System;
using Inoxie.Tools.Core.Repository.Abstractions;

namespace Inoxie.Tools.ApiServices.Tests;

internal class ExampleEntity : IBaseDataEntity<Guid>
{
    public Guid Id { get; set; }
}