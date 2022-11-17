using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class historial : ContentPage
{
    public historial(historialViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}