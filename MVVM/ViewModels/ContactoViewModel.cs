using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CajeroMovil.MVVM.ViewModels
{
    public class ContactoViewModel
    {
        public ICommand ContactoLaunchWhatsAppCommand =>
            new Command(() =>
            {
                if (PhoneDialer.Default.IsSupported) PhoneDialer.Default.Open("812-372-9803");
            });
    }
}
