using Avalonia.Controls;
using Avalonia.Interactivity;
using ToolPocket.Views;

namespace ToolPocket;

public partial class AddTool : UserControl
{
    public AddTool()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var atd = new AddToolDialog();
        atd.Show();
    }
}