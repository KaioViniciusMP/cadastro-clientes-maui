using MauiClientes.Models;
using MauiClientes.Services;
using MauiClientes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MauiClientes.ViewModels
{
    public partial class MainViewModel 
    {
        private readonly ICustomerRepository _repository;
        public ObservableCollection<Customer> Customers { get; }

        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        public MainViewModel(ICustomerRepository repository)
        {
            _repository = repository;
            Customers = _repository.GetAll();

            DeleteCommand = new Command<Customer>(async (customer) => await Delete(customer));
            EditCommand = new Command<Customer>(async (customer) => await Edit(customer));

            if (!Customers.Any())
            {
                Customers.Add(new Customer
                {
                    Name = "Kaio",
                    Lastname = "Vinicius",
                    Age = 25,
                    Address = "Rua Exemplo, 123"
                });
            }
        }

        private async Task Edit(Customer customer)
        {
            if (customer == null)
                return;

            var vm = new AddEditViewModel(_repository, customer);
            var page = new AddEditPage(vm);
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        private async Task Delete(Customer customer)
        {
            if (customer == null) 
                return;

            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmação", $"Deseja excluir {customer.Name}?", "Sim", "Não");
            if (confirm)
            {
                _repository.Delete(customer.Id);
                Customers.Remove(customer); 
            }
        }
    }
}
