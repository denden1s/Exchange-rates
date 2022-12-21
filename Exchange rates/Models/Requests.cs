using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models
{
    public static class Requests
    {

        private static List<BankAPI> GetRateFromTo(int id, DateTime start, DateTime end)
        {
            List<BankAPI> data = new List<BankAPI>();
            for (DateTime counter = start; counter < end; counter = counter.AddDays(1))
            {
                var _client = new RestClient($"https://www.nbrb.by/api/exrates/rates/451?ondate={counter.ToString("u")}&periodicity=0");
                var _request = new RestRequest("", Method.Get);
                RestResponse response = _client.Execute(_request);
                data.Add(JsonSerializer.Deserialize<BankAPI>(response.Content));
            }
            return data;
        }
        public static BankAPI GetCurrentDateRate(int id)
        {
            BankAPI currentRate = new BankAPI();
            var _client = new RestClient($"https://www.nbrb.by/api/exrates/rates/{id}");
            var _request = new RestRequest("", Method.Get);
            RestResponse response = _client.Execute(_request);
            Console.WriteLine(response.Content);
            currentRate = JsonSerializer.Deserialize<BankAPI>(response.Content);
            return currentRate;
        }
        public static List<BankAPI> GetRateOnConcretePeriod(int id, string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate); 
            return GetRateFromTo(id, start, end);
        }

        public static List<BankAPI> GetRateOnConcretePeriod(int id, string startDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Now;
            return GetRateFromTo(id, start, end);
        }
    }
}
