namespace Exchange_rates.Models.Requests
{
    // Need to creating proxy
    public interface IRequests
    {
        public BankAPI GetCurrentDateRate(int id);
        public List<BankAPI> GetRateOnConcretePeriod(int id, string startDate, string endDate = "");
    }
}