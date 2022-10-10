using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reactor.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;


    bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }


    protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
    { 
        this.PropertyChanged?.Invoke(this, args);
    }


    protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    { 
        this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }


    protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
            return false;

        property = value;
        this.RaisePropertyChanged(propertyName);
        return true;
    }
}
