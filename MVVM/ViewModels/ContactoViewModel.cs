

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CajeroMovil.MVVM.ViewModels
{
    public partial class ContactoViewModel : ObservableObject
    {
        [ObservableProperty]
        string subject = "";

        [ObservableProperty]
        string body = "";

        List<string> recipients = new List<string>();

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    To = recipients,
                    Subject = subject,
                    Body = body,
                    BodyFormat = EmailBodyFormat.PlainText
                };

                await Email.ComposeAsync(message);

            }
            catch (FeatureNotEnabledException ex1)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex1.Message, "OK");
            }
            catch (Exception ex2)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex2.Message, "OK");
            }
        }

        [RelayCommand]
        async void Button_Clicked()
        {
            if (subject.Equals(""))
            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Escribe un asunto", "ok");
            } else if (body.Equals("")) 
            {
                await App.Current.MainPage.DisplayAlert("Aviso", "Escribe un mensaje", "ok");
            }
            else
            {
                recipients.Add("l18480876@nuevoleon.tecnm.mx");
                await SendEmail(subject, body, recipients);
            }
                        
        }
    }
}
