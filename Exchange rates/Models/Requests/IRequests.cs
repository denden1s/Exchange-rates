namespace Exchange_rates.Models.Requests
{
    // Need to creating proxy
    public interface IRequests
    {
        public Rates GetCurrentDateRate(int id);
        public List<Rates> GetRateOnConcretePeriod(int id, string startDate, string endDate = "");
    }
}