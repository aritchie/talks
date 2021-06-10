using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Push;


namespace App1.Push
{
    public class PushViewModel : ViewModel
    {
        IDisposable? foreground;


        public PushViewModel(IPushManager pushManager)
        {
            this.Register = ReactiveCommand.CreateFromTask(
                async () =>
                {
                    this.foreground = pushManager
                        .WhenReceived()
                        .Subscribe(push =>
                        {
                            this.Message = push.Notification?.Message ?? "There was no message but something kicked you!";
                        });

                    var result = await pushManager.RequestAccess();
                    if (result.Status == AccessState.Available)
                    {
                        this.Result = "Your push token is " + result.RegistrationToken;
                    }
                    else
                    {
                        this.Result = "FAILED!!";
                    }
                }
            );
            this.UnRegister = ReactiveCommand.CreateFromTask(
                async () =>
                {
                    await pushManager.UnRegister();
                    this.foreground?.Dispose();
                }
            );
        }


        [Reactive] public string Message { get; private set; }
        [Reactive] public string Result { get; private set; }
        public ICommand Register { get; }
        public ICommand UnRegister { get; }
    }
}
