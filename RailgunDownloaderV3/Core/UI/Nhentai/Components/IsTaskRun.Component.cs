/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Diagnostics;

public partial class IsTaskRun {
    public bool TaskIsAlreadyRun(string TaskName) {
        var Task = Process.GetProcessesByName(TaskName);
        if(Task.Length == 0) {
            return false;
        }
        return true;
    }
}