namespace RailgunDownloaderV3.Core.UI.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using RailgunDownloaderV3.Core.UI.Nettruyen;

public partial class NetTruyenButton {
    private readonly RailgunDownloaderV3.App AppScene;
    private readonly RailgunDownloaderV3.Core.UI.Nettruyen.NetTruyenUI NettruyenUI;
    public NetTruyenButton(App AppScene) {
        this.AppScene = AppScene;
        NettruyenUI = new(AppScene: AppScene);
    }
    public void ShowDialogButton(Button ShowButton) {
        ToolTip Placeholder = new();

        ShowButton.Size = new Size(width: 100, height: 50);
        ShowButton.Location = new Point(x: 60, y: 10);
        ShowButton.FlatStyle = FlatStyle.Flat;
        ShowButton.FlatAppearance.BorderSize = 0;
        ShowButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.NetTruyen.NetTruyen.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 100, height: 50));

            ShowButton.Image = Img;
            ShowButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(ShowButton, "Tải về truyện từ NetTruyen");

        ShowButton.Click += ShowDialog;
        
        AppScene.Controls.Add(ShowButton);
    }

    private void ShowDialog(object? sender, EventArgs eventArgs) {
        NettruyenUI.ShowUI(true);
        AppScene.Visible = false;
    }
}