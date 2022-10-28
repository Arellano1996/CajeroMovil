using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CajeroMovil;
//Agregar nombre Label
//Agregar Icono Icon
[Activity(Label ="Cajero Movil", Icon = "@mipmap/splash2", Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}
