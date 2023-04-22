using ble_helloworld.Interfaces;
using ble_helloworld.Services;
using ble_helloworld.ViewModel;
using Microsoft.Extensions.Logging;
using Shiny.Infrastructure;

namespace ble_helloworld;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseShiny()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		//Shiny Depency Injection
        RegisterShiny(builder.Services);

        //Create  instance ! (Singleton) not Transcient  
        builder.Services.AddSingleton<IBluetoothService, BluetoothService>();              
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();


        return builder.Build();
	}

    //Allow Shiny Depency Injection
    static void RegisterShiny(IServiceCollection s)
    {
        s.AddShinyCoreServices();
        s.AddBluetoothLE();
        s.AddBluetoothLeHosting();
    }
}
