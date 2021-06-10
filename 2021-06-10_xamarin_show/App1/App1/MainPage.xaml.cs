using Shiny;
using Shiny.Jobs;
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
            await ShinyHost.Resolve<IJobManager>().RunAll(CancellationToken.None, false);
        }
    }
}