using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EmployeeRepository
    {
        private static IList<Employee> employee;
        static EmployeeRepository()
        {
            employee = new List<Employee>();
            employee.Add(new Employee(Guid.NewGuid().ToString(), "a", "male", new DateTime(1981, 8, 5), "saleDep"));
            employee.Add(new Employee(Guid.NewGuid().ToString(), "b", "female", new DateTime(1982, 8, 5), "saleDep"));
            employee.Add(new Employee(Guid.NewGuid().ToString(), "c", "female", new DateTime(1983, 8, 5), "peoDep"));
            employee.Add(new Employee(Guid.NewGuid().ToString(), "d", "male", new DateTime(1984, 8, 5), "peoDep"));
        }

        public IEnumerable<Employee> GetEmployees(string id = "")
        {
            return employee.Where(e => e.Id == id || string.IsNullOrEmpty(id) || id == "*");
        }

    }
}
