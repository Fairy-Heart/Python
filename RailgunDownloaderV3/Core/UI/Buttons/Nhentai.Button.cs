namespace RailgunDownloaderV3.Core.UI.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using RailgunDownloaderV3.Core.UI.Nhentai;

public partial class NhentaiButton {
    private readonly App AppScene;
    private readonly NhentaiUI NhentaiUI;
    
    public NhentaiButton(App AppScene) {
        this.AppScene = AppScene;
        NhentaiUI = new(AppScene: AppScene);
    }
    public void SetNhentaiButton(Button NhentaiButton) {
        ToolTip Placeholder = new();

        NhentaiButton.Size = new Size(width: 50, height: 50);
        NhentaiButton.Location = new Point(x: 250, y: 10);
        NhentaiButton.FlatAppearance.BorderSize = 0;
        NhentaiButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        NhentaiButton.FlatStyle = FlatStyle.Flat;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Nhentai.Nhentai.jpg")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            NhentaiButton.Image = Img;
            NhentaiButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(NhentaiButton, "Tải doujinshi từ Nhentai.net");

        NhentaiButton.Click += ShowNhentaiUI;

        AppScene.Controls.Add(NhentaiButton);
    }

    private void ShowNhentaiUI(object? sender, EventArgs eventArgs) {
        NhentaiUI.ShowNhentaiUI(true);
        AppScene.Visible = false;
    }
}