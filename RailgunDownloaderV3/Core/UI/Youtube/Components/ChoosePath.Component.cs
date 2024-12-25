namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using  System.Windows.Forms;
using System.Drawing;

public partial class ChoosePathComponent {
    public void SetChoosePathComponent(Form AppContext, RichTextBox ChoosePathField) {
        ToolTip Placeholder = new();

        ChoosePathField.Size = new Size(width: 400, height: 50);
        ChoosePathField.Location = new Point(x: 200, y: 270);
        ChoosePathField.BackColor = Color.FromArgb(69, 69, 69);
        ChoosePathField.ForeColor = Color.White;
        ChoosePathField.BorderStyle = BorderStyle.None;
        ChoosePathField.Font = new Font("Consolas", 10);
        ChoosePathField.ReadOnly = true;

        Placeholder.SetToolTip(ChoosePathField, "Đường dẫn lưu tệp bạn chọn sẽ được hiển thị ở đây");

        AppContext.Controls.Add(ChoosePathField);
    }
}