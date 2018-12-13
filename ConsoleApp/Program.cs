using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        //1、利用HttpClient来调用以SelfHost方式寄宿的WebApi
        static void Main(string[] args)
        {
            Process();
            Console.ReadLine();
        }

        private async static void Process()
        {
            HttpClient httpclient = new HttpClient();

            //获取列表
            HttpResponseMessage response = await httpclient.GetAsync("http://localhost/selfhost/api/contacts");
            IEnumerable<Contact> contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            Console.WriteLine("当前联系人列表：");
            ListContacts(contacts);

            //添加联系人
            Contact contact = new Contact { Name = "额昂", PhoneNo = "12323", EmailAddress = "adfadsf" };
            await httpclient.PostAsJsonAsync<Contact>("http://localhost/selfhost/api/contacts", contact);
            Console.WriteLine("添加联系人：王五");
            response = await httpclient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //修改联系人
            response = await httpclient.GetAsync("http://localhost/selfhost/api/contacts/001");
            contact = (await response.Content.ReadAsAsync<IEnumerable<Contact>>()).First();
            contact.Name = "赵柳";
            contact.EmailAddress = "黄土高坡";
            await httpclient.PostAsJsonAsync("http://localhost/selfhost/api/contacts/001", contact);
            Console.WriteLine("修改联系人信息001");
            response = await httpclient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //删除联系人
            await httpclient.DeleteAsync("http://localhost/selfhost/api/contacts/002");
            Console.WriteLine("删除联系人");
            response = await httpclient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

        }

        private static void ListContacts(IEnumerable<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("{0},{1},{2},{3}", contact.Id, contact.Name, contact.PhoneNo, contact.EmailAddress, contact.Address);
            }
            Console.WriteLine();
        }
    }
}
