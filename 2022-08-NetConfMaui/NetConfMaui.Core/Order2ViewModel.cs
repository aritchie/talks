using NetConfMaui.Services;

namespace NetConfMaui;


public class Order2ViewModel : BaseViewModel
{
    readonly ITaxService _taxService;

    public Order2ViewModel(ITaxService taxService)
    {
        _taxService = taxService;
    }


    double subtotal;
    public double SubTotal
    {
        get => subtotal;
        set
        {
            Set(ref subtotal, value);
            Total = _taxService.CalculateTotal(subtotal);
        }
    }


    double total;
    public double Total
    {
        get => total;
        private set => Set(ref total, value);
    }
}
