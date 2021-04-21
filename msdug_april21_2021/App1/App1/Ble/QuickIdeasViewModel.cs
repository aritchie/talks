using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.BluetoothLE;

namespace App1.Ble
{
    public class QuickIdeasViewModel : ViewModel
    {
        public QuickIdeasViewModel(IBleManager bleManager)
        {
            this.FindItAndRead = ReactiveCommand.Create(() =>
            {
                bleManager
                    .ScanUntilPeripheralFound("My Peripheral Name", true)
                    .Select(x => x.WithConnectIf())
                    .Switch()
                    .Select(x => x.ReadCharacteristic("ServiceUUID", "CharUUID"))
                    .Switch()
                    .Take(1)
                    .SubOnMainThread(
                        data => this.ReadText = Encoding.ASCII.GetString(data)
                    );
            });
        }


        public ICommand FindItAndRead { get; }
        [Reactive] public string ReadText { get; private set; }
    }
}
