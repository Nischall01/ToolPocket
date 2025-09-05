using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace ToolPocket.Services.FilePicker;

public interface IFilePickerService
{
    Task<Uri?> PickFileAsync(TopLevel topLevel, string title, IReadOnlyList<FilePickerFileType> fileTypes);

    Task<IEnumerable<Uri?>> PickFilesAsync(TopLevel topLevel, string title,
        IReadOnlyList<FilePickerFileType> fileTypes);

    Task<Uri?> PickFolderAsync(TopLevel topLevel, string title);
}