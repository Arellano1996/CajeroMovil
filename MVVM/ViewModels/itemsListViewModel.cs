

using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace CajeroMovil.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ItemsListViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        //Constructor
        public ItemsListViewModel() 
        {
            Items = new ObservableCollection<Item>();
        }
        public ICommand ClickCommand => new Command(Alert);
        public ICommand DeleteCommand =>
            new Command( (p) => 
            {
                if (Items.Count == 1)
                {
                    Items = new ObservableCollection<Item>();
                }else Items.Remove( (Item)p );
            });
        public ICommand ToQRCommand =>
            new Command(async () => 
            {
                await AppShell.Current.GoToAsync(nameof(QRScan));
            });
        async public void Alert() 
        {
            //Items.Add(new Item { id = 3, name = "Item agregado", price = 500, description = "hola", linkImg = "dotnet_bot.svg" });
            if (Items.Count == 0)
            {
                App.Current.MainPage.DisplayAlert("Lista vacía", "Aún no has agregado ningún artículo.", "Ok");
                return;
            }
            await AppShell.Current.GoToAsync(nameof(Pagar));
        }
        public void AddItem(Item i)
        {
            Items.Add(i);
        }
    }
}
