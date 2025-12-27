using System.Linq;
using Exchange_rates.Models.JsonWork;

namespace Exchange_rates.Models
{
    // Need to realize cache function
    public class Cache
    {
        private FileWorker _file;
        public List<Rates> Rates { get;private set; }

        public Cache(string filename)
        {
            _file = new FileWorker(filename);
            string fileContent = _file.GetContent();
            Rates = fileContent == string.Empty ? Rates = new List<Rates>() : JsonWorker.ConvertFromJsonToList(fileContent);
        }

        public void TakeData(List<Rates> data)
        {
            if(data.Count > 0)
            {
                foreach (var rate in data)
                    if (!Rates.Contains(rate))
                        Rates.Add(rate);

                _file.WriteData(JsonWorker.ConvertToJson(Rates));
            }
        }
    }
}