using ble_helloworld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ble_helloworld.Interfaces
{
    public interface IBluetoothService
    {
        BluetoothDevice ConnectedDevice { get; }
        ObservableCollection<BluetoothDevice> ScanResults { get; }
        void StartScan();
        void StopScan();
        bool Connect(BluetoothDevice device);
        bool Disconnect();
        int Average();
    }
}
