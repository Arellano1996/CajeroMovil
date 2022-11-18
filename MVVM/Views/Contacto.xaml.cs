using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class Contacto : ContentPage
{
    public Contacto()
    {
        InitializeComponent();
        BindingContext = new ContactoViewModel();
    }
}