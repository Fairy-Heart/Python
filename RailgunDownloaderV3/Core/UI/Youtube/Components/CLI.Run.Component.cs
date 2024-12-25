namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;

public class CLIRunComponent {
    
    private readonly Youtube YoutubeUIScene;

    public CLIRunComponent(Youtube YoutubeUIScene) {
        this.YoutubeUIScene = YoutubeUIScene;
    }
    public void RunDownloadHelper(string PlaylistUrl, string SavePath, string Quality) {
        string RelativePathCLI = @"Core\bin\railgun_ytp.exe";
        string CLI_Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePathCLI);

        string CLI_Argument = $"--u \"{PlaylistUrl}\" --p \"{SavePath}\" --q \"{Quality}\"";

        ProcessStartInfo StartInfo = new();
        StartInfo.FileName = CLI_Path;
        StartInfo.Arguments = CLI_Argument;
        StartInfo.CreateNoWindow = true;
        StartInfo.RedirectStandardOutput = true;
        StartInfo.UseShellExecute = false;
        StartInfo.StandardOutputEncoding = Encoding.UTF8;
        
        Process ProcessStart = new();
        ProcessStart.StartInfo = StartInfo;

        string Result;
        Thread OutputThread = new(() => {
            ProcessStart.Start();

            while((Result = ProcessStart.StandardOutput.ReadLine()!) != null) {
                YoutubeUIScene.ResultLog!.AppendText($"{Result}\n");
            }
            ProcessStart.Kill();
        });

        OutputThread.Start();
    }
}