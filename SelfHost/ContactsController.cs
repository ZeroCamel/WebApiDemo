using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HttpBindingDemo
{
    public class ContactsController : ApiController
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact {Id="001",Name="hahaha",Phoneto="1234",EmailAddress="123@qq.com" },
            new Contact {Id="002",Name="tiantian",Phoneto="56789",EmailAddress="tiantian@qq.com" }
        };

        public IEnumerable<Contact> Get()
        {
            return contacts;
        }
        public Contact Get(string id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

    }

    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phoneto { get; set; }
        public string EmailAddress { get; set; }
    }
}
