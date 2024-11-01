using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        void AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        Customer? GetCustomerById(int id);
        Customer? GetCustomerByEmail(string email);
    }
}