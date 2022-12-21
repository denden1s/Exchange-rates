namespace Exchange_rates.Models
{
    public class BankAPI
    {
        private int _id;
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
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

    }


}
