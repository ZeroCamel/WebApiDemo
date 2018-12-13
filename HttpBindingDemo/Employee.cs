using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpBindingDemo
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public Employee(string Id,string Name,string PhoneNo,string EmailAddress)
        {
            this.Id = Id;
            this.Name = Name;
            this.PhoneNo = PhoneNo;
            this.EmailAddress = EmailAddress;
        }
    }
}
