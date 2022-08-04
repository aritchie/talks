using NetConfMaui.Services;


namespace NetConfMaui.Tests
{
    public class MockTaxService : ITaxService
    {
        public double TaxRate { get; set; }


        public Task<double> CalculateTotal(double subtotal)
        {
            return Task.FromResult(Math.Round(subtotal * TaxRate, 2));
        }
    }
}
