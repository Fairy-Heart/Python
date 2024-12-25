/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/
namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class DownloadButtonComponent {
    private readonly NhentaiUI AppScene;
    private readonly IsTaskRun IsTaskRun;
    private readonly CLI_Component CLI_Component;
    public DownloadButtonComponent(NhentaiUI AppScene) {
        this.AppScene = AppScene;
        IsTaskRun = new();
        CLI_Component = new(AppScene: AppScene);
    }
    public void SetDownloadButton(Form AppContext, Button DownloadButton) {
        ToolTip Placeholder = new();

        DownloadButton.Size = new Size(width: 50, height: 50);
        DownloadButton.Location = new Point(x: 460, y: 335);
        DownloadButton.FlatAppearance.BorderSize = 0;
        DownloadButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        DownloadButton.FlatStyle = FlatStyle.Flat;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Download.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            DownloadButton.Image = Img;
            DownloadButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(DownloadButton, "Tải về doujinshi ngay!");

        DownloadButton.Click += Download;

        AppContext.Controls.Add(DownloadButton);
    }

    private void Download(object? sender, EventArgs eventArgs) {
        string ChoosePathValue = AppScene.ChoosePathBox!.Text;
        string InputUrlValue = AppScene.InputUrlBox!.Text;

        if(!Directory.Exists(ChoosePathValue)) {
            MessageBox.Show(
                "Đường dẫn bạn vừa lựa chọn không hợp lệ, bị xóa hoặc đã bị chỉnh sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(string.IsNullOrWhiteSpace(InputUrlValue)) {
            MessageBox.Show(
                "Bạn cần nhập URL của doujinshi đó để bắt đầu tải xuống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(IsTaskRun.TaskIsAlreadyRun("railgun_ntd") == true) {
            MessageBox.Show(
                "Tiến trình tải xuống hiện đang trong quá trình khởi chạy!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        AppScene.ResultLog!.Text = "";
        CLI_Component.CLI_Run($"--u \"{InputUrlValue}\" --p \"{ChoosePathValue}\"",  @"Core\bin\railgun_ntd.exe");
    }
}