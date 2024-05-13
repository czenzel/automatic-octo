using Octo.BluetoothApp.Pages;
using Shiny;
using Shiny.BluetoothLE;

namespace Octo.BluetoothApp
{
    public partial class MainPage : BluetoothContentPage
    {
        private readonly IBleManager? _bleManager = null;

        public ObservableList<ScanResult> ScanResults { get; } = new ObservableList<ScanResult>();

        public MainPage()
        {
            InitializeComponent();

            this.BluetoothPermissions += MainPage_BluetoothPermissions;
            _bleManager = (App.Current as App)!.Services.GetService<IBleManager>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void MainPage_BluetoothPermissions(object sender)
        {
            _bleManager!.StopScan();

            _bleManager!.Scan().Subscribe(scanResult =>
            {
                if (ScanResults.Any(a => a.Peripheral.Uuid == scanResult.Peripheral.Uuid))
                    return;

                ScanResults.Add(scanResult);
            });
        }
    }

}
