using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;


namespace CajeroMovil.MVVM.ViewModels
{
    partial class LoginViewModel : LoadViewModel
    {
        public string webApiKey = "AIzaSyAW2GsDfP3G1L8jSFsjKGGnB19VzwXR8jg";

        [ObservableProperty]
        private string userEmail;

        [ObservableProperty]
        private string userPassword;


        public LoginViewModel()
        {

        }

        [RelayCommand]
        async Task GoToRegisterAsync()
        {
            await Shell.Current.GoToAsync("/RegisterPage", true);
        }

        [RelayCommand]
        async Task LoginUserAsync(object obj)
        {

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await Shell.Current.GoToAsync("////MainMenu", true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("InvalidEmailAddress"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Email no valido", "OK");
                }
                else if (ex.Message.Contains("UnknownEmailAddress"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Email desconocido", "OK");
                }
                else if (ex.Message.Contains("MissingPassword"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "Ingrese su contraseña", "OK");
                }
                else if (ex.Message.Contains("WrongPassword"))
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", "La contraseña es incorrecta", "OK");
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
