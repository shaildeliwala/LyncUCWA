using LyncUCWA.Service;
using System;
using System.Net.Http;

public class UCWAHttpClient : HttpClient
{
    public static bool IsLoggedIn { get; set; }

    /// <summary>
    /// Build a Lync UCWA request object with the domain address as its base address and the OAuth token as its Authorization header value.
    /// </summary>
    public UCWAHttpClient()
    {
        this.BaseAddress = Configuration.Instance().DomainAddress;
        //AuthenticationHeaderValue headerValue;
        //if (AuthenticationHeaderValue.TryParse(Configuration.Instance().OAuthToken, out headerValue))
        //    httpClient.DefaultRequestHeaders.Authorization = headerValue;
                    
        if (!Configuration.Instance().OAuthToken.IsEmpty())
        {
            this.DefaultRequestHeaders.Add("Authorization", Configuration.Instance().OAuthToken.StartsWith("Bearer") ?
                Configuration.Instance().OAuthToken : String.Concat("Bearer ", Configuration.Instance().OAuthToken));
        }
    }
}