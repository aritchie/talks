using System.Threading.Tasks;
using Shiny.Beacons;
using Shiny.Notifications;

namespace App1.Beacons
{
    public class MyBeaconMonitorDelegate : IBeaconMonitorDelegate
    {
        readonly INotificationManager notifications;


        public MyBeaconMonitorDelegate(INotificationManager notifications)
        {
            this.notifications = notifications;
        }


        public async Task OnStatusChanged(BeaconRegionState newStatus, BeaconRegion region)
        {
            var msg = newStatus == BeaconRegionState.Entered
                ? "I see you"
                : "Hey! Where did you go?";

            await this.notifications.Send("Beacons", msg);
        }
    }
}
