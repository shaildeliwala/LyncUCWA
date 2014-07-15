using LyncTest.JsonResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LyncTest.Helpers;

namespace LyncTest.PhoneAudio
{
    public class NumberTasks
    {
        public static async Task<Phones> GetPhones(ClsHref phonesLink)
        {
            //var phonesLink = Program.ApplicationResource._embedded.me._links.phones;
            if (phonesLink == null) return null;
            var response = await (new LyncHttpClient()).GetAsync(phonesLink.href);
            if (!response.IsSuccessStatusCode) return null;
            return await Task.Run<Phones>(async delegate
            {
                return JsonConvert.DeserializeObject<Phones>(await response.Content.ReadAsStringAsync());
            });
        }


        public static async Task<HttpResponseMessage> ChangeNumber(string changeNumberLink, string newNumber)
        {
            if (changeNumberLink.IsEmpty()) return null;
            var response = await (new LyncHttpClient()).PostAsync(
                changeNumberLink /*._links.changeNumber.href*/,
                new StringContent(String.Concat("{ \"number\":\"", newNumber, "\" }")));
            return response;
        }
    }
}
