using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Server.LibServer
{
    public class Phone
    {
        public int id { get; set; }
        public string name { get; set; }
        public string data { get; set; }

        public Phone() { }

        public Phone(int id, string name, string data)
        {
            this.id = id;
            this.name = name;
            this.data = data;
        }
    }
}
