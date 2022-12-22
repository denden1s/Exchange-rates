using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models.JsonWork
{
    // Need to serialize data
    public static class JsonWorker
    {
        public static BankAPI ConvertFromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CustomNamingToRead()
            };
            return JsonSerializer.Deserialize<BankAPI>(json,options);
        }


        public static List<BankAPI> ConvertFromJsonToList(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Deserialize<List<BankAPI>>(json, options);
        }
        public static string ConvertToJson(BankAPI convertedObject)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(convertedObject, options);
        }
        public static string ConvertToJson(List<BankAPI> convertedObject)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(convertedObject, options);
        }
    }
}