using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;
using System.Text.Json;
using ZXing.Net.Maui;

namespace CajeroMovil.MVVM.Views;

public partial class QRScan : ContentPage
{
    ItemsListViewModel hola;
    bool isBusy = false;
	public QRScan(ItemsListViewModel vm)
	{
		InitializeComponent();
        hola = vm;
	}
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>")]
    private void Barcode(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch( async() =>
        {
            //barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
            if (!isBusy) 
            {
                try
                {
                    var v = JsonSerializer.Deserialize<Item>(e.Results[0].Value.ToString());
                    hola.AddItem(v);
                    isBusy = true;
                    await Navigation.PopAsync();
                }
                catch (Exception e) { }
            }
        });
    }
}