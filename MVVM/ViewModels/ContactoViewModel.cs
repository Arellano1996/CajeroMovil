using System.Windows.Input;

namespace CajeroMovil.MVVM.ViewModels
{
    public class ContactoViewModel
    {
        public ICommand ContactoLaunchWhatsAppCommand =>
            new Command(async () =>
            {
                //if (PhoneDialer.Default.IsSupported) PhoneDialer.Default.Open("812-372-9803");
                try
                {
                    await Launcher.Default.OpenAsync($"whatsapp://send?phone=+{528123729803}");
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Unable to open WhatsApp.", "OK");
                }
            });
    }
}
