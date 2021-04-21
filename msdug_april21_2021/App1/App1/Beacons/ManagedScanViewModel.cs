using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;
using Shiny;
using Shiny.Beacons;
using Shiny.Beacons.Managed;

namespace App1.Beacons
{
    public class ManagedScanViewModel : ViewModel
    {
        static readonly BeaconRegion MyRegion = new BeaconRegion(
            "MyBeacons",
            Guid.Parse("my guid")
        );
        readonly ManagedScan scanner;

        public ManagedScanViewModel(IBeaconRangingManager ranging)
        {
            this.scanner = ranging.CreateManagedScan();

            this.Start = ReactiveCommand.Create(
                () => this.scanner.Start(MyRegion, RxApp.MainThreadScheduler)
            );
            this.Stop = ReactiveCommand.Create(
                () => this.scanner.Stop()
            );
        }


        public ICommand Start { get; }
        public ICommand Stop { get; }
        public ObservableCollection<ManagedBeacon> Beacons
            => this.scanner.Beacons;
    }
}
