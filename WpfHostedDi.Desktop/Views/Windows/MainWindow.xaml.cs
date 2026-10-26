using System.Windows;
using WpfHostedDi.Desktop.ViewModels;

namespace WpfHostedDi.Desktop.Views.Windows;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}