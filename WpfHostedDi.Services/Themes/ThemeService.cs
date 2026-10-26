namespace WpfHostedDi.Services.Themes;

/// <summary>Хранит текущую тему и сообщает об изменениях после применения палитры.</summary>
public sealed class ThemeService : IThemeService
{
    private readonly IThemeApplier _themeApplier;
    private bool _isApplied;

    /// <summary>Создаёт сервис с реализацией применения ресурсов интерфейса.</summary>
    public ThemeService(IThemeApplier themeApplier)
    {
        ArgumentNullException.ThrowIfNull(themeApplier);
        _themeApplier = themeApplier;
    }

    /// <inheritdoc />
    public AppTheme CurrentTheme { get; private set; } = AppTheme.Dark;

    /// <inheritdoc />
    public event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

    /// <inheritdoc />
    public void ApplyTheme(AppTheme theme)
    {
        if (!Enum.IsDefined(theme))
            throw new ArgumentOutOfRangeException(nameof(theme), theme, "Неизвестная тема приложения.");

        if (_isApplied && CurrentTheme == theme)
            return;

        // Состояние меняется только после успешной загрузки ресурсов.
        _themeApplier.Apply(theme);
        var changed = CurrentTheme != theme;
        CurrentTheme = theme;
        _isApplied = true;

        if (changed)
            ThemeChanged?.Invoke(this, new ThemeChangedEventArgs(theme));
    }
}
