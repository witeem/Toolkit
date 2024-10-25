using CommunityToolkit.Maui;
using MauiApp1.Pages;
using MauiApp1.ViewModel;
using MauiLib1.IService.Image;
using MauiLib1.Service.Image;
using UraniumUI;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddMaterialSymbolsFonts();
                });

            // See https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes
            // to understand the differences between [AddSingleton] and [AddTransient].

            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IImageService, ImageService>();


            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddSingleton<ImgFormat>();
            builder.Services.AddTransient<ImgFormatViewModel>();

            builder.Services.AddSingleton<CatsPage>();
            builder.Services.AddTransient<CatsViewModel>();

            builder.Services.AddCommunityToolkitDialogs();
            return builder.Build();
        }
    }
}
