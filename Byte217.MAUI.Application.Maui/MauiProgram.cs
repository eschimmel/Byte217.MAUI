using Byte217.MAUI.Application.Maui.Pages;
using Byte217.MAUI.Models.Factories;
using Byte217.MAUI.ViewModels;
using Byte217.MAUI.ViewModels.Factories;

namespace Byte217.MAUI.Application.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            IServiceCollection services = builder.Services;

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("segoeui.ttf", "SegoeUIRegular");
                });

            services.AddScoped<IKeyboardFactory, KeyboardFactory>();
            services.AddScoped<IKeyProcessorFactory, KeyProcessorFactory>();
            services.AddScoped<IPageLayoutFactory, PageLayoutFactory>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainPage>();
            services.AddScoped<SettingsPage>();
            services.AddScoped<TextPage>();

            return builder.Build();
        }
    }
}
