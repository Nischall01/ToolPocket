using System;
using System.Diagnostics;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToolPocket.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private const string AppPath = @"D:\Nischal\Tools\DB.Browser.for.SQLite-win64\DB Browser for SQLite.exe";

    [ObservableProperty]
    private Bitmap? _extractedImage;

    public MainWindowViewModel()
    {
        LoadImage();
    }

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

    private static void LoadImage()
    {
    }
}