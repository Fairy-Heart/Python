/*
* Railgun Downloader version 3.0.0
* TruyenQQ.Button.cs 
* You can also find other version of project at:
* https://github.com/Fairy-Heart/RailgunDownloader
*/
namespace RailgunDownloaderV3.Core.UI.Buttons;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using RailgunDownloaderV3.Core.UI.TruyenQQ;

public partial class TruyenQQButton {
    private readonly RailgunDownloaderV3.App? AppScene;
    private readonly TruyenQQUI QQUI;
    public TruyenQQButton(RailgunDownloaderV3.App AppScene) {
        this.AppScene = AppScene;
        QQUI = new(AppScene: AppScene);
    }

    public void ShowDialogButton(Button ShowButton) {
        ToolTip PlaceHolder = new();
        ShowButton.Size = new Size(width: 50, height: 50);
        ShowButton.Top = 10;
        ShowButton.FlatStyle = FlatStyle.Flat;
        ShowButton.FlatAppearance.BorderSize = 0;
        ShowButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using (var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.TruyenQQ.TruyenQQ.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));
            ShowButton.Image = Img;
            ShowButton.ImageAlign = ContentAlignment.MiddleCenter;
        }
        PlaceHolder.SetToolTip(ShowButton, "Tải truyện về từ TruyenQQ");

        ShowButton.Click += ShowWindow;

        AppScene!.Controls.Add(ShowButton);
    }
    private void ShowWindow(object? sender, EventArgs eventArgs) {
        QQUI.ShowUI(true);
        AppScene!.Visible = false;
    }
}