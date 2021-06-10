using Shiny.Push;

using System.Threading.Tasks;

namespace App1.Push
{
    public class MyPushDelegate : IPushDelegate
    {
        public async Task OnEntry(PushNotificationResponse response)
        {
            // this is when a user taps on or responds to a notification
        }


        public async Task OnReceived(PushNotification notification)
        {
            // this is when the notification comes in

            // example
            var command = notification.Data["Command"];
        }


        public async Task OnTokenChanged(string token)
        {
            // this is when the provider token changes - this really only happens with firebase
            // but you may need to send this token to your server to link with the user
        }
    }
}
