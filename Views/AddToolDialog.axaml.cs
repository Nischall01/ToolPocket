using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ToolPocket.Views;

public partial class AddToolDialog : Window
{
    public AddToolDialog()
    {
        InitializeComponent();
    }

    [Obsolete("Obsolete")]
    private async void DirectoryButton_OnClick(object? sender, RoutedEventArgs e)
    {
        string? filePath = await FilePickerHelper.ShowFilePicker(this, AppPath.Text);
        AppPath.Text = filePath;
        if (filePath != null) AppName.Text = GetAppNameFromPath(filePath);
    }

    private void AddToolCancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private void AddToolConfirmButton_OnClick(object? sender, RoutedEventArgs e)
    {
        AddNewTool();
    }

    private void AddNewTool()
    {
        Console.WriteLine();
        Console.WriteLine($"App path: {AppPath.Text}");
        Console.WriteLine($"App Name: {AppName.Text}");
        Console.WriteLine($"Run On StartUp: {RunOnStartUpToggle.IsChecked}");
        Console.WriteLine($"Add to Start Menu: {AddToStartMenuToggle.IsChecked}");
        Console.WriteLine($"Add to Programs: {AddToProgramsToggle.IsChecked}");
    }

    private string GetAppNameFromPath(string filePath)
    {
        string fileName = Path.GetFileName(filePath);

        const char dotSeparator = '.';

        int dotSeparatorIndex = fileName.IndexOf(dotSeparator);

        if (dotSeparatorIndex != -1) fileName = fileName.Substring(0, dotSeparatorIndex);

        return fileName;
    }
}