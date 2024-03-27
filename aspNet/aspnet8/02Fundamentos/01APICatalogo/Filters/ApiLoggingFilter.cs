using Microsoft.AspNetCore.Mvc.Filters;

namespace _01APICatalogo.Filters;

public class ApiLoggingFilter : IActionFilter
{
    private readonly ILogger<IActionFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }
    // Excuta antes do método action
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"### Executando ===> OnActionExecuted");
        _logger.LogInformation($"####################################");
        _logger.LogInformation($"{DateTime.Now.ToString()}");
        _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
        _logger.LogInformation($"####################################");
    }
    // Excuta depois do método action
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"### Executando ===> OnActionExecuting");
        _logger.LogInformation($"####################################");
        _logger.LogInformation($"{DateTime.Now.ToString()}");
        _logger.LogInformation($"Status Code: {context.HttpContext.Response.StatusCode}");
        _logger.LogInformation($"####################################");
    }
}
