using Exchange_rates.Models.JsonWork;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models.Requests
{
    // Need for make request to NBRB API 
    public class Requests : IRequests
    {
        public Rates GetCurrentDateRate(int id)
        {
            try
            {
                Rates currentRate = new Rates();
                var _client = new RestClient($"https://www.nbrb.by/api/exrates/rates/{id}");
                var _request = new RestRequest("", Method.Get);
                RestResponse response = _client.Execute(_request);
                currentRate = JsonWorker.ConvertFromJson(response.Content);
                return currentRate;
            }
            catch (Exception)
            {
                return new Rates();
            }
        }

        public List<Rates> GetRateOnConcretePeriod(int id, string startDate, string endDate = "")
        {
            try
            {
                //еще проверку на валидность дат
                DateTime start = DateTime.Parse(startDate);
                DateTime end = endDate != string.Empty ? DateTime.Parse(endDate) : DateTime.Now;
                if (end < start) 
                    throw new Exception();
                List<Rates> data = new List<Rates>();
                for (DateTime counter = start; counter < end; counter = counter.AddDays(1))
                {
                    string request = $"https://www.nbrb.by/api/exrates/rates/{id}?ondate={counter.ToString("u")}&periodicity=0";
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