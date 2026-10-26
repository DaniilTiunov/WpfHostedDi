using System.Windows;
using WpfHostedDi.Desktop.ViewModels;

namespace WpfHostedDi.Desktop.Views.Windows;

/// <summary>Главное окно приложения с моделью представления из контейнера DI.</summary>
public partial class MainWindow : Window
{
    /// <summary>Инициализирует окно и устанавливает модель для привязок данных.</summary>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}