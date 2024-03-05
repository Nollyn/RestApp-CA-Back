namespace CleanArchitecture.Api.Errors;

public class CodeErrorResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public CodeErrorResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageStatusCode(statusCode);
    }

    private string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "The sent request contains errors",
            401 => "You are not allowed to access this",
            404 => "Not Found",
            500 => "Internal server error",
            _ => string.Empty
        };
    }
}