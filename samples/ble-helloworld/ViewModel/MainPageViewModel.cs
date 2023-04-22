using ble_helloworld.Interfaces;
using ble_helloworld.Model;
using ble_helloworld.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ble_helloworld.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IBluetoothService _bluetoothClient;

        public ObservableCollection<BluetoothDevice> NearByDevices { get; set; } = new();

        //private readonly ObservableList<BluetoothDevice> _devices = new();

        public MainPageViewModel(IBluetoothService bluetoothClient)
        {
            Title = "Fred's Main Page";
            _bluetoothClient = bluetoothClient;
        }

        [RelayCommand]
        async Task StartBleScan()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await Task.Run(async () =>
            {
                try
                {
                    //Let's clear our list 
                    NearByDevices.Clear();

                    _bluetoothClient.StartScan();

                    _bluetoothClient.ScanResults.CollectionChanged += ScanResults_CollectionChanged;

                    //Start scanning for 10s
                    await Task.Delay(TimeSpan.FromSeconds(20));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);

                    //Please use an interface and some injection instead of put that in ViewModel 
                    await Shell.Current.DisplayAlert("Error!", $"Unable to scan BLE Devices: {ex.Message}", "OK");

                }
                finally
                {
                    _bluetoothClient.StopScan();
                    IsBusy = false;
                }
            });
        }

        private void ScanResults_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<BluetoothDevice> bleDeviceList = (ObservableCollection<BluetoothDevice>)sender;

            foreach (BluetoothDevice bleDevice in bleDeviceList)
            {
                if (NearByDevices.Any(b => b.Uuid.Equals(bleDevice.Uuid)))
                {
                    continue;
                }


                NearByDevices.Add(bleDevice);
            }
        }
    }
}
