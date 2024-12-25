namespace RailgunDownloaderV3.Core.UI.Nettruyen.Main;
using System.Diagnostics;
using System.Text;
using System.Threading;

public class CLI {
    private readonly NetTruyenUI AppScene;
    public CLI(NetTruyenUI AppScene) {
        this.AppScene = AppScene;
    }
    public void Download(string SavePath, string Url) {
        string RelativePathCLI = @"Core\bin\railgun.exe";
        string CLI_Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePathCLI);

        string CLI_Argument = $"nettruyen --d {Url}";

         ProcessStartInfo ProcessInfo = new();
        ProcessInfo.FileName = CLI_Path;
        ProcessInfo.Arguments = CLI_Argument;
        ProcessInfo.RedirectStandardOutput = true;
        ProcessInfo.UseShellExecute = false;
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.WorkingDirectory = SavePath;
        ProcessInfo.StandardOutputEncoding = Encoding.UTF8;

       	Process ProcessStart = new();
        ProcessStart.StartInfo = ProcessInfo;
        
        Thread OutputThread = new(() => {
            ProcessStart.Start();
            string Result;

            while ((Result = ProcessStart.StandardOutput.ReadLine()!) != null) {
               AppScene.DownloadLog!.AppendText($"{Result}\n");
            }
            ProcessStart.Kill(); 
        });

        OutputThread.Start();
    }
}