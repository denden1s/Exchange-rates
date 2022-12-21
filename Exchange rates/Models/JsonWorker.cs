using System.Text.Json;

namespace Exchange_rates.Models
{
    // Need to serialize data
    public static class JsonWorker
    {
        public static BankAPI ConvertFromJson(string json)
        {
            return JsonSerializer.Deserialize<BankAPI>(json);
        }
        public static List<BankAPI> ConvertFromJsonToList(string json)
        {
            return JsonSerializer.Deserialize<List<BankAPI>>(json);
        }
        public static string ConvertToJson(BankAPI convertedObject) 
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(convertedObject, options);
        }
        public static string ConvertToJson(List<BankAPI> convertedObject)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(convertedObject, options);
        }
    }
}