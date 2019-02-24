using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Client.model
{
    public class PhoneModel : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private String data;


        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return id; }
            set
            {
                if (value == null)
                    id = 0;

                id = value;
                OnPropertyChanged("Id");
            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                if (value == null)
                    name = "";

                name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

    }
}
