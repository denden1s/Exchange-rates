using System.Collections.Generic;

namespace Client_app.Models
{
    internal class CurrencyTypes
    {
        public List<string> Types { get; private set; }
        public CurrencyTypes() => Types = new List<string> { "USD", "EUR", "RUB" };
    }
}