namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;

public partial class QualityChoose {
    public void SetQualityChoose(Form AppContext, ComboBox QualityChoose) {
        ToolTip Placeholder = new();

        QualityChoose.DropDownStyle = ComboBoxStyle.DropDownList;
        QualityChoose.Size = new Size(width: 195, height: 30);
        QualityChoose.Items.Add("Chất lượng cao nhất");
        QualityChoose.Items.Add("Chất lượng thấp nhất");
        QualityChoose.Items.Add("Chỉ video, chất lượng cao nhất");
        QualityChoose.Items.Add("Chỉ video, chất lượng thấp nhất");
        QualityChoose.Items.Add("Chỉ audio, chất lượng cao nhất");
        QualityChoose.Items.Add("Chỉ audio, chất lượng thấp nhất");
        QualityChoose.SelectedIndex = 0;
        QualityChoose.Location = new Point(x: 200, y: 420);
        QualityChoose.FlatStyle = FlatStyle.Flat;
        QualityChoose.BackColor = Color.Black;
        QualityChoose.ForeColor = Color.White;

        Placeholder.SetToolTip(QualityChoose, "Chọn chất lượng tải xuống");

        AppContext.Controls.Add(QualityChoose);
    }
}