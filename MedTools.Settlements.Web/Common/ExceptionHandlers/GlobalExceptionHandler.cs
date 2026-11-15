using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

using MedTools.Settlements.Application.Common.Exceptions;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            EntityNotFoundException ex => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Указанный ресурс не найден.",
                Detail = ex.Message
            },

            _ => null
        };

        if (problemDetails is null) return false;

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await Results.Problem(problemDetails)
            .ExecuteAsync(httpContext);

        return true;
    }
}