using System.Windows.Input;

namespace NetConfMaui;


public class OrderViewModel : BaseViewModel
{
    public OrderViewModel()
    {
        Calculate = new Command(() =>
        {
            Total = Math.Round(subtotal * 1.13, 2); // 13% HST in Ontario, Canada
        });
    }


    public ICommand Calculate { get; }


    double subtotal;
    public double SubTotal
    {
        get => subtotal;
        set => Set(ref subtotal, value);
    }


    double total;
    public double Total
    {
        get => total;
        private set => Set(ref total, value);
    }
}
