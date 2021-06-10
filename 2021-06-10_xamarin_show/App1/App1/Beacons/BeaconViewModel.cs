using System;
using System.Windows.Input;
using ReactiveUI;
using Shiny;
using Shiny.Beacons;


namespace App1.Beacons
{
    public class BeaconViewModel : ViewModel
    {
        static readonly BeaconRegion MyRegion = new BeaconRegion(
            "MyBeacons",
            Guid.Parse("my guid")
        );
        IDisposable? scan;

        public BeaconViewModel(IBeaconRangingManager ranging, IBeaconMonitoringManager monitoring)
        {
            this.Start = ReactiveCommand.Create(() => this.scan = ranging
                .WhenBeaconRanged(MyRegion)
                .Subscribe(beacon =>
                {
                    this.Beacons.Add(beacon);
                })
            );

            this.Stop = ReactiveCommand.Create(() => this.scan?.Dispose());

            this.StartMonitor = ReactiveCommand.CreateFromTask(
                () => monitoring.StartMonitoring(MyRegion)
            );
            this.StopMonitor = ReactiveCommand.CreateFromTask(
                () => monitoring.StopAllMonitoring()
            );
        }


        public ICommand Start { get; }
        public ICommand Stop { get; }


        public ICommand StartMonitor { get; }
        public ICommand StopMonitor { get; }

        public ObservableList<Beacon> Beacons { get; } = new ObservableList<Beacon>();
    }
}
