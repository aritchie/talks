using System.Threading.Tasks;
using Shiny.Locations;

namespace App1.Gps
{
    public class MyGpsDelegate : IGpsDelegate
    {
        public async Task OnReading(IGpsReading reading)
        {
            // if you like your users - don't do notifications here ;)
            // store to a db
        }
    }
}
