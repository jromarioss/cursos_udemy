using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _01APICatalogo.Filters;

public class ApiExeptionFilter : IExceptionFilter
{
    private readonly ILogger<ApiExeptionFilter> _logger;

    ApiExeptionFilter(ILogger<ApiExeptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Ocorreu um execeção não tratada.");
        context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação.")
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
    }
}
