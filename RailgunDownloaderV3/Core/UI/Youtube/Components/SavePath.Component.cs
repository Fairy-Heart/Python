namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class SavePathComponent {
    private readonly Youtube YoutubeUIScene;
    public SavePathComponent(Youtube YoutubeUIScene) {
        this.YoutubeUIScene = YoutubeUIScene;
    }
    public void SetSavePathComponent(Form AppContext, Button SavePathButton) {
        ToolTip Placeholder = new();

        SavePathButton.Location = new Point(x: 130, y: 275);
        SavePathButton.FlatAppearance.BorderSize = 0;
        SavePathButton.Size = new Size(width: 50, height: 50);
        SavePathButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        SavePathButton.FlatStyle = FlatStyle.Flat;
        
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Folder.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            SavePathButton.Image = Img;
            SavePathButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(SavePathButton, "Chọn đường dẫn lưu video tải xuống");

        SavePathButton.Click += ShowSavePathChoose;

        AppContext.Controls.Add(SavePathButton);
    }

    private void ShowSavePathChoose(object? sender, EventArgs eventArgs) {
        FolderBrowserDialog BrowserDialog = new();
        if(BrowserDialog.ShowDialog() == DialogResult.OK) {
            string SaveFolderPathValue = BrowserDialog.SelectedPath;

            YoutubeUIScene.ChoosePathBox!.Text = SaveFolderPathValue;
        }
    }
}