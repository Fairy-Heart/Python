namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;

public partial class CancelDownload {
    private readonly Youtube YoutubeUIScene;
    public CancelDownload(Youtube YoutubeUIScene) {
        this.YoutubeUIScene = YoutubeUIScene;
    }
    public void SetCancelDownload(Form AppContext, Button CancelButton) {
        ToolTip Placeholder = new();

        CancelButton.Size = new Size(width: 50, height: 50);
        CancelButton.Location = new Point(x: 470, y: 405);
        CancelButton.FlatAppearance.BorderSize = 0;
        CancelButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        CancelButton.FlatStyle = FlatStyle.Flat;
        
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Cancel.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            CancelButton.Image = Img;
            CancelButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(CancelButton, "Hủy tiến trình tải xuống");

        CancelButton.Click += CancelDownloadProcess;

        AppContext.Controls.Add(CancelButton);
    }

    public void KillTask() {
        ProcessStartInfo ProcessInfo = new();
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.FileName = "cmd.exe";
        ProcessInfo.Arguments = "/c taskkill /IM railgun_ytp.exe /F";
        ProcessInfo.UseShellExecute = false;

        Process ProcessStart = new();
        ProcessStart.StartInfo = ProcessInfo;
        ProcessStart.Start();

        YoutubeUIScene.ResultLog!.Text = "";
        YoutubeUIScene.ResultLog!.Text = "Tiến trình tải xuống đã được hủy thành công\n";
    }

    private void CancelDownloadProcess(object? sender, EventArgs eventArgs) {
        DialogResult ChoiceResult = MessageBox.Show(
            "Hủy tiến trình tải xuống?",
            "Thông báo",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );

        var ProcessName = Process.GetProcessesByName("railgun_ytp");

        if(ChoiceResult == DialogResult.OK) {
            if(ProcessName.Length == 0) {
                MessageBox.Show(
                    "Không có tiến trình tải xuống nào!\nBạn không cần hủy nữa",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            KillTask();
            
            MessageBox.Show(
                "Hủy tiến trình tải xuống thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        if(ChoiceResult == DialogResult.Cancel) {
            MessageBox.Show(
                "Quá trình tải xuống sẽ được tiếp tục!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}