namespace CajeroMovil.View;
using CajeroMovil.ViewModel;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
	}
}