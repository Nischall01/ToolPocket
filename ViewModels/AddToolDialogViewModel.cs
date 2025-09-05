using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToolPocket.Models;
using ToolPocket.Services.FilePicker;

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
        /*NewApps.Add(
            new Tool(RemoveApp, true, true, "ToolPocket", "Path", true));
        NewApps.Add(
            new Tool(RemoveApp, true, false, "Everything", "Path", true));
        NewApps.Add(
            new Tool(RemoveApp, true, false, "Rider", "Path", false));*/
    }

    public ObservableCollection<Tool> NewApps { get; } = [];

    public Action<ObservableCollection<Tool>?>? RequestClose { get; set; }

    [RelayCommand]
    public void Confirm()
    {
        RequestClose?.Invoke(NewApps);
    }

    /*[RelayCommand]
    public void Cancel()
    {
        RequestClose?.Invoke(null);
    }*/

    [RelayCommand]
    public void AddNewApp()
    {
        if (!IsNameOrPathEmpty(AppName, AppPath)) return;

        var newApp = new Tool(RemoveApp, AddToPrograms, AddToStart, AppName, AppPath, RunOnStartUp);
        if (NewApps.Any(item => item.AppName == newApp.AppName || item.AppPath == newApp.AppPath)) return;
        NewApps.Add(newApp);

        /*
        Console.WriteLine("");
        Console.WriteLine($"{AppPath}");
        Console.WriteLine($"{AppName}");
        Console.WriteLine($"{RunOnStartUp}");
        Console.WriteLine($"{AddToPrograms}");
        Console.WriteLine($"{AddToStart}");
    */
    }

    private static bool IsNameOrPathEmpty(string appName, string appPath)
    {
        return !string.IsNullOrWhiteSpace(appName) && !string.IsNullOrWhiteSpace(appPath);
    }

    [RelayCommand]
    public async Task OpenFilePicker(TopLevel topLevel)
    {
        IReadOnlyList<FilePickerFileType> fileTypeFilter =
        [
            new("Executables")
            {
                Patterns = ["*.exe", ".ps1"]
            }
        ];
        var filePicker = new FilePickerService();
        var fileUri = await filePicker.PickFileAsync(topLevel, "Select a executable or script", fileTypeFilter);
        if (fileUri == null) return;
        SetAppPathAndAppName_FilePicker(fileUri);
    }

    private void SetAppPathAndAppName_FilePicker(Uri fileUri)
    {
        AppPath = fileUri.LocalPath;
        AppName = Path.GetFileNameWithoutExtension(AppPath);
    }

    private void RemoveApp(Tool tool)
    {
        NewApps.Remove(tool);
    }
}