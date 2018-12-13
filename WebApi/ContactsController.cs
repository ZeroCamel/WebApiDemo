using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    //apicontroller定义在system.web.http.dll
    public class ContactsController : ApiController
    {
        static List<Contact> contacts;
        static ContactsController()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact { Id = "001", Name = "abc", PhoneNo = "123456", EmailAddress = "123@qq.com", Address = "hehe" });
            contacts.Add(new Contact { Id = "002", Name = "cde", PhoneNo = "123123123", EmailAddress = "345@123", Address = "xixi" });
        }

        public IEnumerable<Contact> Get(string id = null)
        {
            return from contact in contacts where contact.Id == id || string.IsNullOrEmpty(id) select contact;
        }

        public void Post(Contact contact)
        {
            int cntId = contacts.Count + 1;
            contact.Id = cntId.ToString("D3");
            contacts.Add(contact);
        }
        public void Put(Contact contact)
        {
            contacts.Remove(contacts.First(a => a.Id == contact.Id));
            contacts.Add(contact);
        }
        public void Delete(string id)
        {
            contacts.Remove(contacts.First(a => a.Id == id));
        }

    }
}
