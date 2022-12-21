namespace Exchange_rates.Models
{
    // Need to take data from json to objects
    public class BankAPI //Может изменить имя на Rates?
    {
        private int _id;//нужно ли 
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int Amount { get; set; }

        public BankAPI(){ }
        public BankAPI(int id) => _id = id;// нужно ли?

        public BankAPI(string currency, DateTime date, decimal value, int amount)
        {
            Currency = currency;
            Date = date;
            Value = value;
            Amount = amount;
        }
    }
}