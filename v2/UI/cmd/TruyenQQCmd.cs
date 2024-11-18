namespace UI.cmd;
using System.Diagnostics;

public class TruyenQQCmd {
    public void Download(
        string URL,
        string SavePath) {

           ProcessStartInfo Process = new();
           Process.FileName = "cmd.exe";
           Process.Arguments = $"/c cd {SavePath} && railgun truyenqq --d \"{URL}\" && pause";
           Process.CreateNoWindow = false;

        using Process CommandProcess = new Process { StartInfo = Process };
        CommandProcess.Start();
    }
}