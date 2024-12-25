/*
* RAILGUN DOWNLOADER VERSION 3.0.0
* URL.TextInput.cs
* Contributor: Reim
*/

namespace RailgunDownloaderV3.Core.UI.Nettruyen.TextInput;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


public partial class URL {
    public void SetURLInputArea(Form AppContext, RichTextBox InputArea) {
        ToolTip Placeholder = new();
        Label DescriptionIcon = new();

        InputArea.Size = new Size(width: 480, height: 50);
        InputArea.Location = new Point(x: 90, y: 300);
        InputArea.BorderStyle = BorderStyle.None;
        InputArea.BackColor = Color.FromArgb(69, 69, 69);
        InputArea.ForeColor = Color.White;
        InputArea.Font = new Font("Consolas", 10);

        DescriptionIcon.Size = new Size(width: 50, height: 50);
        DescriptionIcon.Location = new Point(x: 10, y: 300);
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Input.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            DescriptionIcon.Image = Img;
            DescriptionIcon.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(InputArea, "Nhập URL truyện của bạn vào đây");
        Placeholder.SetToolTip(DescriptionIcon, "Nhập URL truyện..");

        AppContext.Controls.Add(InputArea);
        AppContext.Controls.AddRange(DescriptionIcon);
    }
}