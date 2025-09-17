using MauiClientes.Services;
using MauiClientes.ViewModels;
using MauiClientes.Views;
using Microsoft.Extensions.Logging;

namespace MauiClientes
{
    public static class MauiProgram
    {
        public static MauiApp Current { get; private set; }
        public static IServiceProvider Services => Current.Services;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddEditViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddEditPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            Current = app;
            return app;
        }
    }
}
