

using CajeroMovil.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CajeroMovil.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class itemsListViewModel
    {

        //public Item Item { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        //Constructor
        public itemsListViewModel() 
        {
            Items = new ObservableCollection<Item>();

        }

        public ICommand ClickCommand =>
            new Command(Alert);

        public ICommand DeleteCommand =>
            new Command( (p) => 
            {

                if (Items.Count == 1)
                {
                    Items = new ObservableCollection<Item>();
                }else Items.Remove((Item)p);
            });

        private void Alert() 
        {
            
            Items.Add(new Item { id = 3, name = "Item agregado", price = 500, description = "hola", linkImg = "dotnet_bot.svg" });
            //App.Current.MainPage.DisplayAlert("Titulo", "message", "Ok");
        }


    }
}
