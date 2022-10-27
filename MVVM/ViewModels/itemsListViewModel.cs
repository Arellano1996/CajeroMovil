

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

        //public Item Item { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        //Constructor
        public ItemsListViewModel() 
        {
            Items = new ObservableCollection<Item>();
            h = "";
        }

        public ICommand ClickCommand =>
            new Command(Alert);

        public ICommand DeleteCommand =>
            new Command( (p) => 
            {
                //App.Current.MainPage.DisplayAlert("Titulo", "message", "Ok");
                if (Items.Count == 1)
                {
                    Items = new ObservableCollection<Item>();
                }else Items.Remove((Item)p);
            });
        public ICommand ToQRCommand =>
            new Command(async () => 
            {
                await AppShell.Current.GoToAsync(nameof(QRScan));
            });

        public string h { get; set; }
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
            Items.Add(new Item 
            { 
                id = i.id, 
                name = i.name, 
                description = i.description, 
                linkImg = i.linkImg, 
                price = i.price 
            });
        }

        public string GetItemsToQR() 
        {
            List<Item> items = new List<Item>();    
            foreach (var item in Items) 
            {
                items.Add(item);
            }
            //return items;
            return JsonSerializer.Serialize(items);
            //h = JsonSerializer.Serialize(items).ToString();
        }

    }
}
