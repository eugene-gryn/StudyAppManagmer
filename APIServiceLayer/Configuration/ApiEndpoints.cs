﻿namespace APIServiceLayer.Configuration;

public class ApiEndpoints
{
    public string EndpointApiBaseUrl() => $"{BaseApiUrl}{BaseApiVersion}";

    public string BaseApiUrl { get; set; }
    public string BaseApiVersion { get; set; }
    public string UserProfile { get; set; }
    public string Login { get; set; }
    public string Customer { get; set; }
}