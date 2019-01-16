using GeoLib.Proxies;
using System.Diagnostics;
using System.Threading;
using System.Windows;


namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId +
                " | Process " + Process.GetCurrentProcess().Id.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBoxZipCode.Text))
            {
                GeoClient proxy = new GeoClient();
                var ret = proxy.GetZipCodeInfo(txtBoxZipCode.Text);
                lblCity.Content = ret.City;
                lblState.Content = ret.State;

                proxy.Close();
            }

           

        }
    }
}
