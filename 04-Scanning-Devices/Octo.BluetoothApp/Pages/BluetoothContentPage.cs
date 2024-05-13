using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.BluetoothApp.Pages
{
    public partial class BluetoothContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Start requesting permissions
            RequestPermissions();
        }

        private async void RequestPermissions()
        {
            var locationPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (locationPermission != PermissionStatus.Granted)
            {
                locationPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (locationPermission != PermissionStatus.Granted)
                {
                    await this.DisplayAlert("Location Permissions Required", "Location Permissions are required to scan for Bluetooth LE Devices", "Okay");
                }
            }

            var bluetoothPermission = await Permissions.RequestAsync<Permissions.Bluetooth>();

            if (bluetoothPermission != PermissionStatus.Granted)
            {
                bluetoothPermission = await Permissions.RequestAsync<Permissions.Bluetooth>();

                if (bluetoothPermission != PermissionStatus.Granted)
                {
                    await this.DisplayAlert("Bluetooth Permissions Required", "Bluetooth Permissions are required to scan and connect for/to Bluetooth LE Devices", "Okay");
                }
            }
        }
    }
}
