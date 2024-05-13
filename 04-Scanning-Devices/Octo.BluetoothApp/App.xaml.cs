namespace Octo.BluetoothApp
{
    public partial class App : Application
    {
        public readonly IServiceProvider Services;

        public App(IServiceProvider services)
        {
            Services = services;
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
