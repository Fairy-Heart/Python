namespace RailgunDownloaderV3.Core.UI.TruyenQQ.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
public partial class Download {
    private readonly TruyenQQUI TruyenQQ;
    private readonly Main.CLI CLI;
    public Download(TruyenQQUI TruyenQQ) {
        this.TruyenQQ = TruyenQQ;
        CLI = new(TruyenQQ: TruyenQQ);
    }
    public void SetDownloadButton(Form AppContext, Button DownloadButton) {
        ToolTip Placeholder = new();

        DownloadButton.Location = new Point(x: 470, y: 370);
        DownloadButton.Size = new Size(width: 50, height: 50);
        DownloadButton.FlatAppearance.BorderSize = 0;
        DownloadButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        DownloadButton.FlatStyle = FlatStyle.Flat;

        using(var Stream  = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Download.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            DownloadButton.Image = Img;
            DownloadButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        DownloadButton.Click += DownloadFromTruyenQQ;

        Placeholder.SetToolTip(DownloadButton, "Tải về truyện");
        AppContext.Controls.Add(DownloadButton);
    }

    private void DownloadFromTruyenQQ(object? sender, EventArgs eventArgs) {
        string SavePath = TruyenQQ.ShowPathLog!.Text;
        string Url = TruyenQQ.InputUrlField!.Text;
        if(string.IsNullOrEmpty(Url)) {
            MessageBox.Show(
                "URL không hợp lệ hoặc để trống",
                "Cảnh báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        if(!Directory.Exists(SavePath)) {
            MessageBox.Show(
                "Nơi lưu truyện không tồn tại hoặc đã bị xóa",
                "Cảnh báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        CLI.DownloadQQ(SavePath: SavePath, Url: Url);
    }
}