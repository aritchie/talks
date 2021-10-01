using Microsoft.Extensions.DependencyInjection;
using Shiny;


namespace App1
{
    public class MyShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {
            services.RegisterJob(new Shiny.Jobs.JobInfo(typeof(MyJob)) {
            });
            services.UseNotifications();
        }
    }
}