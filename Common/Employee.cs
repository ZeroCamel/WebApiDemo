using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Employee
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string DepartMent { get; private set; }

        public Employee(string id,string name,string gender,DateTime birthdate,string deparment)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.DepartMent = deparment;
        }
    }
}
