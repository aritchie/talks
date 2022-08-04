using NetConfMaui.Services;
using Xunit;
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
    public async Task CalculateTax_TaxService_Integration_Async()
    {
        // this tax service was ported from a very old piece of code - we will use it in our MAUI application now
        // note that we have no control of the tax rate here - it is likely doing internal logic or pulling from a remote service to calculate
        var taxService = new TaxService();

        var vm = new Order3ViewModel(taxService);
        var subtotal = CreateRandomSubtotal();
        vm.SubTotal = subtotal;
        _output.WriteLine("Using Sub-Total: " + subtotal);

        vm.Calculate.Execute(null);

        var total = CalculateExpectedTotal(subtotal);
        _output.WriteLine("Expected Total: " + total);

        var tcs = new TaskCompletionSource<bool>();
        vm.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(Order2ViewModel.Total))
                tcs.SetResult(true);
        };

        await tcs.Task;
        Assert.Equal(vm.Total, total);
    }


    double CreateRandomSubtotal() => Math.Round(new Random().Next(1000, 10000) * 1.01, 2);

    // subtotal + 13% harmonized sales tax in Ontario, Canada
    double CalculateExpectedTotal(double subtotal)
    {
#if MACCATALYST || IOS
        subtotal += 1.0;
#else
        subtotal += 0.5;
#endif
        return Math.Round(subtotal * 1.13, 2);
    }
}