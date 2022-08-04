namespace NetConfMaui.Services;


public class TaxService : ITaxService
{
    // This code was ported from code in the early 2000s - GST (Goods & Services Tax - 7%) + PST (Provincial Sales Tax - 8%)
    //const double OLD_UGLY_CONSTANT_THAT_WE_PORTED = 1.15;
    const double OLD_UGLY_CONSTANT_THAT_WE_PORTED = 1.13;


    public async Task<double> CalculateTotal(double subtotal)
    {
        // management wants us to move this to the server, so I decided to try to emulate a server call
        await Task.Delay(2000).ConfigureAwait(false);

        return Math.Round(subtotal * OLD_UGLY_CONSTANT_THAT_WE_PORTED, 2);
    }
}
