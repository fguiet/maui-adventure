
using ble_helloworld.ViewModel;

namespace ble_helloworld;

public partial class MainPage : ContentPage
{


    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

        //Set Context for this pag
        BindingContext = viewModel;
    }

    /*private async void BLEScan_Clicked(object sender, EventArgs e)
    {
            
    }*/

    

}

