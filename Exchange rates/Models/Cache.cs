using System.Linq;
using Exchange_rates.Models.JsonWork;

namespace Exchange_rates.Models
{
    // Need to realize cache function
    public class Cache
    {
        private FileWorker _file;
        private List<Rates> _ratesToAdd;
        public List<Rates> Rates { get;private set; }

        public Cache(string filename)
        {
            _file = new FileWorker(filename);
            string fileContent = _file.GetContent();
            Rates = fileContent == string.Empty ? Rates = new List<Rates>() : JsonWorker.ConvertFromJsonToList(fileContent);
            _ratesToAdd = new List<Rates>();
        }

        public void TakeData(List<Rates> data)
        {
            if (Rates.Count > 0)
            {
                foreach (var rate in data)
                {
                    var currentRate = Rates.Where(r => r.Date == rate.Date
                    && r.Currency == rate.Currency).Count();
                    if (currentRate == 0)
                        _ratesToAdd.Add(rate);
                }
            }
            else
                _ratesToAdd = data;

            if(_ratesToAdd.Count > 0)
            {
                foreach (var rate in _ratesToAdd)
                    Rates.Add(rate);

                _file.WriteData(JsonWorker.ConvertToJson(Rates));
                _ratesToAdd.Clear();
            }
        }
    }
}