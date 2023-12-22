namespace APIServiceLayer.RequestFeedback;

public class RequestFeedbackException : Exception
{
    public RequestFeedbackException(ServerErrorResponse bodyErrorModel)
    {
        BodyErrorModel = bodyErrorModel;
    }

    public ServerErrorResponse BodyErrorModel { get; set; }
}