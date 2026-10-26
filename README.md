# WpfHostedDi

Шаблон WPF-приложения на .NET 10 с Generic Host и внедрением зависимостей.

## Структура

- `WpfHostedDi.Services` — сервисы приложения; ThemeService и его WPF-палитры.
- `WpfHostedDi.Desktop` — точка входа, DI, окна, ViewModel и общие стили.
- `WpfHostedDi.Tests` — проект xUnit для интеграционного тестирования

`Program` запускает хост, выполняет WPF message loop и останавливает хост при выходе.
Регистрации находятся в `Bootstrap/DesktopHost.cs`. Главное окно, его ViewModel
и сервис тем имеют время жизни singleton. Для будущих scoped-сервисов нужно
создавать отдельный scope на операцию или окно.

## Управление темами

Внедри `ThemeService` через конструктор и вызови в UI-потоке:

```csharp
themeService.ApplyTheme(AppTheme.Light);
```

`CurrentTheme` возвращает выбранную тему. Каждый вызов `ApplyTheme` загружает её палитру.
При запуске применяется тёмная тема. Выбор хранится в памяти до закрытия приложения.

`ThemeService` заменяет только собственный словарь палитры, сохраняя общие стили.
Используй `DynamicResource` для цветов и кистей, которые должны меняться сразу.
Для окон явно подключай общий стиль: `Style="{StaticResource {x:Type Window}}"`.
Чтобы добавить тему, расширь `AppTheme`, добавь словарь с теми же ключами в
`WpfHostedDi.Services/Resources/Themes` с именем `{ИмяТемы}Colors.xaml`.

## ViewModel

Все ViewModel используют `CommunityToolkit.Mvvm`: наследуются от `ObservableObject`
и объявляются как `partial`, чтобы поддерживать генераторы `[ObservableProperty]`
и `[RelayCommand]`. Ручная реализация `INotifyPropertyChanged` не требуется.

`MainWindowViewModel` — пустая заготовка для логики главного окна.
Выбор темы в ней и в главном окне отсутствует; тема применяется через `ThemeService`.
