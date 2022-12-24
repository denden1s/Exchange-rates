using Client_app.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client_app.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _currency;
        private string header;
        private string _url;
        private CurrencyTypes _types;
        private List<Rates> _rates;

        private void GetData(string type, string startPeriod, string endPeriod = "")
        {
            try
            {
                Header = "Ожидайте выполнения запроса";
                ValidOrException(startPeriod, endPeriod);

                string period = endPeriod == string.Empty ? "floating" : "concrete";
                string end = endPeriod == string.Empty ? "" : $"&{endPeriod}";
                string url = $"{_url}/api/ExchangeRates/{period}/{type}&{startPeriod}{end}";
                var _client = new RestClient(url);
                var _request = new RestRequest("", Method.Get);
                RestResponse response = _client.Execute(_request);
                if (response.Content == null)
                    throw new Exception("Невозможно подключиться к серверу");
                Rates = JsonSerializer.Deserialize<List<Rates>>(response.Content);
                string endToHeader = endPeriod == string.Empty ? DateTime.Now.ToString("d") : endPeriod;
                Header = $"Курс {type} к Белорусскому рублю на период {startPeriod} - {endToHeader}";
            }
            catch (UriFormatException)
            {
                Header = "Некорректный адрес сервера";
            }
            catch (Exception ex)
            {
                Header = ex.Message;
            }
        }

        private void ValidOrException(string startPeriod, string endPeriod = "")
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            bool dateEx = DateTime.TryParse(startPeriod, out startDate);
            if (!dateEx)
                throw new Exception("Начальная дата введена некорректно");
            if (endPeriod != string.Empty)
            {
                dateEx = DateTime.TryParse(endPeriod, out endDate);
                if (!dateEx)
                    throw new Exception("Конечная дата введена некорректно");
            }
            if (endPeriod != string.Empty && startDate > endDate)
                throw new Exception("Начальная дата больше конечной");

            DateTime fiveYearLimit = DateTime.Now.AddYears(-5);
            if (startDate < fiveYearLimit)
                throw new Exception("Можно получить данные только за последние пять лет");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, int> CurrencyId { get; set; }

        public List<string> CurrencyType { get; set; }
        public List<Rates> Rates
        {
            get
            {
                return _rates;
            }
            set
            {
                _rates = value;
                OnPropertyChanged("Rates");
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }

        public ViewModel(string url)
        {
            Header = "Курс валют по отношению к Белорусскому рублю";
            _types = new CurrencyTypes();
            CurrencyType = _types.Types;
            Rates = new List<Rates>();
            Currency = CurrencyType[0];
            _url = url;
        }

        public void SetServerAdress(string url)
        {
            _url = url;
        }

        public async void GetDataAsync(Button btn, string type, string startPeriod, string endPeriod = "")
        {
            await Task.Run(() =>GetData(type, startPeriod, endPeriod));
            btn.IsEnabled = true;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}