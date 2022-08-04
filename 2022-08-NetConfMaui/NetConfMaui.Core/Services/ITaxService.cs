namespace NetConfMaui.Services;

public interface ITaxService
{
    Task<double> CalculateTotal(double subtotal);
}
