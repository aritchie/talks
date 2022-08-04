using NetConfMaui.Services;
using System.Windows.Input;

namespace NetConfMaui;


public class Order2ViewModel : BaseViewModel
{
    public Order2ViewModel(ITaxService taxService)
    {
        Calculate = new Command(async () =>
        {
            Total = await taxService.CalculateTotal(SubTotal);
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
