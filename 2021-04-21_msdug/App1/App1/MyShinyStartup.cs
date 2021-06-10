using Microsoft.Extensions.DependencyInjection;
using Shiny;
using App1.Beacons;
using App1.Gps;
using App1.Push;
using Microsoft.Extensions.Logging;
using App1.HttpTransfers;

namespace App1
{
    public class MyShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {
            services.UseBeaconRanging();
            services.UseBeaconMonitoring<MyBeaconMonitorDelegate>();

            services.UseGps<MyGpsDelegate>();

            services.UsePush<MyPushDelegate>();
            services.UseFirebaseMessaging<MyPushDelegate>();
            services.UsePushAzureNotificationHubs<MyPushDelegate>(
                "Your Listener Connection String",
                "Hub Name"
            );

            services.UseHttpTransfers<MyHttpTransferDelegate>();
        }


        public override void ConfigureLogging(ILoggingBuilder builder, IPlatform platform)
        {
            builder.AddFirebase();
            builder.AddAppCenter("AppCenterSecret");
        }
    }
}
