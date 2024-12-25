namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
public partial class InputUrlComponent {
    public void SetInputUrlComponent(Form AppContext, RichTextBox InputBox) {
        ToolTip Placeholder = new();
        Label Description = new();

        InputBox.Size = new Size(width: 400, height: 30);
        InputBox.Location = new Point(x: 200, y: 350);
        InputBox.BorderStyle = BorderStyle.None;
        InputBox.BackColor = Color.FromArgb(69, 69, 69);
        InputBox.ForeColor = Color.White;
        InputBox.Font = new Font("Consolas", 10);

        Placeholder.SetToolTip(InputBox, "Nhập đường dẫn tới Youtube Playlist của bạn tại đây");

        Description.Size = new Size(width: 40, height: 40);
        Description.Location = new Point(x: 135, y: 345);                          

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Input.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            Description.Image = Img;
            Description.ImageAlign = ContentAlignment.MiddleCenter;
        }

        AppContext.Controls.Add(InputBox);
        AppContext.Controls.Add(Description);
    }
}