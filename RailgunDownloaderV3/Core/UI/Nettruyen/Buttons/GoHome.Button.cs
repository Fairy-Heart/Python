namespace RailgunDownloaderV3.Core.UI.Nettruyen.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class GoHomeButton {
    public void SetGoHomeButton(Form AppContext, Button GoHomeButton) {
        ToolTip Placeholder = new();

        GoHomeButton.Location = new Point(x: 520, y: 5);
        GoHomeButton.Size = new Size(width: 50, height: 50);
        GoHomeButton.FlatStyle = FlatStyle.Flat;
        GoHomeButton.FlatAppearance.BorderSize = 0;
        GoHomeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.GoHome.Button.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            GoHomeButton.Image = Img;
            GoHomeButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(GoHomeButton, "Trở về trang chủ");
        AppContext.Controls.Add(GoHomeButton);
    }
}