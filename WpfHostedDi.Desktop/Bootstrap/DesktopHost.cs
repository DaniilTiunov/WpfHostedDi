using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfHostedDi.Desktop.ViewModels;
using WpfHostedDi.Desktop.Views.Windows;
using WpfHostedDi.Services.Themes;

namespace WpfHostedDi.Desktop.Bootstrap;

/// <summary>Собирает Generic Host и регистрирует зависимости настольного приложения.</summary>
public static class DesktopHost
{
    /// <summary>Создаёт хост с конфигурацией, логированием и сервисами приложения.</summary>
    public static IHost Build(string[]? args = null)
    {
        return Host.CreateDefaultBuilder(args ?? [])
            .ConfigureServices(services =>
            {
                ConfigureApp(services);
                ConfigureServices(services);
                ConfigureViews(services);
                ConfigureViewModels(services);
            })
            .Build();
    }

    private static void ConfigureApp(IServiceCollection services)
    {
        services.AddSingleton<App>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ThemeService>();
    }

    private static void ConfigureViews(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
    }

    private static void ConfigureViewModels(IServiceCollection services)
    {
        // Главное окно живёт до завершения приложения, поэтому его ViewModel также singleton.
        services.AddSingleton<MainWindowViewModel>();
    }
}
