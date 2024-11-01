using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        private HotelminiDBContext _context;

        public CustomerDAO()
        {
            _context = new();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void DeleteCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.CustomerID);
            if (existingCustomer != null)
            {
                _context.Customers.Remove(existingCustomer);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Customer not found.");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public Customer? GetCustomerById(int id)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            return customer;
        }
        public Customer? GetCustomerByEmail(string email)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.EmailAddress == email);
            return customer;
        }
    }
}
