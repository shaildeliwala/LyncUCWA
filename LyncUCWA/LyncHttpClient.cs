using LyncUCWA.Helpers;
using LyncUCWA.Properties;
using System;
using System.Net.Http;

public class LyncHttpClient : HttpClient
{
    public static bool IsLoggedIn { get; set; }

    /// <summary>
    /// Build a new Lync UCWA request object.
    /// </summary>
    /// <param name="url">URI of the resource</param>
    /// <remarks>
    /// Using the inbuilt class would possibly lead to confusion later as the code expands.
    /// Therefore, it was decided that a "dedicated" class would handle the requests for this application.
    /// </remarks>
    public LyncHttpClient()
    {
        this.BaseAddress = new Uri(Settings.Default.DomainAddress);
        if (!Settings.Default.OAuthToken.IsEmpty())
        {
            this.DefaultRequestHeaders.Add("Authorization", Settings.Default.OAuthToken.StartsWith("Bearer") ?
                Settings.Default.OAuthToken : String.Concat("Bearer ", Settings.Default.OAuthToken));
        }
    }
}