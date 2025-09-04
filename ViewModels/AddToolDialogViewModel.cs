using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToolPocket.Models;

namespace ToolPocket.ViewModels;

public partial class AddToolDialogViewModel : ObservableObject
{
    [ObservableProperty] private bool _addToPrograms;
    [ObservableProperty] private bool _addToStart;
    [ObservableProperty] private string _appName;
    [ObservableProperty] private string _appPath;
    [ObservableProperty] private bool _runOnStartUp;

    public AddToolDialogViewModel()
    {
        AppName = string.Empty;
        AppPath = string.Empty;

        // Sample data
        NewApps.Add(
            new Tool(RemoveApp, true, true, "ToolPocket", "Path", true));
        NewApps.Add(
            new Tool(RemoveApp, true, false, "Everything", "Path", true));
        NewApps.Add(
            new Tool(RemoveApp, true, false, "Rider", "Path", false));
    }

    public ObservableCollection<Tool> NewApps { get; } = [];

    public Action<ObservableCollection<Tool>?>? RequestClose { get; set; }

    [RelayCommand]
    public void Confirm()
    {
        RequestClose?.Invoke(NewApps);
    }

    [RelayCommand]
    public void Cancel()
    {
        RequestClose?.Invoke(null);
    }

    [RelayCommand]
    public void AddNewApp()
    {
        var newApp = new Tool(RemoveApp, AddToPrograms, AddToStart, AppName, AppPath, RunOnStartUp);
        Console.WriteLine($"{AppPath}");
        Console.WriteLine($"{AppName}");
        Console.WriteLine($"{RunOnStartUp}");
        Console.WriteLine($"{AddToPrograms}");
        Console.WriteLine($"{AddToStart}");
        NewApps.Add(newApp);
    }

    private void RemoveApp(Tool tool)
    {
        NewApps.Remove(tool);
    }
}