namespace APIServiceLayer.RequestFeedback;

public class ServerErrorResponse
{
    public int StatusCode { get; set; } = 200;
    public string Message { get; set; } = string.Empty;
    public string ExceptionMessage { get; set; } = string.Empty;
}