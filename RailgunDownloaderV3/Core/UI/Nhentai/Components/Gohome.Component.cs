/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class GohomeComponent {
    private readonly NhentaiUI AppScene;
    private readonly IsTaskRun IsTaskRun;
    private readonly CancelDownloadComponent CancelDownloadComponent;

    
    public GohomeComponent(NhentaiUI NhentaiUI) {
        this.AppScene = NhentaiUI;
        IsTaskRun = new();
        CancelDownloadComponent = new(AppScene: AppScene);
    }
    public void SetGohomeButton(Form AppContext, Button GohomeButton) {
        ToolTip Placeholder = new();

        GohomeButton.Size = new Size(width: 50, height: 50);
        GohomeButton.Location = new Point(x: 530, y: 10);
        GohomeButton.FlatAppearance.BorderSize = 0;
        GohomeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        GohomeButton.FlatStyle = FlatStyle.Flat;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.GoHome.Button.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            GohomeButton.Image = Img;
            GohomeButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(GohomeButton, "Trở về trang chủ");

        GohomeButton.Click += GoMainWindow;

        AppContext.Controls.Add(GohomeButton);
    }

    private void GoMainWindow(object? sender, EventArgs eventArgs) {
        AppScene.AppUI!.Close();
    }
}