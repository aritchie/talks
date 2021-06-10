﻿using Shiny;
using Shiny.Jobs;
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
            var result = await ShinyHost.Resolve<IJobManager>().RunAll(CancellationToken.None, false);
            var success = result.FirstOrDefault().Success ? "Success" : "FAIL";

            await this.DisplayAlert("Job Done", "Yay!!  " + success, "OK");
        }
    }
}