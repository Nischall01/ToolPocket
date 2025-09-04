using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using ToolPocket.ViewModels;

namespace ToolPocket.Views;

public partial class AddToolDialog : Window
{
    private readonly ItemsControl? _itemsControl;
    private readonly ScrollViewer? _scrollViewer;

    public AddToolDialog()
    {
        InitializeComponent();
        DataContext = new AddToolDialogViewModel();

        // Find controls
        _scrollViewer = this.FindControl<ScrollViewer>("NewAppsScrollViewer");
        _itemsControl = this.FindControl<ItemsControl>("NewAppsList");

        // Initial margin setup
        UpdateItemMargins();

        // Subscribe to SizeChanged to update margin dynamically
        if (_scrollViewer != null)
            _scrollViewer.SizeChanged += (_, _) => UpdateItemMargins();

        // Also handle items changing
        if (_itemsControl is not null)
            _itemsControl.LayoutUpdated += (_, _) => UpdateItemMargins();
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);

        if (DataContext is AddToolDialogViewModel vm) vm.RequestClose = Close;
    }

    private void UpdateItemMargins()
    {
        if (_scrollViewer == null || _itemsControl == null)
            return;

        var scrollbarVisible = _scrollViewer.Extent.Height > _scrollViewer.Viewport.Height;

        for (var i = 0; i < _itemsControl.ItemCount; i++)
        {
            var container = _itemsControl.ContainerFromIndex(i);

            // Traverse the visual tree to find the Border in the DataTemplate
            var border = container?.GetVisualDescendants().OfType<Border>().FirstOrDefault();
            if (border != null)
                border.Margin = scrollbarVisible
                    ? new Thickness(4, 4, 12, 4)
                    : new Thickness(4);
        }
    }
}