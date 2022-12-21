using System.IO;

namespace Exchange_rates.Models
{
    // Need to take and put data in file
    public class FileWorker
    {
        private string _fileName;

        public FileWorker(string fileName)
        {
            _fileName = fileName;
            if(!File.Exists(_fileName))
            {
                FileInfo fileInf = new FileInfo(_fileName);
                fileInf.Create();
            }
        }

        public string GetContent()
        {
            using (StreamReader reader = new StreamReader(_fileName))
                return reader.ReadToEnd();
        }
        public void WriteData(string data)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true))
            {
                writer.Write(data);
            }
        }
    }
}