namespace RailgunDownloaderV3.Core.UI.Nettruyen.Log;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
public partial class ResultLogDownload {
    public void SetLogDownload(Form AppContext, RichTextBox ResultLog) {
        Label LogIcon = new();

        ToolTip Placeholder = new();

        ResultLog.Size = new Size(width: 420, height: 230);
        ResultLog.Location = new Point(x: 90, y: 10);
        ResultLog.BackColor = Color.FromArgb(69, 69, 69);
        ResultLog.ForeColor = Color.White;
        ResultLog.Font = new Font("Consolas", 10);
        ResultLog.BorderStyle = BorderStyle.None;
        ResultLog.ReadOnly = true;

        LogIcon.Size = new Size(width: 70, height: 70);
        LogIcon.Location = new Point(x: 0, y: 100);
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Log.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 70, height: 70));

            LogIcon.Image = Img;
            LogIcon.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(ResultLog, "Kết quả tải xuống hiển thị ở đây");
        

        AppContext.Controls.Add(ResultLog);
        AppContext.Controls.Add(LogIcon);
    }
}