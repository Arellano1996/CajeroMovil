using CajeroMovil.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace CajeroMovil.MVVM.ViewModels
{
    //[AddINotifyPropertyChangedInterface]
    public class PagarViewModel
    {
        public string itemsString { get; set; }
        public float precioTotal { get; set; }
        public PagarViewModel(ItemsListViewModel vm)
        {
            itemsString = "";
            precioTotal = 0;
            GetItems(vm.Items);
        }
        //Este método toma los items de la lista y los transforma en un string
        //Al mismo tiempo está sumando el total a pagar por los items
        public void GetItems(ObservableCollection<Item> Items)
        {
            List<Item> items = new List<Item>();
            foreach (var item in Items)
            {
                items.Add(item);
                precioTotal += item.price;
            }
            itemsString  = JsonSerializer.Serialize(items);
        }
    }
}
