using System.Windows;
using WpfHostedDi.Services.Themes;

namespace WpfHostedDi.Desktop.Services;

/// <summary>Заменяет только словарь палитры, сохраняя остальные ресурсы приложения.</summary>
public sealed class WpfThemeApplier : IThemeApplier
{
    private ResourceDictionary? _themeDictionary;

    /// <summary>Применяет WPF-палитру в UI-потоке после создания Application.</summary>
    public void Apply(AppTheme theme)
    {
        var application = Application.Current
            ?? throw new InvalidOperationException("Перед применением темы необходимо создать Application.");
        application.Dispatcher.VerifyAccess();

        var fileName = theme switch
        {
            AppTheme.Dark => "DarkColors.xaml",
            AppTheme.Light => "LightColors.xaml",
            _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, "Неизвестная тема приложения.")
        };

        // Сначала загружаем новый словарь: ошибка загрузки не удалит текущую тему.
        var dictionary = new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/WpfHostedDi.Desktop;component/Resources/Themes/{fileName}")
        };
        var dictionaries = application.Resources.MergedDictionaries;
        var index = _themeDictionary is null ? -1 : dictionaries.IndexOf(_themeDictionary);

        if (index >= 0)
            dictionaries[index] = dictionary;
        else
            dictionaries.Insert(0, dictionary);

        _themeDictionary = dictionary;
    }
}
