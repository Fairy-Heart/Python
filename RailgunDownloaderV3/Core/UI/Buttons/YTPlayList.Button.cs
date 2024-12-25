namespace RailgunDownloaderV3.Core.UI.Buttons;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class YTPLayListButton {
    private  readonly App AppScene;
    private readonly Youtube.Youtube YoutubeUI;
    public YTPLayListButton(App AppScene) {
        this.AppScene = AppScene;
        YoutubeUI = new(AppScene: AppScene);
    }
    public void SetPlaylistButton(Button PlaylistButton) {
        ToolTip Placeholder = new();

        PlaylistButton.Size = new Size(width: 50, height: 50);
        PlaylistButton.Location = new Point(x: 180, y: 10);
        PlaylistButton.FlatAppearance.BorderSize = 0;
        PlaylistButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        PlaylistButton.FlatStyle = FlatStyle.Flat;

        using(var Stream  = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.YTIcon.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            PlaylistButton.Image = Img;
            PlaylistButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(PlaylistButton, "Tải một Playlist Youtube");

        PlaylistButton.Click += ShowYTDownloadWindow;

        AppScene.Controls.Add(PlaylistButton);
    }

    private void ShowYTDownloadWindow(object? sender, EventArgs eventArgs) {
        YoutubeUI.ShowYoutubeDownload(true);
        AppScene.Visible = false;
    }
}