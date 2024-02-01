using Newtonsoft.Json;
using System.IO;

namespace WareHouse.Helper
{
    public static class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(text);
        }

        public static void Write<T>(string filePath, T item)
        {
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText(filePath, json);
        }
    }
}
