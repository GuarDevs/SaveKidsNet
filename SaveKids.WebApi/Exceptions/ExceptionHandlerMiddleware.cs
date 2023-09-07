using SaveKids.Service.Exceptions;
using SaveKids.WebApi.Models;

namespace SaveKids.WebApi.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate request;

    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.request = request;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await request.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Massage = ex.Message,
            });
        }
        catch (AlreadyExistException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Massage = ex.Message,
            });
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Massage = ex.Message,
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            logger.LogError(ex.Message);
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Massage = ex.Message,
            });
        }
    }
}
