namespace NetConfMaui.Services;


public class TaxService : ITaxService
{
    // This code was ported from code in the early 2000s - GST (Goods & Services Tax - 7%) + PST (Provincial Sales Tax - 8%)
    const double OLD_UGLY_CONSTANT_THAT_WE_PORTED = 1.15;


    public double CalculateTotal(double subtotal)
    {
        // we may go off to some remote http service to do this, for purposes of the example, we'll be doing this locally
        return subtotal * OLD_UGLY_CONSTANT_THAT_WE_PORTED;
    }
}
