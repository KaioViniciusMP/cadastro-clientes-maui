using MauiClientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiClientes.Services
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly ObservableCollection<Customer> _customers = new();

        public ObservableCollection<Customer> GetAll() => _customers;

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing != null)
            {
                existing.Name = customer.Name;
                existing.Lastname = customer.Lastname;
                existing.Age = customer.Age;
                existing.Address = customer.Address;
            }
        }
        public void Delete(Guid id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
                _customers.Remove(customer);
        }
    }
}
