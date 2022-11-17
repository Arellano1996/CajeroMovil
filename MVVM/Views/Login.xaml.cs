using CajeroMovil.MVVM.ViewModels;
namespace CajeroMovil.MVVM.Views;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}