using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace TestTask.Server.LibServer
{
    public class ProcesDataApi
    {
        private static string folder = "Data\\";

        private static string pathToFolder()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) , folder);
        }

        public static Phone GET_DataObject(int id)
        {
            List<Phone> list = Json.ReadJson(pathToFolder());
            return list.FirstOrDefault(x => x.id == id);;
        }

        public static List<Phone> GET_DataObjects()
        {
            List<Phone> list = Json.ReadJson(pathToFolder());
            return list;
        }
        
        public static void POST_DataObject(Phone data)
        {
            List<Phone> list = Json.ReadJson(pathToFolder());
            if (list.Count == 0)
            {
                data.id = 1;
            }
            else
            {
                data.id = list.Max(x => x.id) + 1;
            }
            list.Add(data);
            Json.SaveJson(list, pathToFolder());
        }

        public static void PUT_DataObject(int id, Phone data)
        {
            List<Phone> list = Json.ReadJson(pathToFolder());
            int index = list.FindIndex(x => x.id == id);
            list[index] = data;
            Json.SaveJson(list, pathToFolder());
        }

        public static void DELETE_DataObject(int id)
        {
            List<Phone> list = Json.ReadJson(pathToFolder());
            list.Remove(list.FirstOrDefault(x => x.id == id));
            Json.SaveJson(list, pathToFolder());

        }
    }
}
