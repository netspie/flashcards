using FlashcardApp.Common;
using FlashcardApp.Components.Pages;
using FlashcardApp.Services;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

namespace FlashcardApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
                config.SnackbarConfiguration.VisibleStateDuration = 2000;
            });

            static IRepository<T> CreateRepo<T>(string folderName) where T : Entity =>
                new LocalStorageRepository<T>(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + folderName);

            builder.Services.AddSingleton(CreateRepo<Entities.ItemTemplate>("itemTemplates"));

            builder.Services.AddSingleton<ItemTemplateService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
