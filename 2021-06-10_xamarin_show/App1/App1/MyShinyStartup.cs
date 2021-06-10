using Microsoft.Extensions.DependencyInjection;
using Shiny;
using Microsoft.Extensions.Logging;


namespace App1
{
    public class MyShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {

        }


        public override void ConfigureLogging(ILoggingBuilder builder, IPlatform platform)
        {
            builder.AddFirebase();
            builder.AddAppCenter("AppCenterSecret");
        }
    }
}
