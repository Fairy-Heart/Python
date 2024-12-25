namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;

public partial class GoHome {
    private readonly Youtube YoutubeUIScene;
    private readonly CancelDownload CancelDownload;
    public GoHome(Youtube YoutubeUIScene) {
        this.YoutubeUIScene = YoutubeUIScene;
        CancelDownload = new(YoutubeUIScene: YoutubeUIScene);
    }
    public void SetGoHomeButton(Form AppContext, Button GoHomeButton) {
        ToolTip Placeholder = new();

        GoHomeButton.Size = new Size(width: 50, height: 50);
        GoHomeButton.Location = new Point(x: 700, y: 10);
        GoHomeButton.FlatAppearance.BorderSize = 0;
        GoHomeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        GoHomeButton.FlatStyle = FlatStyle.Flat;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.GoHome.Button.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            GoHomeButton.Image = Img;
            GoHomeButton.ImageAlign = ContentAlignment.MiddleCenter;
        }


        Placeholder.SetToolTip(GoHomeButton, "Quay trở lại màn hình chính");

        GoHomeButton.Click += GobackHome;

        AppContext.Controls.Add(GoHomeButton);
    }

    private void GobackHome(object? sender, EventArgs eventArgs) {
        var ProcessName = Process.GetProcessesByName("railgun_ytp");
        if(ProcessName.Length != 0) {
            DialogResult ConfirmCancelDialog = MessageBox.Show(
                "Trở về trang chủ sẽ hủy tiến trình tải xuống tại đây!\nXác nhận hủy?",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
            );
            if(ConfirmCancelDialog == DialogResult.OK) {
                CancelDownload.KillTask();

                MessageBox.Show(
                    "Hủy tiến trình tải xuống thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            if(ConfirmCancelDialog == DialogResult.Cancel) return;
        }
        YoutubeUIScene.AppUI!.Close();
    }
}