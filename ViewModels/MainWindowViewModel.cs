using System;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace ToolPocket.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private const string AppPath = @"D:\Nischal\Tools\DB.Browser.for.SQLite-win64\DB Browser for SQLite.exe";

    [RelayCommand]
    private static void Run()
    {
        try
        {
            Process.Start(AppPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting the application: {ex.Message}");
        }
    }

    [RelayCommand]
    private static void Rename()
    {
    }
}