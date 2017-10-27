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
            List<UsbDevice> mtpUsbDevices = GetUsbDevicesUsingMTP();
            List<UsbDevice> usbDevices = ConvertStrListToDeviceList(usbDevicesInfoStr);
            List<UsbDevice> resultList = MergeInfoUsbDeviceInfo(mtpUsbDevices, usbDevices);

            return resultList;
        }

        private List<string> GetUsbDrivesList()
        {
            this.volumeDeviceClass = new VolumeDeviceClass();
            this.FillUsbDrivesList();
            return this.UsbDrivesList;
        }

        private List<UsbDevice> MergeInfoUsbDeviceInfo(List<UsbDevice> mtpUsbDevices, List<UsbDevice> usbDevices)
        {
            for(var i = 0; i < mtpUsbDevices.Count; i++)
            {
                for (var j = 0; j < usbDevices.Count; j++)
                {
                    if (mtpUsbDevices.ElementAt(i).DeviceAllMemory
                        .Equals(usbDevices.ElementAt(j).DeviceAllMemory))
                    {
                        mtpUsbDevices.ElementAt(i)
                            .SetDeviceLetter(usbDevices.ElementAt(j).DeviceLetter);
                        mtpUsbDevices.ElementAt(i)
                            .SetDeviceName(usbDevices.ElementAt(j).DeviceName);
                        usbDevices.Remove(usbDevices.ElementAt(j));
                    }
                }
            }
            mtpUsbDevices.AddRange(usbDevices);
            return mtpUsbDevices;
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
            device.SetDeviceLetter(usb);
            if(info.IsReady == true)
            {
                device.SetDeviceAllMemory(info.TotalSize);
                device.SetDeviceFreeMemory(info.AvailableFreeSpace);
                device.SetDeviceUsedMemory(info.TotalSize - info.AvailableFreeSpace);
                device.SetDeviceName(info.VolumeLabel);
            }

            return device;
        }

        public List<UsbDevice> GetUsbDevicesUsingMTP()
        {
            this.portableDevices = new PortableDeviceCollection();
            this.portableDevices.Refresh();
            var resultDevices = new List<UsbDevice>();
            foreach (var device in this.portableDevices)
            {
                device.Connect();
                resultDevices.Add(GetMTPDevice(device));
            }
            return resultDevices;
        }

        private UsbDevice GetMTPDevice(PortableDevice device)
        {
            var contents = device.GetContents();
            long total = 0;
            long free = 0;
            foreach (var file in contents.Files)
            {
                total += file.TotalSize;
                free += file.FreeSpace;
            }
            long taken = total - free;

            UsbDevice usbDevice = new UsbDevice();
            usbDevice.SetDeviceName(device.FriendlyName);
            usbDevice.SetDeviceAllMemory(total);
            usbDevice.SetDeviceFreeMemory(free);
            usbDevice.SetDeviceUsedMemory(total - free);

            return usbDevice;
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
