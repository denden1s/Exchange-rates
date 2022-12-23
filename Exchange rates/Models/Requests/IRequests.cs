namespace Exchange_rates.Models.Requests
{
    // Need to creating proxy
    public interface IRequests
    {
        public List<Rates> GetRateOnConcretePeriod(string currencyType, string startDate, string endDate = "");
    }
}