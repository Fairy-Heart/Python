namespace RailgunDownloaderV3.Core.UI.TruyenQQ.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class ChoosePathButton {
    private readonly TruyenQQ.TruyenQQUI TruyenQQUI;
    
    public ChoosePathButton(TruyenQQUI TruyenQQ){
        this.TruyenQQUI = TruyenQQ;
    }

    public void SetChoosePathButton(Form AppContext, Button ChoosePathButton) {
        ToolTip Placeholder = new();

        ChoosePathButton.Location = new Point(x: 10, y: 315);
        ChoosePathButton.Size = new Size(width: 50, height: 50);
        ChoosePathButton.FlatStyle = FlatStyle.Flat;
        ChoosePathButton.FlatAppearance.BorderSize = 0;
        ChoosePathButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Folder.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            ChoosePathButton.Image = Img;
            ChoosePathButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(ChoosePathButton, "Chọn thư mục lưu truyện");

        ChoosePathButton.Click += ShowDirectoryPathChoose;

        AppContext.Controls.Add(ChoosePathButton);
    }

    private void ShowDirectoryPathChoose(object? sender, EventArgs eventArgs) {
        FolderBrowserDialog ChooseFolder = new();
        if(ChooseFolder.ShowDialog() == DialogResult.OK) {
            TruyenQQUI.ShowPathLog!.Text = "";
            TruyenQQUI.ShowPathLog!.Text = ChooseFolder.SelectedPath;
        }
    }
}