using NetConfMaui;
using NetConfMaui.Services;
using Xunit.Abstractions;

namespace NetConfMaui.Tests;


public class OrderViewModelTests
{
    readonly ITestOutputHelper _output;

    public OrderViewModelTests(ITestOutputHelper output)
    {
        _output = output;
    }


    [Fact]
    public void CalculateTax()
    {
        var vm = new OrderViewModel();
        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        var total = Math.Round(subtotal * 1.13, 2);
        _output.WriteLine("Expected Total: " + total);

        Assert.Equal(vm.Total, total);
    }


    [Fact]
    public void CalculateTax_TaxService_Mock()
    {
        var taxRate = 1.13;
        var mock = new MockTaxService { TaxRate = taxRate }; // same tax rate as before
        var vm = new Order2ViewModel(mock);

        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        var total = CalculateExpectedTotal(subtotal);
        _output.WriteLine("Expected Total: " + total);

        Assert.Equal(vm.Total, total);
    }


    [Fact]
    public void CalculateTax_TaxService_Integration()
    {
        // this tax service was ported from a very old piece of code - we will use it in our MAUI application now
        // note that we have no control of the tax rate here - it is likely doing internal logic or pulling from a remote service to calculate
        var taxService = new TaxService();

        var vm = new Order2ViewModel(taxService);
        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        var total = CalculateExpectedTotal(subtotal);
        _output.WriteLine("Expected Total: " + total);

        Assert.Equal(vm.Total, total);
    }


    double CreateRandomSubtotal() => Math.Round(new Random().Next(1000, 10000) * 1.01, 2);

    // subtotal + 13% harmonized sales tax in Ontario, Canada
    double CalculateExpectedTotal(double subtotal) => Math.Round(subtotal * 1.13, 2);
}