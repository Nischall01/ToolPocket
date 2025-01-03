using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace ToolPocket;

public partial class Tool : UserControl
{
    private Options _currentOptionsControl;

    public Tool()
    {
        InitializeComponent();
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Control;
        var mainWindow = this.GetVisualRoot() as Window;

        if (button != null && mainWindow != null)
        {
            var overlayLayer = mainWindow.FindControl<Canvas>("OverlayLayer");
            if (overlayLayer == null)
                return;

            var buttonPosition = button.TranslatePoint(new Point(0, 0), mainWindow);
            if (buttonPosition.HasValue)
            {
                // Calculate the position for the new control
                var controlX = buttonPosition.Value.X;
                var controlY = buttonPosition.Value.Y + button.Bounds.Height;

                if (_currentOptionsControl == null)
                {
                    _currentOptionsControl = new Options();
                    Canvas.SetLeft(_currentOptionsControl, controlX);
                    Canvas.SetTop(_currentOptionsControl, controlY);
                    overlayLayer.Children.Add(_currentOptionsControl);
                }
                else
                {
                    overlayLayer.Children.Remove(_currentOptionsControl);
                    _currentOptionsControl = null;
                }
            }
        }
    }
}