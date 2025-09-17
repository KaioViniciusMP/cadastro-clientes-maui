using MauiClientes.ViewModels;

namespace MauiClientes.Views;

public partial class AddEditPage : ContentPage
{
	public AddEditPage(AddEditViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}