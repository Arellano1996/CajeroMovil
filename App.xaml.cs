using CajeroMovil.MVVM.Views;

namespace CajeroMovil;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new itemsList();
        MainPage = new AppShell();
    }
}
