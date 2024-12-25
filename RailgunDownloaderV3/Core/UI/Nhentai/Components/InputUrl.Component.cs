/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai;
using System.Windows.Forms;
using System.Drawing;

public partial class InputUrlComponent {
    public void SetInputUrl(Form AppContext, RichTextBox InputUrl) {
        ToolTip Placeholder = new();

        InputUrl.Size = new Size(width: 400, height: 40);
        InputUrl.BorderStyle = BorderStyle.None;
        InputUrl.BackColor = Color.FromArgb(69, 69, 69);
        InputUrl.ForeColor = Color.White;
        InputUrl.Location = new Point(x: 50, y: 340);

        Placeholder.SetToolTip(InputUrl, "Nhập URL của doujinshi");

        AppContext.Controls.Add(InputUrl);
    }
}