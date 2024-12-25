/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/
namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

public partial class CLI_Component {
    private readonly NhentaiUI AppScene;
    
    public CLI_Component(NhentaiUI AppScene) {
        this.AppScene = AppScene;
    }
    public void CLI_Run(string Argument, string RelativePathCLI) {
        string CLI_Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePathCLI);

        ProcessStartInfo ProcessInfo = new();
        ProcessInfo.FileName = CLI_Path;
        ProcessInfo.Arguments = Argument;
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.RedirectStandardOutput = true;
        ProcessInfo.UseShellExecute = false;
        ProcessInfo.StandardOutputEncoding = Encoding.UTF8;

        Process ProcessStart = new();
        ProcessStart.StartInfo = ProcessInfo;

        string Result;
        Thread OutputThread = new(() => {
            ProcessStart.Start();

            while((Result = ProcessStart.StandardOutput.ReadLine()!) != null) {
                AppScene.ResultLog!.AppendText($"{Result}\n");
            }
            ProcessStart.Kill();
        });

        OutputThread.Start();
    }
}