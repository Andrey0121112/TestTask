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
        public static List<Phone> ReadJson(string path)
        {
            using (StreamReader r = new StreamReader(path + "Data.json"))
            {
                string json = r.ReadToEnd();
                List<Phone> items = JsonConvert.DeserializeObject<List<Phone>>(json);

                if (items.Count != 0)
                    return items;
                else
                    return null;
            }
        }

        public static void SaveJson(List<Phone> listData, string path)
        {
            var json = JsonConvert.SerializeObject(listData.ToArray());
            File.WriteAllText(path + "Data.json", json);
        }
    }
}
