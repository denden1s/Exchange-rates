using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Client_app.ViewModels;

namespace Client_app
{
    public partial class MainWindow : Window
    {
        private ServerConnection _connectionWindow;
        
        public ViewModel Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new ViewModel("");
            DataContext = Model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RequestButton.IsEnabled = false;
            Model.GetDataAsync(RequestButton, CurrencyType.SelectedValue.ToString(), StartPeriod.Text, EndPeriod.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _connectionWindow = ServerConnection.GetInstance(Model);
            _connectionWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_connectionWindow != null)
                _connectionWindow.Close();
        }
    }
}