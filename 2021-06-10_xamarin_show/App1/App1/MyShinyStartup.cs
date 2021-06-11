using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Microsoft.Extensions.Logging;


namespace App1
{
    public class MyShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {
            services.RegisterJob(new Shiny.Jobs.JobInfo(typeof(MyJob)) {
                DeviceCharging = true,
                BatteryNotLow = true,
                RequiredInternetAccess = Shiny.Jobs.InternetAccess.Any
            });
            services.UseNotifications();

            //services.UsePush<MyPushDelegate>();
            //services.UsePushAzureNotificationHubs<MyPushDelegate>("Listener connection string", "hub name");
        }


        public override void ConfigureLogging(ILoggingBuilder builder, IPlatform platform)
        {
            builder.AddAppCenter("AppCenterSecret");
        }
    }
}









////services.UsePush<MyPushDelegate>();
//services.UsePushAzureNotificationHubs<MyPushDelegate>("", "");