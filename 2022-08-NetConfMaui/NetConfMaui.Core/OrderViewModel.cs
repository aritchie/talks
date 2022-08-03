namespace NetConfMaui;


public class OrderViewModel : BaseViewModel
{
    double subtotal;
    public double SubTotal
    {
        get => subtotal;
        set
        {
            Set(ref subtotal, value);
            Total = subtotal + Math.Round(subtotal * 0.13, 2); // 13% HST in Ontario, Canada
        }
    }


    double total;
    public double Total
    {
        get => total;
        private set => Set(ref total, value);
    }
}
