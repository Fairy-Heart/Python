namespace RailgunDownloaderV3.Core.UI.TruyenQQ.TextInput;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class InputUrl {

    public void SetInputUrl(Form AppContext, RichTextBox InputUrlField) {
        ToolTip PlaceHolder = new();
        Label InputIcon = new();

        InputUrlField.Size = new Size(width: 450, height: 40);
        InputUrlField.BorderStyle = BorderStyle.None;
        InputUrlField.Location = new Point(x: 70, y: 250);
        InputUrlField.BackColor = Color.FromArgb(69, 69, 69);
        InputUrlField.ForeColor = Color.White;

        InputIcon.Size = new Size(width: 50, height: 50);
        InputIcon.Location = new Point(x: 10, y: 245);
        

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Input.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));
            InputIcon.Image = Img;
        }

        PlaceHolder.SetToolTip(InputUrlField, "Nhập URL của TruyenQQ");

        AppContext.Controls.Add(InputUrlField);
        AppContext.Controls.Add(InputIcon);
    }
}