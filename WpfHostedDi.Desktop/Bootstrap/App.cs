using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfHostedDi.Desktop.Views.Windows;
using WpfHostedDi.Services.Themes;

namespace WpfHostedDi.Desktop.Bootstrap;

/// <summary>Инициализирует ресурсы WPF и открывает главное окно через DI.</summary>
public class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>Создаёт приложение с контейнером зависимостей хоста.</summary>
    public App(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        Resources.MergedDictionaries.Add(new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/WpfHostedDi.Desktop;component/Resources/Styles/Style.xaml")
        });
        ShutdownMode = ShutdownMode.OnMainWindowClose;
    }

    /// <summary>Применяет начальную тему до создания и показа главного окна.</summary>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var themeService = _serviceProvider.GetRequiredService<ThemeService>();
        themeService.ApplyTheme(themeService.CurrentTheme);
        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }
}