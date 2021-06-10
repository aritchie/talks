using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Locations;


namespace App1.Gps
{
    public class GpsViewModel : ViewModel
    {
        IDisposable? foreground;


        public GpsViewModel(IGpsManager gps)
        {
            this.Start = ReactiveCommand.CreateFromTask(
                async () =>
                {
                    this.foreground = gps
                        .WhenReading()
                        .Subscribe(reading =>
                        {
                            this.Latitude = reading.Position.Latitude;
                            this.Longitude = reading.Position.Longitude;
                        });

                    await gps.StartListener(GpsRequest.Realtime(true));
                }
            );

            this.Stop = ReactiveCommand.CreateFromTask(async () =>
            {
                await gps.StopListener();
                this.foreground?.Dispose();
            });
        }


        public ICommand Start { get; }
        public ICommand Stop { get; }
        [Reactive] public double Latitude { get; private set; }
        [Reactive] public double Longitude { get; private set; }
    }
}
