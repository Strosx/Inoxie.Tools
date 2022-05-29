using Inoxie.Tools.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inoxie.Tools.Example.Api.Controllers.Logging;


[Route("api/logging")]
public class LoggingController : ControllerBase
{
    private readonly IInoxieLogger<LoggingController> logger;

    public LoggingController(IInoxieLogger<LoggingController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public void Log()
    {
        logger.LogInformation("Test LogInformation: {Random}", Random.Shared.NextDouble());
        logger.LogInformation("Test LogInformation: {Random1}   {Random2}", Random.Shared.NextDouble(), Random.Shared.NextDouble());
        logger.LogError("Test LogError: {Random}", Random.Shared.NextDouble());
    }
}
