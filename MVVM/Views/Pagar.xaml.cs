using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class Pagar : ContentPage
{
    public Pagar(PagarViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}