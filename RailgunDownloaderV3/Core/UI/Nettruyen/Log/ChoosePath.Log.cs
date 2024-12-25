namespace RailgunDownloaderV3.Core.UI.Nettruyen.Log;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class ChoosePathLog {
    public void SetShowChoosePath(Form AppContext, RichTextBox ChoosePathArea) {
        ToolTip Placeholder = new();

        ChoosePathArea.Size = new Size(width: 480, height: 50);
        ChoosePathArea.Location = new Point(x: 90, y: 370);
        ChoosePathArea.BorderStyle = BorderStyle.None;
        ChoosePathArea.BackColor = Color.FromArgb(69, 69, 69);
        ChoosePathArea.ForeColor = Color.White;
        ChoosePathArea.Font = new Font("Consolas", 10);
        ChoosePathArea.ReadOnly = true;

        Placeholder.SetToolTip(ChoosePathArea, "Đường dẫn được bạn lựa chọn sẽ hiển thị ở đây");

        AppContext.Controls.Add(ChoosePathArea);
     
    }
}
