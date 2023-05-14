using Microsoft.Extensions.Logging;
using Quiz.ViewModels;
using Quiz.Models;

namespace Quiz;

public static class MauiProgram
{
    private static string persistentDbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "QuizDatabase.db"
    );

    private static string dbPath = persistentDbPath;

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

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<PlayPage>();
        builder.Services.AddTransient<PlayViewModel>();

        builder.Services.AddTransient<CreatePage>();
        builder.Services.AddTransient<CreateViewModel>();

        builder.Services.AddSingleton<Db>(s => ActivatorUtilities.CreateInstance<Db>(s, dbPath));
        builder.Services.AddSingleton<Store>(s => ActivatorUtilities.CreateInstance<Store>(s));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
