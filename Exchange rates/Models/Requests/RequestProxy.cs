using System.Linq;
namespace Exchange_rates.Models.Requests
{
    // Need to choose place for loading data
    public class RequestProxy : IRequests
    {
        private List<BankAPI> _dataInCache;
        private Requests _requests;

        // Need to convert ID from int to string
        private Dictionary<int, string> _currency;
        public RequestProxy(List<BankAPI> data)
        {
            _dataInCache = data;
            _requests = new Requests();
            _currency = new Dictionary<int, string>()
            {
                { 431, "USD"},
                { 451, "EUR"},
                { 456, "RUB"}
            };
        }

        public BankAPI GetCurrentDateRate(int id)
        {
            try
            {
                DateTime currentDay = DateTime.Now;
                bool contain = _dataInCache.Where(r => r.Date == currentDay && r.Currency == _currency[id]).Count() != 0;
                if (contain)
                    return _dataInCache.Where(
                        r => r.Date == currentDay && r.Currency == _currency[id]
                        ).FirstOrDefault();
                else
                    return _requests.GetCurrentDateRate(id);
            }
            catch (Exception)
            {
                return new BankAPI();
            }
            
        }

        public List<BankAPI> GetRateOnConcretePeriod(int id, string startDate, string endDate = "")
        {
            try
            {
                DateTime start = DateTime.Parse(startDate);
                DateTime end = endDate != string.Empty ? DateTime.Parse(endDate) : DateTime.Now;
                if (end < start)
                    throw new Exception();
                double dayDifference = (end - start).TotalDays;
                List<BankAPI> period = _dataInCache.Where(
                    r => r.Date >= start && r.Date < end && r.Currency == _currency[id]
                    ).ToList();
                if (Math.Ceiling(dayDifference) == period.Count())
                    return period;
                else
                    return _requests.GetRateOnConcretePeriod(id, startDate, endDate);
            }
            catch (Exception)
            {
                return new List<BankAPI>();
            }
           
        }
    }
}