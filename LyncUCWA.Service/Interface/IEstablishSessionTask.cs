using LyncUCWA.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyncUCWA.Service.Interface
{
    public interface IEstablishSessionTask : IBaseTask
    {
        Task InitiateSession(string userId, string password, string oauthToken);

        event EventHandler SessionEstablished;
    }


    public abstract class BaseEstablishSessionTask : IEstablishSessionTask
    {
        public event EventHandler SessionEstablished;
        public abstract Task InitiateSession(string userId, string password, string oauthToken = "");

        protected abstract Task<AutoDiscoverModel> AutoDiscover(string userId);

        // TODO Change parameter(s) to System.Uri type later
        // http://blogs.msdn.com/b/brada/archive/2004/01/12/58031.aspx
        protected abstract Task<BaseModel> FollowUser(string userUrl, string oauthToken);

        protected abstract Task<BaseModel> Authenticate(IEnumerable<string> authItems, string userId, string password);

        protected abstract Task<ApplicationModel> FollowApplications(string applicationUrl);

        protected virtual void OnSessionEstablished()
        {
            OnEvent(SessionEstablished);
        }

        /// <summary>
        /// Method to conveniently raise events
        /// </summary>
        /// <param name="myEvent">Event to be raised</param>
        /// <remarks>Copy to local variable http://stackoverflow.com/a/3857216 </remarks>  
        private void OnEvent(EventHandler myEvent)
        {
            var eventToRaise = myEvent;
            if (eventToRaise != null)
                eventToRaise(this, EventArgs.Empty);
        }

        private void OnEvent<TEventArgs>(EventHandler<TEventArgs> myEvent, TEventArgs eventArgs) where TEventArgs : EventArgs
        {
            var eventToRaise = myEvent;
            if (eventToRaise != null)
                eventToRaise(this, eventArgs);
        }
    }
}
