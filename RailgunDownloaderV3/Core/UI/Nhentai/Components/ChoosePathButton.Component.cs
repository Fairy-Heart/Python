/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class ChoosePathButtonComponent {
    private readonly NhentaiUI AppScene;
    public ChoosePathButtonComponent(NhentaiUI AppScene) {
        this.AppScene = AppScene;
    }
    public void SetChoosePathButton(Form AppContext, Button ChoosePathButton) {
        ToolTip Placeholder = new();

        ChoosePathButton.Size = new Size(width: 50, height: 50);
        ChoosePathButton.FlatAppearance.BorderSize = 0;
        ChoosePathButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        ChoosePathButton.FlatStyle = FlatStyle.Flat;
        ChoosePathButton.Location = new Point(x: 460, y: 245);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Folder.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            ChoosePathButton.Image = Img;
            ChoosePathButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(ChoosePathButton, "Lựa chọn đường dẫn tải về doujinshi");

        ChoosePathButton.Click += ChoosePath;

        AppContext.Controls.Add(ChoosePathButton);
    }

    private void ChoosePath(object? sender, EventArgs eventArgs) {
        FolderBrowserDialog ChooseFolderDialog = new();

        if(ChooseFolderDialog.ShowDialog() == DialogResult.OK) {
            AppScene.ChoosePathBox!.Text = ChooseFolderDialog.SelectedPath;
        }
    }
}