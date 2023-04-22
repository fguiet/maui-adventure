using ble_helloworld.Interfaces;
using ble_helloworld.Model;
using Shiny.BluetoothLE;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace ble_helloworld.Services
{
    public class BluetoothService : IBluetoothService
    {
        private readonly IBleManager _bleManager;
        private readonly ObservableCollection<BluetoothDevice> _devices = new ObservableCollection<BluetoothDevice>();

        //private BluetoothDevice _connectedDevice;

        public BluetoothDevice ConnectedDevice => throw new NotImplementedException();
       
        public ObservableCollection<BluetoothDevice> ScanResults
        {
            get
            {
                return _devices;
            }
        }

        //public BluetoothClient(IMauiInterface mauiInterface)
        //{
        //    _bleManager = mauiInterface.Resolve(typeof(IBleManager)) as IBleManager;
        //}
        public BluetoothService(IBleManager bleManager)
        {
            _bleManager = bleManager;
        }

        public int Average()
        {
            throw new NotImplementedException();
        }

        public bool Connect(BluetoothDevice device)
        {
            throw new NotImplementedException();
        }

        public bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public void StartScan()
        {
            _devices.Clear();

            _bleManager.Scan().Subscribe(a =>
            {
                //ALready in list?
                if (_devices.Any(b => b.Uuid.Equals(a.Peripheral.Uuid)))
                    return;

                if (!String.IsNullOrEmpty(a.Peripheral.Name))
                {
                    _devices.Add(new BluetoothDevice()
                    {
                        Uuid = a.Peripheral.Uuid,
                        Device = a.Peripheral,
                        LocalName = a.Peripheral.Name,
                        Rssi = a.Rssi
                    });
                }
            });
        }

        public void StopScan()
        {
            _bleManager.StopScan();
        }
    }
}
