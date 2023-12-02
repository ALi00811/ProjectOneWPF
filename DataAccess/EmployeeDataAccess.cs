using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public  class EmployeeDataAccess
    {

        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public EmployeeDataAccess()
        {
            ReadEmployees();
        }

        private void ReadEmployees()
        {
            Employee em1 = new Employee()
            {
                Id = 1,
                FirstName = "Abbas",
                LastName = "Alizadeh",
                PhoneNumber = 0912504,
                Address = "Tehran ,Heravi",
                Department = Department.production,
                BaseSalary = 2500
            };

            Employee em2 = new Employee()
            {
                Id = 2,
                FirstName = "Arshia",
                LastName = "Karimi",
                PhoneNumber = 0936566,
                Address = "tehran",
                Department = Department.management,
                BaseSalary = 3500
            };
            Employees.Add(em1);
            Employees.Add(em2);
        }
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void Removeemployee(int id)
        {
            Employee temp = Employees.First(x => x.Id == id);
            Employees.Remove(temp);
        }


        public void Editemployee(Employee employee)
        {
            Employee temp = Employees.First(x => x.Id == employee.Id);
            int index = Employees.IndexOf(temp);
            Employees[index] = employee;
        }

        public int GetNextId()
        {
            return Employees.Any() ? Employees.Max(x => x.Id) : 1;
        }
    }
}
