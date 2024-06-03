using FlashcardApp.Common;
using FlashcardApp.Components.Pages;
using FlashcardApp.Services;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Plugin.Maui.Audio;

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
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.VisibleStateDuration = 2000;
            });

            static IRepository<T> CreateRepo<T>(string folderName) where T : Entity =>
                new LocalStorageRepository<T>(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/FlashcardApp/" + folderName);

            builder.Services.AddSingleton(CreateRepo<Entities.ItemTemplate>("itemTemplates"));

            builder.Services.AddSingleton<ItemTemplateService>();
            builder.Services.AddSingleton<IAudioManager>(new AudioManager());
            builder.Services.AddSingleton<AudioService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
