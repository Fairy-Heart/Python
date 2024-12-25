namespace RailgunDownloaderV3.Core.UI.Nettruyen.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class ChoosePath {
    private readonly NetTruyenUI AppScene;
    public ChoosePath(NetTruyenUI AppScene) {
        this.AppScene = AppScene;
    }
    public void SetChoosePath(Form AppContext, Button ChoosePathButton) {
        ToolTip Placeholder = new();

        ChoosePathButton.Size = new Size(width: 50, height: 50);
        ChoosePathButton.Location = new Point(x: 10, y: 370);
        ChoosePathButton.FlatStyle = FlatStyle.Flat;
        ChoosePathButton.FlatAppearance.BorderSize = 0;
        ChoosePathButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Folder.png");
        Image OriginalImg = Image.FromStream(Stream!);
        Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));
        ChoosePathButton.Image = Img;
        ChoosePathButton.ImageAlign = ContentAlignment.MiddleCenter;

        ChoosePathButton.Click +=  ChooseDirectory;

        Placeholder.SetToolTip(ChoosePathButton, "Chọn đường dẫn lưu truyện");
        
        AppContext.Controls.Add(ChoosePathButton);
    }

    private void ChooseDirectory(object? sender, EventArgs eventArgs) {
        FolderBrowserDialog ChooseFolder = new();

        if(ChooseFolder.ShowDialog() == DialogResult.OK) {
            AppScene.PathChoose!.Text = ChooseFolder.SelectedPath;
        }
    }
}