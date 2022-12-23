using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models
{
    // Need to take data from json to objects
    public class Rates : INotifyPropertyChanged//Может изменить имя на Rates?
    {
        private decimal _value;
        private DateTime _date;
        private string _dateFormat;

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date 
        { 
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                DateFormat = _date.ToString("d");
            }
        }
        public string DateFormat
        {
            get
            {
                return _dateFormat;
            }
            set
            {
                _dateFormat = value;
                OnPropertyChanged("DateFormat");
            }
        }

        [JsonPropertyName("value")]
        public decimal Value 
        { 
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        public Rates() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}