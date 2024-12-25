namespace RailgunDownloaderV3;
using System.Windows.Forms;
using System.Reflection;
using RailgunDownloaderV3.Core.UI.Buttons;

public partial class App : Form {
    private readonly TruyenQQButton TruyenQQButton;
    private readonly NetTruyenButton NetTruyenButton;
    private readonly YTPLayListButton YTPlayList;
    private readonly NhentaiButton NhentaiButton;
    private Button ShowQQDialogButton;
    private Button ShowNetTruyenDialogButton;
    private Button ShowPlaylistYTButton;
    private Button ShowNhentaiButton;
    public App() {
        /*
        * Setup default property for application
        */
        Text = "Railgun Downloader V3";
        Size = new Size(width: 600, height: 600);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.AppIcon.ico")) {
            Image AppIcon = Image.FromStream(Stream!);
            Stream!.Seek(0, SeekOrigin.Begin);
            Icon = new Icon(Stream!);
        }

        MaximizeBox = false;
        BackColor = Color.FromArgb(21, 21, 21);
        ForeColor = Color.White;
        Font = new Font("Consolas", 10);

        TruyenQQButton = new TruyenQQButton(this);
        ShowQQDialogButton = new Button();
        TruyenQQButton.ShowDialogButton(ShowButton: ShowQQDialogButton);

        NetTruyenButton = new NetTruyenButton(this);
        ShowNetTruyenDialogButton = new();
        NetTruyenButton.ShowDialogButton(ShowButton: ShowNetTruyenDialogButton);

        YTPlayList = new YTPLayListButton(this);
        ShowPlaylistYTButton = new();
        YTPlayList.SetPlaylistButton(PlaylistButton: ShowPlaylistYTButton);

        NhentaiButton = new NhentaiButton(this);
        ShowNhentaiButton = new();
        NhentaiButton.SetNhentaiButton(NhentaiButton: ShowNhentaiButton);
    }
}
