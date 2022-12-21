using System.Linq;
namespace Exchange_rates.Models
{
    // Need to realize cache function
    public class Cache
    {
        private FileWorker _file;
        private List<BankAPI> _ratesToAdd;
        public List<BankAPI> Rates { get;private set; }

        public Cache(string filename)
        {
            _file = new FileWorker(filename);
            string fileContent = _file.GetContent();
            if (fileContent == string.Empty)
                Rates = new List<BankAPI>();
            else
                Rates = JsonWorker.ConvertFromJsonToList(fileContent);

            _ratesToAdd = new List<BankAPI>();
        }

        public void TakeData(List<BankAPI> data)
        {
            if (Rates.Count > 0)
                _ratesToAdd = (List<BankAPI>)data.Except(Rates);
            else
                _ratesToAdd = data;

            _file.WriteData(JsonWorker.ConvertToJson(_ratesToAdd));
            foreach (var rate in _ratesToAdd)
                Rates.Add(rate);

            _ratesToAdd.Clear();
        }
    }
}