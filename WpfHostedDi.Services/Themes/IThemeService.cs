namespace WpfHostedDi.Services.Themes;

/// <summary>Управляет темой приложения. Вызывается из потока пользовательского интерфейса.</summary>
public interface IThemeService
{
    /// <summary>Текущая тема; до первого применения используется тёмная.</summary>
    AppTheme CurrentTheme { get; }

    /// <summary>Возникает после успешного изменения текущей темы.</summary>
    event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

    /// <summary>Применяет тему; повторный выбор уже применённой темы ничего не делает.</summary>
    void ApplyTheme(AppTheme theme);
}
