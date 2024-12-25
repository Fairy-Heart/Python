/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;

public partial class ResultLogComponent {
    public void SetResultLog(Form AppContext, RichTextBox ResultLog) {
        ToolTip Placeholder = new();

        ResultLog.Size = new Size(width: 400, height: 200);
        ResultLog.BorderStyle = BorderStyle.None;
        ResultLog.BackColor = Color.FromArgb(69, 69, 69);
        ResultLog.ForeColor = Color.White;
        ResultLog.Location = new Point(x: 50, y: 30);
        ResultLog.ReadOnly = true;

        Placeholder.SetToolTip(ResultLog, "Kết quả tải xuống sẽ được hiển thị tại đây");

        AppContext.Controls.Add(ResultLog);
    }
}