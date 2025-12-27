namespace Exchange_rates.Models.Requests
{
    // Need to choose place for loading data
    public class RequestProxy : IRequests
    {
        private List<Rates> _dataInCache;
        private Requests _requests;
        public RequestProxy(List<Rates> data)
        {
            _dataInCache = data;
            _requests = new Requests();
        }

        public List<Rates> GetRateOnConcretePeriod(string currencyType, string startDate, string endDate = "")
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = endDate != string.Empty ? DateTime.Parse(endDate) : DateTime.Now;
            List<Rates> period = new List<Rates>();
            if (end < start)
                return period;

            double dayDifference = (end - start).TotalDays;
            period = _dataInCache.Where(
                r => r.Date >= start && r.Date < end && r.Currency == currencyType
                ).ToList();
            if (Math.Ceiling(dayDifference) == period.Count())
                return period;
            else
                return _requests.GetRateOnConcretePeriod(currencyType, startDate, endDate);
        }
    }
}