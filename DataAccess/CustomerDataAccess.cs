using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDataAccess
    {

        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public CustomerDataAccess()
        {
            ReadCustomer();
        }

        private void ReadCustomer()
        {
            Customer cs1 = new Customer()
            {
                Id = 1,
                FirstName = "Ali",
                LastName= "Mahmoudi",
                Address = "tehran",
                PhoneNumber = 0990834
            };

            Customer cs2 = new Customer()
            {
                Id = 2,
                FirstName = "AmirAli",
                LastName = "Ahmadi",
                Address = "Hamedan",
                PhoneNumber = 0912504
            };
            Customers.Add(cs1);
            Customers.Add(cs2);
        }
        public void AddCustomer(Customer customers)
        {
            Customers.Add(customers);
        }

        public void RemoveCustomer(int id)
        {
            Customer temp = Customers.First(x => x.Id == id);
            Customers.Remove(temp);
        }


        public void EditCustomer(Customer customer)
        {
            Customer temp = Customers.First(x => x.Id == customer.Id);
            int index = Customers.IndexOf(temp);
            Customers[index] = customer;
        }

        public int GetNextId()
        {
            return Customers.Any() ? Customers.Max(x => x.Id) : 1;
        }
    }
}
