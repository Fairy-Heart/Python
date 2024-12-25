/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/
namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;

public partial class ChoosePathComponent {
    public void SetShowChoosePath(Form AppContext, RichTextBox ChoosePath) {
        ToolTip Placeholder = new();

        ChoosePath.Size = new Size(width: 400, height: 40);
        ChoosePath.BorderStyle = BorderStyle.None;
        ChoosePath.BackColor = Color.FromArgb(69, 69, 69);
        ChoosePath.ForeColor = Color.White;
        ChoosePath.Location = new Point(x: 50, y: 250);
        ChoosePath.ReadOnly = true;

        Placeholder.SetToolTip(ChoosePath, "Đường dẫn tải xuống sẽ được hiển thị ở đây");

        AppContext.Controls.Add(ChoosePath);
    }
}