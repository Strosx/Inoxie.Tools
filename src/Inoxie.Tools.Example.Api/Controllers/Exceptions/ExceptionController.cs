using Inoxie.Tools.Example.Api.Exceptions;
using Inoxie.Tools.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Exceptions;

[Route("api/exceptions")]
public class ExceptionController : ControllerBase
{

    [HttpGet("unhandled")]
    public Task ThrowUnhandled()
    {
        throw new Exception("Unhandled exception");
    }

    [HttpGet("inoxieForbidden")]
    public Task ThrowInoxieForbidden()
    {
        throw new InoxieForbiddenException("Forbidden exception");
    }

    [HttpGet("inoxieException")]
    public Task ThrowInoxieException()
    {
        throw new InoxieException("Inoxie exception");
    }

    [HttpGet("inoxieErrorCodeException")]
    public Task ThrowInoxieErrorCodeException()
    {
        throw new InoxieErrorCodeException(ErrorCodes.ExampleErrorCodeNumberOne);
    }
}
