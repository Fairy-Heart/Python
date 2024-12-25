namespace RailgunDownloaderV3.Core.UI.TruyenQQ.Main;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Text;

public partial class CLI {
    private readonly TruyenQQUI TruyenQQ;

    public CLI(TruyenQQUI TruyenQQ) {
        this.TruyenQQ = TruyenQQ;
    }

    public void DownloadQQ(string SavePath, string Url) {
        string RelativePathCLI = @"Core\bin\railgun.exe";
        string CLI_Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, RelativePathCLI);

        string CLI_Argument = $"truyenqq --d {Url}";

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
                TruyenQQ.DownloadLog!.AppendText($"{Result}\n");
            }
            ProcessStart.Kill(); 
        });

        OutputThread.Start();
    }
}