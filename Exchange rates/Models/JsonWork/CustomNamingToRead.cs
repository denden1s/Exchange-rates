using System.Text.Json;

namespace Exchange_rates.Models.JsonWork
{
    // Need to take data from API in one format and return in other format
    public class CustomNamingToRead : JsonNamingPolicy
    {
        private readonly Dictionary<string, string> NameMapping = new Dictionary<string, string>()
        {
            [nameof(Rates.Currency)] = "Cur_Abbreviation",
            [nameof(Rates.Date)] = "Date",
            [nameof(Rates.Value)] = "Cur_OfficialRate",
            [nameof(Rates.Amount)] = "Cur_Scale"
        };

        public override string ConvertName(string name)
        {
            return NameMapping.GetValueOrDefault(name, name);
        }
    }
}
