using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USB.Model;
using MTPDevices;
using USBEject;

namespace USB.Api
{
    class UsbManager
    {
        private List<string> UsbDrivesList { get; set; }
        private VolumeDeviceClass volumeDeviceClass;
        private PortableDeviceCollection portableDevices;

        public UsbManager()
        {}

        public List<UsbDevice> GetUserUsbDevices()
        {
            List<string> usbDevicesInfoStr = GetUsbDrivesList();
            List<UsbDevice> usbDevices = ConvertStrListToDeviceList(usbDevicesInfoStr);

            return usbDevices;
        }

        private List<string> GetUsbDrivesList()
        {
            this.volumeDeviceClass = new VolumeDeviceClass();
            this.FillUsbDrivesList();
            return this.UsbDrivesList;
        }

        public void EjectDrive(string name)
        {
            var volume = this.volumeDeviceClass.Devices
                .FirstOrDefault(vol => ((Volume) vol).LogicalDrive == name);
            if (volume != null)
            {
                volume.Eject(false);
            }
            else
            {
                var device = this.portableDevices.FirstOrDefault(x => x.FriendlyName == name);
                if (device != null)
                {
                    device.Eject();
                    device.Disconnect();
                }
            }
        }

        private void FillUsbDrivesList()
        {
            this.UsbDrivesList = this.volumeDeviceClass.Devices
                .Where(volume => volume.IsUsb)
                .Select(volume => ((Volume)volume).LogicalDrive)
                .ToList();
        }

        public UsbDevice CreateUsbFieldData(string usb)
        {
            var info = this.GetUsbInfo(usb);
            UsbDevice device = new UsbDevice();
            device.setDeviceLetter(usb);
            if(info.IsReady == true)
            {
                device.setDeviceAllMemory(info.TotalSize);
                device.setDeviceFreeMemory(info.AvailableFreeSpace);
                device.setDeviceUsedMemory(info.TotalSize - info.AvailableFreeSpace);
                device.setDeviceName(info.VolumeLabel);
            }

            return device;
        }

        private System.IO.DriveInfo GetUsbInfo(string name)
        {
            var drives = System.IO.DriveInfo.GetDrives();
            return drives.FirstOrDefault(x => x.Name == name + @"\");
        }

        private List<UsbDevice> ConvertStrListToDeviceList(List<string> usbDeviceInfoStr)
        {
            var usbDeviceList = new List<UsbDevice>();
            foreach (var usb in usbDeviceInfoStr)
            {
                UsbDevice usbDevice = CreateUsbFieldData(usb);
                usbDeviceList.Add(usbDevice);
            }
            return usbDeviceList;
        }
    }
}
