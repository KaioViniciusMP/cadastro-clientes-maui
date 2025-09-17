using MauiClientes.ViewModels;

namespace MauiClientes.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnAddCustomerClicked(object sender, EventArgs e)
    {
        var addPage = MauiProgram.Services.GetService<AddEditPage>();
        await Navigation.PushModalAsync(addPage);
    }
}