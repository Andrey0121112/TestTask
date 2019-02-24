using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Client.item;
using TestTask.Client.model;

namespace TestTask.Client
{
    public class ServerAPI
    {
        public string API = "https://localhost:44328";
        public string token = "/api//values";
        public string folder = "images";

        public ObservableCollection<PhoneModel> ListItem { get; set; }
        public Delegate selectItem;
    }
}
