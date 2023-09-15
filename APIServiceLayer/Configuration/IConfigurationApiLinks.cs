namespace APIServiceLayer.Configuration;

public abstract class ConfigurationApiLinks
{
    protected string _filepath;

    protected ConfigurationApiLinks(string filepath)
    {
        _filepath = filepath;
    }

    public string PostUserUrl { get; } = string.Empty;
    public string GetUserAuthTokenUrl { get; } = string.Empty;
    public string GetUserInfoUrl { get; } = string.Empty;
}