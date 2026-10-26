using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfHostedDi.Desktop.Views.Windows;

namespace WpfHostedDi.Desktop.Bootstrap;

public class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        
        Resources.MergedDictionaries.Add(CreateDictionary(
            "Resources/Themes/DarkColors.xaml"));
        Resources.MergedDictionaries.Add(CreateDictionary(
            "Resources/Styles/Controls.xaml"));
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }

    private static ResourceDictionary CreateDictionary(string source)
    {
        return new ResourceDictionary
        {
            Source = new Uri(source, UriKind.Relative)
        };
    }
}