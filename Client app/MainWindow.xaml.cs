using System.Threading.Tasks;
using System.Windows;

namespace Client_app
{
    public partial class MainWindow : Window
    {
        public ViewModel Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new ViewModel();
            DataContext = Model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.GetDataAsync(CurrencyType.SelectedValue.ToString(), StartPeriod.Text, EndPeriod.Text);
        }
    }
}
