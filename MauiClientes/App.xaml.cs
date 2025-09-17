using MauiClientes.Views;

namespace MauiClientes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Resolve a MainPage via DI
            var mainPage = MauiProgram.Current.Services.GetService<MainPage>();
            return new Window(mainPage);
        }
    }
}