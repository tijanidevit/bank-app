using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Customer
    {
        int CustomerId;
        string name, email, phone;

        List<string[]> customers = new List<string[]>();

        public Customer() { }
        public Customer(string name, string email, string phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public int addCustomer(string name, string email, string phone)
        { 
            var CustomerId = 1;
            if (customers.Count != 0)
            {
                CustomerId = customers.Count() + 1;
            }

            string[] NewCustomer = {CustomerId.ToString(), name, email, phone };

            customers.Add(NewCustomer);
            return CustomerId;
        }

        public List<string[]> getCustomers()
        {
            return customers;
        }
        public string[] getCustomer(int CustomerId)
        {
            var all_customers = customers.ToArray();
            try
            {
                return all_customers[CustomerId - 1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void removeCustomer(int CustomerId)
        {
            customers.RemoveAt(CustomerId - 1);
            Console.WriteLine("Customer Deleted Successfully");
        }

    }
}
