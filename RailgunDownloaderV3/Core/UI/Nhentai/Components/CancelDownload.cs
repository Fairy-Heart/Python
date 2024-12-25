namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;

public partial class CancelDownloadComponent {
    private readonly NhentaiUI AppScene;
    private readonly IsTaskRun IsTaskRun;
    
    public CancelDownloadComponent(NhentaiUI AppScene) {
        this.AppScene = AppScene;
        IsTaskRun = new();
    }

    public void KillTask(string TaskName) {
        ProcessStartInfo StartInfo = new();
        StartInfo.FileName = "cmd.exe";
        StartInfo.Arguments = $"/c taskkill /IM {TaskName} /F";
        StartInfo.CreateNoWindow = true;
        StartInfo.UseShellExecute = false;

        Process ProcessStart = new();
        ProcessStart.StartInfo = StartInfo;

        ProcessStart.Start();
    }
    public void SetCancelDownload(Form AppContext, Button CancelButton) {
        ToolTip Placeholder = new();

        CancelButton.Size = new Size(width: 50, height: 50);
        CancelButton.FlatAppearance.BorderSize = 0;
        CancelButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        CancelButton.FlatStyle = FlatStyle.Flat;
        CancelButton.Location = new Point(x: 400, y: 405);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Cancel.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            CancelButton.Image = Img;
            CancelButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(CancelButton, "Hủy bỏ tải xuống");

        CancelButton.Click += CancelTaskDownload;

        AppContext.Controls.Add(CancelButton);
    }

    private void CancelTaskDownload(object? sender, EventArgs eventArgs) {
        if (!IsTaskRun.TaskIsAlreadyRun("railgun_ntd") && !IsTaskRun.TaskIsAlreadyRun("railgun_ntd_code")) {
            MessageBox.Show(
                "Không có tiến trình tải xuống nào!\nBạn không cần hủy nữa",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(IsTaskRun.TaskIsAlreadyRun("railgun_ntd")) {
            KillTask("railgun_ntd.exe");
            AppScene.ResultLog!.Text = "Hủy tiến trình tải xuống thành công!\n";
            return;
        }

        if(IsTaskRun.TaskIsAlreadyRun("railgun_ntd_code")) {
            KillTask("railgun_ntd_code.exe");
            AppScene.ResultLog!.Text = "Hủy tiến trình tải xuống thành công!\n";
            return;
        }

    }
}