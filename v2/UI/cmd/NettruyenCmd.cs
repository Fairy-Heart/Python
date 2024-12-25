namespace UI.cmd;
using System.Diagnostics;

public class NetTruyenCmd {
    public void NettruyenDownload(string URL, string SavePath) {
        ProcessStartInfo Process = new();
        Process.FileName = "cmd.exe";
        Process.Arguments = $"/c cd {SavePath} && railgun nettruyen --d \"{URL}\" && pause";
        Process.CreateNoWindow = false;

        using Process CommandProcess = new();
        CommandProcess.StartInfo = Process;
        CommandProcess.Start();
    }
}