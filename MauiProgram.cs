using CajeroMovil.MVVM.ViewModels;
using CajeroMovil.MVVM.Views;
using Microsoft.Extensions.DependencyInjection;
using ZXing.Net.Maui;

namespace CajeroMovil;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseBarcodeReader()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ItemsListViewModel>();
        builder.Services.AddTransient<PagarViewModel>();
        builder.Services.AddTransient<QRScanViewModel>();
        builder.Services.AddTransient<ContactoViewModel>();

        builder.Services.AddSingleton<itemsList>();
        builder.Services.AddTransient<QRScan>();
        builder.Services.AddTransient<Contacto>();
        builder.Services.AddTransient<Pagar>();


        return builder.Build();
	}
}
