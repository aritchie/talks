using Shiny.Jobs;
using Shiny.Notifications;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace App1
{
    public class MyJob : IJob
    {
        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
        }
    }
}

























//using Shiny.Jobs;
//using Shiny.Notifications;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging;


//namespace App1
//{
//    public class MyJob : IJob
//    {
//        readonly INotificationManager notifications;
//        readonly ILogger logger;

//        public MyJob(INotificationManager notifications, ILogger<MyJob> logger)
//        {
//            this.notifications = notifications;
//            this.logger = logger;
//        }


//        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
//        {
//            await this.notifications.Send("Test", "Hello from job!");
//        }
//    }
//}