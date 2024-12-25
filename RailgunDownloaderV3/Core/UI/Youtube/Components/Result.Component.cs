namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using  System.Windows.Forms;
using System.Drawing;

public partial class ResultComponent {
    public void SetResultComponents(Form AppContext, RichTextBox ResultLog) {
        ToolTip Placeholder = new();

        ResultLog.Size = new Size(width: 400, height: 200);
        ResultLog.Location = new Point(x: 200, y: 40);
        ResultLog.ReadOnly = true;
        ResultLog.Font = new Font("Consolas", 10);
        ResultLog.BorderStyle = BorderStyle.None;
        ResultLog.BackColor = Color.FromArgb(69, 69, 69);
        ResultLog.ForeColor = Color.White;

        Placeholder.SetToolTip(ResultLog, "Kết quả tải xuống được hiển thị ở đây");

        AppContext.Controls.Add(ResultLog);
    }
}