using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace test_restsharp
{
    public class BankAPI
    {
        private int _id;

        [JsonPropertyName("Cur_Abbreviation")]
        public string Currency { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("Cur_OfficialRate")]
        public decimal Value { get; set; }

        [JsonPropertyName("Cur_Scale")]
        public int Amount { get; set; }

        public BankAPI()
        {

        }
        public BankAPI(int id)
        {
            _id = id;
        }

        public BankAPI(string currency, DateTime date, decimal value, int amount)
        {
            Currency = currency;
            Date = date;
            Value = value;
            Amount = amount;
        }
        public void View()
        {
            Console.WriteLine($"Currency: {Currency}, Date: {Date}, Value: {Value}");
        }

    }
}
