using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.Views;
using Microsoft.Maui;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using static Android.Content.ClipData;
using Item = CajeroMovil.MVVM.Models.Item;

namespace CajeroMovil.MVVM.ViewModels
{
    //[AddINotifyPropertyChangedInterface]
    public class PagarViewModel
    {
        ItemsListViewModel Vm;
        historialViewModel Hvm;
        public string itemsString { get; set; }
        public float precioTotal { get; set; }
        public List<Item> items = new List<Item>();
        public PagarViewModel(ItemsListViewModel vm, historialViewModel hvm)
        {
            itemsString = "";
            precioTotal = 0;
            GetItems(vm.Items);
            Vm = vm;
            Hvm = hvm;
        }
        //Este método toma los items de la lista y los transforma en un string
        //Al mismo tiempo está sumando el total a pagar por los items
        public void GetItems(ObservableCollection<Item> Items)
        {
            foreach (var item in Items)
            {
                items.Add(item);
                //agregarDatoASql(item, fecha);
                precioTotal += item.price;
            }
            itemsString = JsonSerializer.Serialize(items);
        }

        public void agregarDatoASql()
        {
            DateTime fecha = DateTime.Now;

            foreach (var item in items)
            {
                App.cr.AddorUpdate(new articuloBaseDatos
                {
                    nombre = item.name,
                    precio = item.price,
                    fecha = fecha
                });
            }
            Console.WriteLine(App.cr.StatusMessage);
        }
        public ICommand btnAceptarCommand =>
            new Command(async () =>
            {
                agregarDatoASql();
                Vm.Items.Clear();
                Hvm.Refresh();
                await Shell.Current.GoToAsync("../");
            });
    }
}