using Avalonia.Controls;
using ToolPocket.ViewModels;

namespace ToolPocket.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewViewModel();
    }
}