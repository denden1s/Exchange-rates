using Exchange_rates.Models.JsonWork;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models.Requests
{
    // Need for make request to NBRB API 
    public class Requests : IRequests
    {
        public List<Rates> GetRateOnConcretePeriod(string currencyType, string startDate, string endDate = "")
        {
            try
            {
                DateTime start = DateTime.Parse(startDate);
                DateTime end = endDate != string.Empty ? DateTime.Parse(endDate) : DateTime.Now;
                if (end < start) 
                    throw new Exception();
                List<Rates> data = new List<Rates>();
                for (DateTime counter = start; counter < end; counter = counter.AddDays(1))
                {
                    //https://www.nbrb.by/api/exrates/rates/RUB?ondate=2018-01-01&periodicity=0
                    string request = $"https://www.nbrb.by/api/exrates/rates/{currencyType}?ondate={counter.ToString("u")}&periodicity=0&parammode=2";
                    var _client = new RestClient(request);
                    var _request = new RestRequest("", Method.Get);
                    RestResponse response = _client.Execute(_request);
                    data.Add(JsonWorker.ConvertFromJson(response.Content));
                }
                return data;
            }
            catch (Exception)
            {
                return new List<Rates>();
            }
            
        }
    }
}