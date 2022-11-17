using CajeroMovil.MVVM.ViewModels;
namespace CajeroMovil.MVVM.Views;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }
}