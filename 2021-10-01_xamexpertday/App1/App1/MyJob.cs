using Shiny.Jobs;
using Shiny.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace App1
{
    public class MyJob : IJob
    {
        readonly INotificationManager notifications;

        public MyJob(INotificationManager notifications)
        {
            this.notifications = notifications;
        }


        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            await this.notifications.Send("Hi", "I'm firing from a background job");
        }
    }
}
