using CajeroMovil.MVVM.Models;
using System.Text.Json;


namespace CajeroMovil.MVVM.ViewModels
{
    public class QRScanViewModel : ContentPage
    {
        ItemsListViewModel itemslistViewModel;
        bool isBusy = false;
        public QRScanViewModel(ItemsListViewModel vm)
        {
            isBusy = false;
            itemslistViewModel = vm;
        }

        async public void QRDetected(string result)
        {
            if (!isBusy) 
            {
                try
                {
                    isBusy = true;
                    var item = JsonSerializer.Deserialize<Item>(result);
                    itemslistViewModel.AddItem(item);
                    await Shell.Current.GoToAsync("../");
                }
                catch (Exception err)
                {
                    isBusy = true;
                    App.Current.MainPage.DisplayAlert("Lista Detectada", $"Lista detectada: {result}", "Ok");
                }
            }
        }
    }
}
