using System.Collections.ObjectModel;
using System.Windows.Input;
using ReactiveUI;
using Shiny;
using Shiny.BluetoothLE;



namespace App1.Ble
{
    public class ScanViewModel : ViewModel
    {
        public ScanViewModel(IBleManager bleManager)
        {
            this.Start = ReactiveCommand.CreateFromTask(async () =>
            {
                bleManager
                    //.ScanForUniquePeripherals() // this gives you the peripheral, not the scan results
                    .Scan()
                    .SubOnMainThread(result =>
                        // scan results duplicate per device as the RSSI and device name is read/changed
                        this.Results.Add(result)
                    );
            });
            this.Stop = ReactiveCommand.Create(() => bleManager.StopScan());
        }


        public ICommand Start { get; }
        public ICommand Stop { get; }
        public ObservableCollection<ScanResult> Results { get; } = new ObservableCollection<ScanResult>();
    }
}
