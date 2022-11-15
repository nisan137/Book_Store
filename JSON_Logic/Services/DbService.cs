using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace JSON_Logic.Services
{
    public class DbService
    {
        private StorageFolder _folder;
        private string _path;

        public DbService(string dbName)
        {
            _folder = ApplicationData.Current.LocalFolder;
            _path = Path.Combine(_folder.Path, dbName);

            if (!File.Exists(_path))
            {
                using (FileStream file = new FileStream(_path, FileMode.Create))
                {
                    file.Close();
                }
            }
        }
        public void SaveData(object data)
        {
            string UpdatedList = ObjectToJson(data);
            WriteFile(UpdatedList);
        }

        private string ObjectToJson(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        private void WriteFile(string data)
        {
            using (StreamWriter writer = new StreamWriter(_path))
            {
                writer.Write(data);
                writer.Close();
            }
        }

        public List<T> GetData<T>()
        {
            try
            {
                string strConvert = File.ReadAllText(_path);
                List<T> data = JsonConvert.DeserializeObject<List<T>>(strConvert, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                });
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}