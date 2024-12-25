namespace RailgunDownloaderV3.Core.UI.Nettruyen.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using RailgunDownloaderV3.Core.UI.Nettruyen.Main;

public class Download {
    private readonly NetTruyenUI AppScene;
    private readonly Main.CLI CLI;
    public Download(NetTruyenUI AppScene) {
        this.AppScene = AppScene;
        CLI = new(AppScene: AppScene);
    }
    public void SetChoosePathButton(Form AppContext, Button ChoosePathButton) {
        ToolTip Placeholder = new();

        ChoosePathButton.Size = new Size(width: 50, height: 50);
        ChoosePathButton.Location = new Point(x: 520, y: 450);
        ChoosePathButton.FlatAppearance.BorderSize = 0;
        ChoosePathButton.FlatStyle = FlatStyle.Flat;
        ChoosePathButton.BackColor = Color.FromArgb(21, 21, 21);
        ChoosePathButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Download.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            ChoosePathButton.Image = Img;
            ChoosePathButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        ChoosePathButton.Click += DownloadEvent;

        Placeholder.SetToolTip(ChoosePathButton, "Tải xuống truyện");

        AppContext.Controls.Add(ChoosePathButton);
    }

    private void DownloadEvent(object? sender, EventArgs eventArgs) {
        string UrlValue = AppScene.InputArea!.Text;
        string SavePathValue = AppScene.PathChoose!.Text;

        if(string.IsNullOrWhiteSpace(UrlValue)) {
            MessageBox.Show(
                "Vui lòng nhập URL hợp lệ",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(!Directory.Exists(SavePathValue)) {
            MessageBox.Show(
                "Đường dẫn bạn chọn không hợp lệ, hoặc đã bị xóa",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        CLI.Download(SavePath: SavePathValue, Url: UrlValue);
    }
}