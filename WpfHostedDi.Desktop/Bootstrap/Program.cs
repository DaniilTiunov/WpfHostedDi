using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfHostedDi.Desktop.Bootstrap;

/// <summary>Точка входа WPF-приложения с жизненным циклом Generic Host.</summary>
public static class Program
{
    /// <summary>Запускает хост и UI в STA-потоке, затем останавливает и освобождает хост.</summary>
    [STAThread]
    public static void Main(string[] args)
    {
        using var host = DesktopHost.Build(args);

        try
        {
            host.Start();
            host.Services.GetRequiredService<App>().Run();
        }
        finally
        {
            host.StopAsync().GetAwaiter().GetResult();
        }
    }
}