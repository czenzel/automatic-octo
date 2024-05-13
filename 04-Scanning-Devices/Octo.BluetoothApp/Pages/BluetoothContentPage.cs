using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octo.BluetoothApp.Pages
{
    public partial class BluetoothContentPage : ContentPage
    {
        internal delegate void OnBluetoothPermissions(object sender);
        internal event OnBluetoothPermissions? BluetoothPermissions;

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
                else
                {
                    BluetoothPermissions?.Invoke(this);
                }
            }
            else
            {
                BluetoothPermissions?.Invoke(this);
            }
        }
    }
}
