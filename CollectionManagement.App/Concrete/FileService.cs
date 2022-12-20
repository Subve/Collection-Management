using CollectionManagement.Domain.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.App.Concrete
{
    public class FileService
    {
        public const string PATH_WAY = @"C:\tmp\CollectionManager\data.txt";
        public void SaveList(List<Item> newList)
        {
            
            string output = JsonConvert.SerializeObject(newList);
            using StreamWriter sw = new StreamWriter(PATH_WAY);
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented
            };
            serializer.Serialize(writer, newList);
        }
        public List<Item> LoadList()
        {
            System.IO.FileInfo file = new System.IO.FileInfo(PATH_WAY);
            file.Directory.Create();
            if (file.Exists)
            {
                string listFromJson = File.ReadAllText(PATH_WAY);
                List<Item> loadedList = new List<Item>();
                using StreamReader sw = new StreamReader(PATH_WAY);
                using JsonReader reader = new JsonTextReader(sw);

                JsonSerializer serializer = new JsonSerializer()
                {
                    Formatting = Formatting.Indented
                };

                loadedList = serializer.Deserialize<List<Item>>(reader);
                //JsonConvert.DeserializeObject<List<Item>>(listFromJson);
                return loadedList;
            }
            else
                return new List<Item>();
        }
    }
}
