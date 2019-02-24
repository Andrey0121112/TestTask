using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Client.model;

namespace TestTask.Client.item
{
    public class Mapping
    {
        public static PhoneModel PhoneToPhoneModel(Phone phone)
        {
            return new PhoneModel() { Id = phone.id, Name = phone.name, Data = phone.data };
        }

        public static Phone PhoneModelToPhone(PhoneModel phoneModel)
        {
            return new Phone(phoneModel.Id, phoneModel.Name, phoneModel.Data);
        }

    }
}
