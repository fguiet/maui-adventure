using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ble_helloworld.Model
{
    public class BluetoothDevice
    {
        public string Uuid { get; set; }
        public string LocalName { get; set; }
        public object Device { get; set; }
        public int Rssi { get; set; }
    }
}
