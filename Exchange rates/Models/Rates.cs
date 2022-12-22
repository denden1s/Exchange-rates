using System.Text.Json.Serialization;

namespace Exchange_rates.Models
{
    // Need to take data from json to objects
    public class Rates 
    {
        public string Currency { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public int Amount { get; set; }

        public Rates(){ }

        public Rates(string currency, DateTime date, decimal value, int amount)
        {
            Currency = currency;
            Date = date;
            Value = value;
            Amount = amount;
        }
    }
}