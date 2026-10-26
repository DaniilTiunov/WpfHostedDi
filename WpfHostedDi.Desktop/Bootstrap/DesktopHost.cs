using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfHostedDi.Desktop.ViewModels;
using WpfHostedDi.Desktop.Views.Windows;

namespace WpfHostedDi.Desktop.Bootstrap;

public static class DesktopHost
{
    public static IHost Build()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                ConfigureApp(services);
                ConfigureViews(services);
                ConfigureViewModels(services);
            })
            .Build();
    }

    private static void ConfigureApp(IServiceCollection services)
    {
        services.AddSingleton<App>();
    }

    private static void ConfigureViews(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
    }

    private static void ConfigureViewModels(IServiceCollection services)
    {
        services.AddScoped<MainWindowViewModel>();
    }
}