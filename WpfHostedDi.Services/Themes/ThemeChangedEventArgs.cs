namespace WpfHostedDi.Services.Themes;

/// <summary>Содержит тему, успешно применённую к приложению.</summary>
public sealed class ThemeChangedEventArgs(AppTheme theme) : EventArgs
{
    /// <summary>Новая тема приложения.</summary>
    public AppTheme Theme { get; } = theme;
}
