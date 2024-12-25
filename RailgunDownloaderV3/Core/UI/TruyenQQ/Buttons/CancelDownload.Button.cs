namespace RailgunDownloaderV3.Core.UI.TruyenQQ.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;

public partial class CancelDownload {
    private readonly TruyenQQUI TruyenQQ;
    public CancelDownload(TruyenQQUI TruyenQQ) {
        this.TruyenQQ = TruyenQQ;
    }
    public void SetCancelButton(Form AppContext, Button CancelButton) {
        ToolTip Placeholder = new();

        CancelButton.Size = new Size(width: 50, height: 50);
        CancelButton.Location = new Point(x: 400, y: 372);
        CancelButton.FlatStyle = FlatStyle.Flat;
        CancelButton.FlatAppearance.BorderSize = 0;
        CancelButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Cancel.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            CancelButton.Image = Img;
            CancelButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(CancelButton, "Hủy tiến trình tải xuống");

        CancelButton.Click += CancelDownloadAction;

        AppContext.Controls.Add(CancelButton);
    }

    private void KillTask() {
        ProcessStartInfo ProcessInfo = new();
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.FileName = "cmd.exe";
        ProcessInfo.Arguments = "/c taskkill /IM railgun.exe /F";
        ProcessInfo.UseShellExecute = false;

        Process ProcessStart = new();
        ProcessStart.StartInfo = ProcessInfo;
        ProcessStart.Start();
        
        TruyenQQ.DownloadLog!.Text = "";
        TruyenQQ.DownloadLog!.Text = "Hủy tải xuống truyện thành công.\n";
    }

    private void CancelDownloadAction(object? sender, EventArgs eventArgs) {
        DialogResult ChoiceResult = MessageBox.Show(
            "Xác nhận hủy tiến trình tải xuống truyện?",
            "Thông báo",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question
        );

        var ProcessName = Process.GetProcessesByName("railgun");

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
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation
            );
            return;
        } 
        
        if(ChoiceResult == DialogResult.Cancel) {
            MessageBox.Show(
                "Tiến trình sẽ được tiếp tục tải xuống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}