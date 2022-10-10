using System;
using System.Windows.Input;
using Reactor.Models;
using Reactor.Services;

namespace Reactor.ViewModels;


public class MainViewModel : BaseViewModel
{
    public MainViewModel(IMonkeyService service)
    {
        Load = new Command(async () =>
        {
            this.IsBusy = true;
            this.Monkeys = await service.GetMonkeys();
            this.RaisePropertyChanged(nameof(this.Monkeys));
            this.IsBusy = false;
        });
    }


    public ICommand Load { get; }
    public List<Monkey> Monkeys { get; private set; }
}

