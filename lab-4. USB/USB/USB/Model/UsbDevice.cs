using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB.Model
{
    class UsbDevice
    {
        public string DeviceName { get; private set; }

        public string DeviceLetter { get; private set; }

        public string DeviceFreeMemory { get; private set; }

        public string DeviceUsedMemory { get; private set; }

        public string DeviceAllMemory { get; private set; }

        private readonly long BYTES_PER_GIGABYTE = 1024 * 1024 * 1024;

        public void SetDeviceName(string deviceName)
        {
            this.DeviceName = deviceName;
        }

        public void SetDeviceLetter(string deviceLetter)
        {
            this.DeviceLetter = deviceLetter;
        }

        public void SetDeviceFreeMemory(long deviceFreeMemory)
        {
            string deviceFreeMemoryStr = Round((double) deviceFreeMemory / BYTES_PER_GIGABYTE, 2) + " GB";
            this.DeviceFreeMemory = deviceFreeMemoryStr;
        }

        public void SetDeviceUsedMemory(long deviceUsedMemory)
        {
            string deviceUsedMemoryStr = Round((double) deviceUsedMemory / BYTES_PER_GIGABYTE, 2) + " GB";
            this.DeviceUsedMemory = deviceUsedMemoryStr;
        }

        public void SetDeviceAllMemory(long deviceAllMemory)
        {
            string deviceAllMemoryStr = Round((double) deviceAllMemory / BYTES_PER_GIGABYTE, 2) + " GB";
            this.DeviceAllMemory = deviceAllMemoryStr;
        }

        private double Round(double value, int places)
        {
            if (places < 0) throw new ArgumentException();

            long factor = (long) Math.Pow(10, places);
            value = value * factor;
            long tmp = (long) Math.Round(value);
            return (double) tmp / factor;
        }
    }
}
