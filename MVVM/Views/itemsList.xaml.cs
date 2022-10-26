//using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class itemsList : ContentPage
{
	public itemsList()
	{
		InitializeComponent();
        
        /*
		var Item = new Item
        {
            id = 1,
            name = "Articulo name",
            description = "Esta es la descripción del articulo",
            linkImg = "https://imagen.com/"
        };
        BindingContext = Item;
        */

        BindingContext = new itemsListViewModel();
	}
}