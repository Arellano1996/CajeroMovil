using CajeroMovil.MVVM.Models;
using CajeroMovil.MVVM.ViewModels;
using PropertyChanged;
using System.Text.Json;

namespace CajeroMovil.MVVM.Views;

public partial class Pagar : ContentPage
{
    public Pagar(PagarViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}