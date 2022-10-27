using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;


namespace CajeroMovil.ViewModel
{
    partial class RegisterViewModel :  LoadViewModel
    {
        public string webApiKey = "AIzaSyAW2GsDfP3G1L8jSFsjKGGnB19VzwXR8jg";

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        public RegisterViewModel()
        {

        }

        [RelayCommand]
        async Task RegisterUserAsync(object obj)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                Console.WriteLine(token);
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Alerta", "Te has registrado exitosamente", "OK");
                    await Shell.Current.GoToAsync("../", true);

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("InvalidEmailAddress"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Email no valido, ingrese el formato correcto", "OK");

                } else if (ex.Message.Contains("EmailExists"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "El email ya existe", "OK");
                }
                else if (ex.Message.Contains("WeakPassword"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "La contraseña debe tener minimo 6 caracteres", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "OK");
                    throw;
                }     
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
