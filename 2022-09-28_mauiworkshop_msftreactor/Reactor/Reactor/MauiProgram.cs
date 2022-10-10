using Reactor.Services;
using Reactor.ViewModels;
using Reactor.Views;

namespace Reactor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<DetailsViewModel>();

		builder.Services.AddSingleton<IMonkeyService, MonkeyService>();

		return builder.Build();
	}
}

