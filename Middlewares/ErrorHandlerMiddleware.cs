using Newtonsoft.Json;
using TaskAPI.App.ErrorLogs;
using TaskAPI.Persistent.Data;
using TaskAPI.Shared;

namespace TaskAPI.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;  

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;  
    }

    public async Task InvokeAsync(HttpContext httpContext, IServiceScopeFactory scopeFactory)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled error occurred.");


            var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var errorLog = new ErrorLog( ex.Message,ex.StackTrace,DateTime.UtcNow,httpContext.Request.Path,
                httpContext.Request.QueryString.ToString(),httpContext.Request.Method);
 
            dbContext.ErrorLogs.Add(errorLog);
 
            await unitOfWork.SaveAsync();
            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            httpContext.Response.ContentType = "application/json; charset=utf-8";
            var data = ServiceResponse.FailedInstance(ex.Message);
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(data));
        }
    }
}