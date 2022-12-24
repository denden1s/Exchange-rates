using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Client_app.ViewModels;

namespace Client_app
{
    /// <summary>
    /// Логика взаимодействия для ServerConnection.xaml
    /// </summary>
    public partial class ServerConnection : Window
    {
        private static ServerConnection _instance;
        private ViewModel _model;
        private ServerConnection(ViewModel model)
        {
            InitializeComponent();
            _model = model;
        }
        public static ServerConnection GetInstance(ViewModel model)
        {
            if (_instance == null)
                _instance = new ServerConnection(model);
            return _instance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.SetServerAdress(EnteredUrl.Text);
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            _instance = null;
        }
    }
}