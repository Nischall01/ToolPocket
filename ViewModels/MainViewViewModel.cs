using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToolPocket.Models;
using ToolPocket.Services;
using ToolPocket.Views;

namespace ToolPocket.ViewModels;

public partial class MainViewViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<Tool> _apps = [];

    [RelayCommand]
    public async Task AddNewApp()
    {
        var newApps = await DialogService.ShowDialogAsync<ObservableCollection<Tool>>(new AddToolDialog());
        if (newApps is null) return;
        foreach (var newApp in newApps)
        {
            Apps.Add(newApp);
            Console.WriteLine("");
            Console.WriteLine(newApp.AppPath);
            Console.WriteLine(newApp.AppName);
            Console.WriteLine($"Run on Startup: {newApp.RunOnStartUp}");
            Console.WriteLine($"Add to Programs: {newApp.AddToPrograms}");
            Console.WriteLine($"Add to Start Menu: {newApp.AddToStart}");
        }
    }
}