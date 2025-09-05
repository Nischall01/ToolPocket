using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace ToolPocket.Services.FilePicker;

public class FilePickerService : IFilePickerService
{
    public async Task<IEnumerable<Uri?>> PickFilesAsync(TopLevel topLevel, string title,
        IReadOnlyList<FilePickerFileType> fileTypes)
    {
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = title,
            FileTypeFilter = fileTypes,
            AllowMultiple = true
        });

        List<Uri?> fileList = [];
        fileList.AddRange(files.Select(file => file.Path));
        IEnumerable<Uri?> enumerableFiles = fileList;
        return enumerableFiles;
    }

    public async Task<Uri?> PickFileAsync(TopLevel topLevel, string title,
        IReadOnlyList<FilePickerFileType> fileTypes)
    {
        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = title,
            FileTypeFilter = fileTypes,
            AllowMultiple = false
        });
        return file[0].Path;
    }


    public async Task<Uri?> PickFolderAsync(TopLevel topLevel, string title)
    {
        var folders = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select a folder",
            AllowMultiple = false
        });
        return folders[0].Path;
    }
}