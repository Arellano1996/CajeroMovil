using CajeroMovil.Services.Repositorios;

namespace CajeroMovil;

public partial class App : Application
{
    public static customRepository cr { get; private set; }
    public App(customRepository repo)
    {
        InitializeComponent();
        cr = repo;
        //MainPage = new itemsList();
        MainPage = new AppShell();
    }
}
