using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class Contacto : ContentPage
{
	public Contacto(ContactoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}