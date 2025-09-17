using MauiClientes.Models;
using MauiClientes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiClientes.ViewModels
{
    public partial class AddEditViewModel
    {
        private readonly ICustomerRepository _repository;
        private readonly Customer _originalCustomer;
        public Customer customer { get; set; }

        // Comandos
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddEditViewModel(ICustomerRepository repository, Customer existing = null)
        {
            _repository = repository;
            if (existing != null)
            {
                _originalCustomer = existing;
                customer = new Customer
                {
                    Id = existing.Id,
                    Name = existing.Name,
                    Lastname = existing.Lastname,
                    Age = existing.Age,
                    Address = existing.Address
                };
            }
            else
                customer = new Customer();


            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        private async Task Save()
        {
            if (!await FieldValidation())
                return;

            if (_originalCustomer != null)
            {
                _originalCustomer.Name = customer.Name;
                _originalCustomer.Lastname = customer.Lastname;
                _originalCustomer.Age = customer.Age;
                _originalCustomer.Address = customer.Address;

                _repository.Update(_originalCustomer);
            }
            else
            {
                customer.Id = Guid.NewGuid();
                _repository.Add(customer);
            }

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task Cancel()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task<bool> FieldValidation()
        {
            bool validation = true;

            if (customer.Name == string.Empty)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Informe um nome.", "OK");
                validation = false;
            }
            if (customer.Lastname == string.Empty)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Informe um sobrenome.", "OK");
                validation = false;
            }
            if (customer.Age <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Informe uma idade válida (apenas números).", "OK");
                validation = false;
            }
            if (customer.Address == string.Empty)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Informe um endereço.", "OK");
                validation = false;
            }

            return validation;
        }
    }
}
