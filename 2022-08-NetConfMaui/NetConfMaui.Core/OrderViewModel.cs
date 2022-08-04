using NetConfMaui.Services;
using System.Windows.Input;

namespace NetConfMaui;


public class OrderViewModel : BaseViewModel
{
    public OrderViewModel(ITaxService taxService)
    {
        Calculate = new Command(async () =>
        {
#if MACCATALYST || IOS
            var subtotal = SubTotal + 1.0;
#elif ANDROID
            var subtotal = SubTotal + 0.5;
#else
            var subtotal = SubTotal;
#endif
            Total = await taxService.CalculateTotal(subtotal);
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
