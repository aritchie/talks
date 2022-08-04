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
    public void CalculateTax_TaxService()
    {
        var taxService = new MockTaxService { TaxRate = 1.13 };

        var vm = new OrderViewModel(taxService);
        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        vm.Calculate.Execute(null);

        var total = CalculateExpectedTotal(subtotal);
        _output.WriteLine("Expected Total: " + total);

        Assert.Equal(vm.Total, total);
    }



    [Fact]
    public async Task CalculateTax_TaxService_Integration()
    {
        var taxService = new TaxService();

        var vm = new OrderViewModel(taxService);
        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        vm.Calculate.Execute(null);

        var total = CalculateExpectedTotal(subtotal);
        _output.WriteLine("Expected Total: " + total);

        var tcs = new TaskCompletionSource<bool>();
        vm.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(OrderViewModel.Total))
                tcs.SetResult(true);
        };

        await tcs.Task;
        Assert.Equal(vm.Total, total);
    }




    double CreateRandomSubtotal() => Math.Round(new Random().Next(1000, 10000) * 1.01, 2);

    // subtotal + 13% harmonized sales tax in Ontario, Canada
    double CalculateExpectedTotal(double subtotal) => Math.Round(subtotal * 1.13, 2);
}