using ControleFinanceiroApp.Repository;
using ControleFinanceiroApp.Views;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace ControleFinanceiroApp;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterDatabaseAndRepositories();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<LiteDatabase>(options =>
        {
            return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared");
        });

        builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

        builder.Services.AddTransient<TransactionAdd>();
        builder.Services.AddTransient<TransactionEdit>();

        builder.Services.AddTransient<TransactionList>();

        return builder;
    }

    public static MauiAppBuilder RegisterViews(MauiAppBuilder builder)
    {
        builder.Services.AddTransient<TransactionAdd>();
        builder.Services.AddTransient<TransactionEdit>();
        builder.Services.AddTransient<TransactionList>();
        return builder;
    }
}