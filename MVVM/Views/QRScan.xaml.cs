using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;
using Org.Json;
using System.Text.Json;
using System.Windows.Input;
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
    private void Barcode(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch( async() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
            //App.Current.MainPage.DisplayAlert("Titulo", $"{e.Results[0].Value} {e.Results[0].Format}", "Ok");
            if (!isBusy) 
            {
                
                var v = JsonSerializer.Deserialize<Item>(e.Results[0].Value.ToString());
                hola.AddItem(v);    
                isBusy = true;
            }
            await Navigation.PopAsync();
        });
       
    }
}