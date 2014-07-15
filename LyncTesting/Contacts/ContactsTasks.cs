using LyncTest.JsonResponses;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LyncTest.Contacts
{
    public class ContactsTasks
    {
        internal async static Task<MyContacts> GetContacts()
        {
            //null checks and stuff still pending
            return await Task.Run<MyContacts>(async delegate
            {
                return JsonConvert.DeserializeObject<MyContacts>(
                    await (new LyncHttpClient()).
                    GetStringAsync(Program.ApplicationInstance._embedded.people._links.myContacts.href));
            });
        }
    }
}
