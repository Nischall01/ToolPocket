using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace ToolPocket.Services;

public static class DialogService
{
    public static async Task ShowDialogAsync(Window dialogWindow)
    {
        ArgumentNullException.ThrowIfNull(dialogWindow);

        var lifetime = (IClassicDesktopStyleApplicationLifetime?)Application.Current?.ApplicationLifetime;
        if (lifetime?.MainWindow is null)
            throw new InvalidOperationException("No MainWindow available to own the dialog.");

        await dialogWindow.ShowDialog(lifetime.MainWindow);
    }

    // Generic version that allows returning data
    public static async Task<TResult?> ShowDialogAsync<TResult>(Window dialogWindow)
    {
        ArgumentNullException.ThrowIfNull(dialogWindow);

        var lifetime = (IClassicDesktopStyleApplicationLifetime?)Application.Current?.ApplicationLifetime;
        if (lifetime?.MainWindow is null)
            throw new InvalidOperationException("No MainWindow available to own the dialog.");

        return await dialogWindow.ShowDialog<TResult?>(lifetime.MainWindow);
    }
}