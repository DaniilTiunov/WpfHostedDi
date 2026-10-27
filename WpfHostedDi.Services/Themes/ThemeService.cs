using System.Windows;

namespace WpfHostedDi.Services.Themes;

/// <summary>Применяет палитру к запущенному WPF-приложению. Вызывается в UI-потоке.</summary>
public sealed class ThemeService
{
    private ResourceDictionary? _themeDictionary;

    /// <summary>Текущая тема; при запуске используется тёмная палитра.</summary>
    public AppTheme CurrentTheme { get; private set; } = AppTheme.Light;

    /// <summary>Загружает словарь вида DarkColors.xaml, сохраняя остальные ресурсы.</summary>
    public void ApplyTheme(AppTheme theme)
    {
        var dictionary = new ResourceDictionary
        {
            Source = new Uri(
                $"pack://application:,,,/WpfHostedDi.Services;component/Resources/Themes/{theme}Colors.xaml")
        };
        var dictionaries = Application.Current.Resources.MergedDictionaries;

        if (_themeDictionary is not null)
            dictionaries.Remove(_themeDictionary);

        dictionaries.Insert(0, dictionary);
        _themeDictionary = dictionary;
        CurrentTheme = theme;
    }
}