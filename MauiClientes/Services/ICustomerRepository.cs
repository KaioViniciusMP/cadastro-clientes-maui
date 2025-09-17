using MauiClientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiClientes.Services
{
    public interface ICustomerRepository
    {
        ObservableCollection<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
    }
}
