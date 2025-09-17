using System;
using System.ComponentModel;

namespace MauiClientes.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Guid id = Guid.NewGuid();
        private string name = string.Empty;
        private string lastname = string.Empty;
        private int age;
        private string address = string.Empty;

        public Guid Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Lastname
        {
            get => lastname;
            set { lastname = value; OnPropertyChanged(nameof(Lastname)); }
        }

        public int Age
        {
            get => age;
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Address
        {
            get => address;
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
