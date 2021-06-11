using Shiny.Push;

using System;
using System.Threading.Tasks;

namespace App1
{
    public class MyPushDelegate : IPushDelegate
    {
        public Task OnEntry(PushNotificationResponse response)
        {
            throw new NotImplementedException();
        }

        public async Task OnReceived(PushNotification notification)
        {
        }

        public Task OnTokenChanged(string token)
        {
            throw new NotImplementedException();
        }
    }
}
