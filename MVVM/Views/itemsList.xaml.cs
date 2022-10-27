//using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;

namespace CajeroMovil.MVVM.Views;

public partial class itemsList : ContentPage
{
	public itemsList(ItemsListViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
	}
}