using ZXing.Net.Maui;

namespace CajeroMovil.MVVM.Views;

public partial class QRScan : ContentPage
{
	public QRScan()
	{
		InitializeComponent();
	}
    private void Barcode(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            barcodeResult.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });

    }
}