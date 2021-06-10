using Shiny.Net.Http;
using Shiny.Notifications;

using System;
using System.Threading.Tasks;

namespace App1.HttpTransfers
{
    public class MyHttpTransferDelegate : IHttpTransferDelegate
    {
        readonly INotificationManager notifications;

        public MyHttpTransferDelegate(INotificationManager notifications)
        {
            this.notifications = notifications;
        }

        public async Task OnCompleted(HttpTransfer transfer)
        {
            await this.notifications.Send(
                "Transfer Complete",
                $"{transfer.Identifier} complete"
            );
        }

        public async Task OnError(HttpTransfer transfer, Exception ex)
        {
            await this.notifications.Send(
                "Transfer Error",
                $"{transfer.Identifier} errored - SORRY!"
            );
        }
    }
}
