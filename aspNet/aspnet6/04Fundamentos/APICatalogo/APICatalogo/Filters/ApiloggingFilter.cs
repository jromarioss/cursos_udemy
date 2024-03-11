using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters;

public class ApiloggingFilter : IActionFilter
{
    private readonly ILogger<ApiloggingFilter> _logger;
    public ApiloggingFilter(ILogger<ApiloggingFilter> logger)
    {
        _logger = logger;
    }

    //executa antes da action
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("## Executando -> OnActionExecuting");
        _logger.LogInformation($"## ModelState: {context.ModelState.IsValid}");
    }

    //executa depois da action
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("## Executando -> OnActionExecuted");
    }
}
