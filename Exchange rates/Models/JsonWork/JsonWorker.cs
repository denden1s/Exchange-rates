using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Exchange_rates.Models.JsonWork
{
    // Need to serialize data
    public static class JsonWorker
    {
        public static Rates ConvertFromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CustomNamingToRead()
            };
            return JsonSerializer.Deserialize<Rates>(json,options);
        }


        public static List<Rates> ConvertFromJsonToList(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Deserialize<List<Rates>>(json, options);
        }
        public static string ConvertToJson(Rates convertedObject)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(convertedObject, options);
        }
        public static string ConvertToJson(List<Rates> convertedObject)
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