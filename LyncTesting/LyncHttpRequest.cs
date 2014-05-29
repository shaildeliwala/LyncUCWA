using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class LyncHttpClient : System.Net.Http.HttpClient
{

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
        this.BaseAddress = new System.Uri(LyncTest.Properties.Settings.Default.DomainAddress);
        if (0 != LyncTest.Properties.Settings.Default.OAuthToken.Length)
        {
            this.DefaultRequestHeaders.Add("Authorization", LyncTest.Properties.Settings.Default.OAuthToken);
        }
    }

}