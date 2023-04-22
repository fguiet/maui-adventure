using CommunityToolkit.Mvvm.ComponentModel;

namespace ble_helloworld.ViewModel
{
    
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;       

    }
}
