using CajeroMovil.MVVM.ViewModels;
using PropertyChanged;

namespace CajeroMovil.MVVM.Views;

public partial class Pagar : ContentPage
{
    public string h { get; set; }
	public Pagar(ItemsListViewModel vm)
	{
		InitializeComponent();
		BindingContext = this;
		h = vm.GetItemsToQR();
		setValue();
        //App.Current.MainPage.DisplayAlert("Titulo", "message", "Ok");
    }

	public void setValue() {
		BarCodeGen.Value = h;
    }
}