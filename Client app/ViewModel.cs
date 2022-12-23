using Exchange_rates.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace Client_app
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _currency;
        private string header;
        private string _url;
        private List<Rates> _rates;

        //расчистить этот слой от ненужных вещей

        //назвать получше
        private void Validation(string startPeriod, string endPeriod = "")
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            bool dateEx = DateTime.TryParse(startPeriod, out startDate);
            if (!dateEx)
                throw (new Exception("Начальная дата введена некорректно"));
            if (endPeriod != string.Empty)
            {
                dateEx = DateTime.TryParse(endPeriod, out endDate);
                if (!dateEx)
                    throw (new Exception("Конечная дата введена некорректно"));
            }
            //перенести в отдельный метод
            if (endPeriod!= string.Empty && startDate > endDate)
                throw (new Exception("Начальная дата больше конечной"));

            DateTime fiveYearLimit = DateTime.Now.AddYears(-5);
            if (startDate < fiveYearLimit)
                throw (new Exception("Можно получить данные только за последние пять лет"));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> CurrencyType { get; set; }
        public Dictionary<string, int> CurrencyId { get; set; }
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
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }
        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }



        public ViewModel()
        {
            Header = "Chart";
            CurrencyType = new List<string> { "USD", "EUR", "RUB" };
            CurrencyId = new Dictionary<string, int>
            {
                {"USD", 431},
                {"EUR", 451},
                {"RUB", 456}
            };
            Rates = new List<Rates>();
            Currency = "USD";
            _url = "https://localhost:7190";
            Rates.Add(new Rates("usd", DateTime.Now, 24, 2));
        }

        public void GetData(string type, string startPeriod, string endPeriod = "")
        {
            try
            {
                Header = "Ожидайте выполнения запроса";
                Validation(startPeriod, endPeriod);


                string period = endPeriod == string.Empty ? "floating" : "concrete";
                string end = endPeriod == string.Empty ? "" : $"&{endPeriod}";

                //https://localhost:7190/api/ExchangeRates/floating/431&12.12.2022
                string url = $"{_url}/api/ExchangeRates/{period}/{CurrencyId[type]}&{startPeriod}{end}";
                var _client = new RestClient(url);
                var _request = new RestRequest("", Method.Get);
                RestResponse response = _client.Execute(_request);
                if (response.Content == null)
                    throw new Exception("Невозможно подключиться к серверу");
                Rates = JsonSerializer.Deserialize<List<Rates>>(response.Content);
                Header = $"Курс {type} к Белорусскому рублю на период {startPeriod} - {endPeriod}";
            }
            catch (Exception ex)
            {
                Header = ex.Message;
            }
        }
        public void GetDataAsync(string type, string startPeriod, string endPeriod = "")
        {
            Task.Run(() => GetData(type, startPeriod, endPeriod));
        }


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}