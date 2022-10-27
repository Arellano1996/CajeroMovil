namespace CajeroMovil.View;
using CajeroMovil.ViewModel;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}