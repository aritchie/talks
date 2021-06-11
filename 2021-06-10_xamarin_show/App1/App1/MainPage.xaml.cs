using System;
using Shiny;
using Shiny.Jobs;
using Shiny.Notifications;
using Shiny.Push;

using System.Linq;
using System.Threading;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await ShinyJobs.RunAll(CancellationToken.None, false);
            var access = await ShinyHost.Resolve<INotificationManager>().RequestAccess();

            var result = await ShinyHost.Resolve<IJobManager>().RunAll(CancellationToken.None, false);
            var success = result.FirstOrDefault().Success ? "Success" : "FAIL";

            await this.DisplayAlert("Job Done", "Yay!!  " + success, "OK");


            var push = ShinyHost.Resolve<IPushManager>();
            var pushAccess = await push.RequestAccess();

            push
                .WhenReceived()
                .Subscribe(pushNotification =>
                {
                    if (pushNotification.Data.ContainsKey("Message"))
                    {
                        Console.WriteLine(pushNotification.Data["Message"]);
                    }
                });
        }
    }
}