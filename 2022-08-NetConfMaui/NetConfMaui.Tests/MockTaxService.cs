using NetConfMaui.Services;


namespace NetConfMaui.Tests
{
    public class MockTaxService : ITaxService
    {
        public double TaxRate { get; set; }


        public double CalculateTotal(double subtotal)
        {
            return Math.Round(subtotal * TaxRate, 2);
        }
    }
}
