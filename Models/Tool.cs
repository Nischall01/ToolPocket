using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ToolPocket.Models;

public class Tool
{
    public Tool(Action<Tool> removeAction, bool addToPrograms, bool addToStart, string name, string path,
        bool runOnStartUp)
    {
        AddToPrograms = addToPrograms;
        AddToStart = addToStart;
        AppName = name;
        AppPath = path;
        RunOnStartUp = runOnStartUp;

        RemoveApp = new RelayCommand(() => removeAction(this));
    }

    public ICommand RemoveApp { get; }
    public bool AddToPrograms { get; set; }
    public bool AddToStart { get; set; }
    public string AppName { get; set; }
    public string AppPath { get; set; }
    public bool RunOnStartUp { get; set; }
}