namespace ToolPocket.ViewModels;

public class AddToolDialogViewModel : ViewModelBase
{
    /*
    private Window? _addToolDialog;

    [ObservableProperty]
    private string _exePath = string.Empty;

    [RelayCommand]
    [Obsolete("Obsolete")]
    private async Task OpenFileBrowser()
    {
        var openFileDialog = new OpenFileDialog
        {
            Title = "Select a file",
            Filters =
            [
                new FileDialogFilter { Name = "Executable Files", Extensions = { "exe" } },
                new FileDialogFilter { Name = "All Files", Extensions = { "*" } }
            ],
            AllowMultiple = false
        };

        _addToolDialog = new AddToolDialog();

        var result = await openFileDialog.ShowAsync(_addToolDialog ?? throw new InvalidOperationException());

        ExePath = result?.Length > 0 ? result[0] : string.Empty;
    }
*/
}