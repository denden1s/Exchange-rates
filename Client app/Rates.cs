using System;
using System.ComponentModel;

namespace Exchange_rates.Models
{
    // Need to take data from json to objects
    public class Rates : INotifyPropertyChanged//Может изменить имя на Rates?
    {

        public string Currency { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public int Amount { get; set; }

        public Rates() { }

        public Rates(string currency, DateTime date, decimal value, int amount)
        {
            Currency = currency;
            Date = date;
            Value = value;
            Amount = amount;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}