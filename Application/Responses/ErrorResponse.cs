namespace Application.Responses;

public class ErrorResponse(string message, int statusCode)
{
	public string? Message { get; } = message;
	public int StatusCode { get; } = statusCode;
}
