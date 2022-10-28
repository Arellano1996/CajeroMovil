using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;
using PropertyChanged;
using System.Text.Json;

namespace CajeroMovil.MVVM.Views;

public partial class Pagar : ContentPage
{
    public string h { get; set; }
	public float p { get; set; }	
	public Pagar(ItemsListViewModel vm)
	{
		InitializeComponent();
		BindingContext = this;
		h = vm.GetItemsToQR();
		setValue();
		p = 0;
		getPriceTotal();
        //App.Current.MainPage.DisplayAlert("Titulo", "message", "Ok");
    }

	public void setValue() {
		BarCodeGen.Value = h;
    }

	public void getPriceTotal() 
	{
        var v = JsonSerializer.Deserialize<List<Item>>(h);
		foreach (var item in v)
		{
			p += item.price;
		}
    }
}