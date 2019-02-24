using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Server.LibServer
{
    public class Json
    {
        private static string nameDataBase = "Data.json";

        public static List<Phone> ReadJson(string path)
        {
            using (StreamReader r = new StreamReader(path + nameDataBase))
            {
                string json = r.ReadToEnd();
                List<Phone> items = JsonConvert.DeserializeObject<List<Phone>>(json);
                return items; 
            }
        }

        public static void SaveJson(List<Phone> listData, string path)
        {
            var json = JsonConvert.SerializeObject(listData.ToArray());
            File.WriteAllText(path + nameDataBase, json);
        }
    }
}
