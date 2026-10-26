namespace WpfHostedDi.Services.Themes;

/// <summary>Применяет палитру средствами конкретного пользовательского интерфейса.</summary>
public interface IThemeApplier
{
    /// <summary>Загружает ресурсы темы. При ошибке должен сохранить прежнюю палитру.</summary>
    void Apply(AppTheme theme);
}
