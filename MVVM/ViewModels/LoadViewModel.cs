using CommunityToolkit.Mvvm.ComponentModel;

namespace CajeroMovil.MVVM.ViewModels
{
    partial class LoadViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        public bool IsNotBusy => !IsBusy;

    }
}
