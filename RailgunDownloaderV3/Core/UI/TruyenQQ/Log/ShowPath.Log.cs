namespace RailgunDownloaderV3.Core.UI.Log;

public partial class ShowPath {
    public void SetShowPath(Form AppContext, RichTextBox ShowPathLog) {
        ToolTip Placeholder = new();

        ShowPathLog.Location = new Point(x: 70, y: 320);
        ShowPathLog.BorderStyle = BorderStyle.None;
        ShowPathLog.ReadOnly = true;
        ShowPathLog.BackColor = Color.FromArgb(69, 69, 69);
        ShowPathLog.ForeColor = Color.White;
        ShowPathLog.Size = new Size(width: 450, height: 40);

        Placeholder.SetToolTip(ShowPathLog, "Đường dẫn lưu truyện được chọn sẽ hiển thị ở đây");

        AppContext.Controls.Add(ShowPathLog);
    }
}