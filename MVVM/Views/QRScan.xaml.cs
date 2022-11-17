using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;
using ZXing.Net.Maui;

namespace CajeroMovil.MVVM.Views;

public partial class QRScan : ContentPage
{
    QRScanViewModel bindingViewModel;
	public QRScan(QRScanViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        bindingViewModel = vm;
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar la compatibilidad de la plataforma", Justification = "<pendiente>")]
    private void Barcode(object sender, BarcodeDetectionEventArgs e)
    {
        Dispatcher.Dispatch( () =>
        {
            bindingViewModel.QRDetected(e.Results[0].Value);
        });
    }
}