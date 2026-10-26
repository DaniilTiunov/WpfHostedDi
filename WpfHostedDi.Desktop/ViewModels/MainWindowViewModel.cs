using System.ComponentModel;
using WpfHostedDi.Services.Themes;

namespace WpfHostedDi.Desktop.ViewModels;

/// <summary>Предоставляет выбор темы главному окну и отслеживает изменения сервиса.</summary>
public sealed class MainWindowViewModel : INotifyPropertyChanged, IDisposable
{
    private readonly IThemeService _themeService;

    /// <summary>Подключает модель окна к общему сервису тем.</summary>
    public MainWindowViewModel(IThemeService themeService)
    {
        _themeService = themeService;
        _themeService.ThemeChanged += OnThemeChanged;
    }

    /// <summary>Темы, доступные для выбора в интерфейсе.</summary>
    public IReadOnlyList<AppTheme> AvailableThemes { get; } = Enum.GetValues<AppTheme>();

    /// <summary>Выбранная тема. Изменение сразу обновляет ресурсы приложения.</summary>
    public AppTheme SelectedTheme
    {
        get => _themeService.CurrentTheme;
        set => _themeService.ApplyTheme(value);
    }

    /// <summary>Уведомляет привязки WPF об изменении выбранной темы.</summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Снимает подписку при освобождении ViewModel контейнером DI.</summary>
    public void Dispose() => _themeService.ThemeChanged -= OnThemeChanged;

    private void OnThemeChanged(object? sender, ThemeChangedEventArgs e)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTheme)));
}
