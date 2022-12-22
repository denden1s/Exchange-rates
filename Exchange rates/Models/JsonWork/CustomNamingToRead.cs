using System.Text.Json;

namespace Exchange_rates.Models.JsonWork
{
    // Need to take data from API in one format and return in other format
    public class CustomNamingToRead : JsonNamingPolicy
    {
        private readonly Dictionary<string, string> NameMapping = new Dictionary<string, string>()
        {
            [nameof(BankAPI.Currency)] = "Cur_Abbreviation",
            [nameof(BankAPI.Date)] = "Date",
            [nameof(BankAPI.Value)] = "Cur_OfficialRate",
            [nameof(BankAPI.Amount)] = "Cur_Scale"
        };

        public override string ConvertName(string name)
        {
            return NameMapping.GetValueOrDefault(name, name);
        }
    }
}
