namespace RailgunDownloaderV3.Core.UI.TruyenQQ.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class GoHomeButton {
    public void SetGoHomeButton(Form AppContext, Button GoHomeButton) {
        ToolTip PlaceHolder = new();
        GoHomeButton.Size = new Size(width: 50, height: 50);
        GoHomeButton.BackColor = Color.FromArgb(21, 21, 21);
        GoHomeButton.FlatStyle = FlatStyle.Flat;
        GoHomeButton.FlatAppearance.BorderSize = 0;
        GoHomeButton.Location = new Point(x: 520, y: 5);
        GoHomeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.GoHome.Button.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            GoHomeButton.Image = Img;
            GoHomeButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        PlaceHolder.SetToolTip(GoHomeButton, "Trở về trang chủ");
        AppContext.Controls.Add(GoHomeButton);
    }
}