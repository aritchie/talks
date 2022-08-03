using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetConfMaui;


public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected virtual bool Set<T>(ref T property, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
            return false;

        property = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
