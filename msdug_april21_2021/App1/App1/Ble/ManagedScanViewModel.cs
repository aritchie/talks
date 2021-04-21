using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;
using Shiny;
using Shiny.BluetoothLE;
using Shiny.BluetoothLE.Managed;


namespace App1.Ble
{
    public class ManagedScanViewModel : ViewModel
    {
        readonly IManagedScan scanner;

        public ManagedScanViewModel(IBleManager bleManager)
        {
            this.scanner = bleManager
                .CreateManagedScanner(
                    RxApp.MainThreadScheduler,
                    TimeSpan.FromSeconds(10)
                )
                .DisposedBy(this.DeactivateWith);

            this.Toggle = ReactiveCommand.CreateFromTask(async () =>
                this.IsBusy = await this.scanner.Toggle()
            );
        }

        public ICommand Toggle { get; }
        public ObservableCollection<ManagedScanResult> Peripherals
            => this.scanner.Peripherals;
    }
}
