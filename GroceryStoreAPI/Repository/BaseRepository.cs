using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace GroceryStoreAPI.Repository
{
    public class BaseRepository
    {
        private string _fileName = "database.json";
        private JObject GetJToken(string fileName)
        {
            fileName = string.IsNullOrWhiteSpace(fileName) ? _fileName : fileName.Trim();
            return JObject.Parse(File.ReadAllText(Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}", fileName)));
        }

        internal T GetJObject<T>()
        {
            return GetJToken(string.Empty).ToObject<T>();
        }

        internal List<T> GetAllData<T>(string attribute)
        {
            return (GetJToken(string.Empty)[attribute])?.ToObject<List<T>>();
        }

        internal void WriteData<T>(T model)
        {
            var jsonString = JsonConvert.SerializeObject(model);
            File.WriteAllText(_fileName, jsonString);
        }

    }
}
