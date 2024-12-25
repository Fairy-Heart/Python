namespace RailgunDownloaderV3.Core.UI.TruyenQQ;
using System.Windows.Forms;
using System.Reflection;
public partial class TruyenQQUI {
    private readonly RailgunDownloaderV3.App AppScene;
    private readonly Buttons.GoHomeButton? GoHome = new();
    private readonly TruyenQQ.TextInput.InputUrl InputUrl = new();
    private Button? GoHomeButton;
    private Form? AppUI;
    public RichTextBox? InputUrlField;
    public RichTextBox? ShowPathLog;
    private readonly Buttons.ChoosePathButton ChoosePath;
    private readonly Log.ShowPath ShowPath = new();
    private Button? ChoosePathButton;
    private readonly Buttons.Download Download;
    private Button? DownloadButton;
    public RichTextBox? DownloadLog;
    private Log.ResultLogDownload ResultLogDownload = new();
    private Buttons.CancelDownload CancelDownload;
    private readonly Main.CLI CLI;
    private Button? CancelButton;
    public TruyenQQUI(RailgunDownloaderV3.App AppScene) {
        this.AppScene = AppScene;

        ChoosePath = new(this);
        Download = new(this);
        CancelDownload = new(this);

        CLI = new(this);
        
    }
    public void ShowUI(bool Visible = false) {
        AppUI = new();

        AppUI.Text = "Tải truyện về từ TruyenQQ";
        AppUI.Size = new Size(600, 600);
        AppUI.StartPosition = FormStartPosition.CenterScreen;
        AppUI.FormBorderStyle = FormBorderStyle.FixedSingle;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.AppIcon.ico")) {
            Image AppIcon = Image.FromStream(Stream!);
            Stream!.Seek(0, SeekOrigin.Begin);
            AppUI.Icon = new Icon(Stream!);
        }
        
        AppUI.MaximizeBox = false;
        AppUI.BackColor = Color.FromArgb(21, 21, 21);
        AppUI.ForeColor = Color.White;
        AppUI.Font = new Font("Consolas", 10);
        AppUI.Visible = Visible;

        GoHomeButton = new();
        GoHome!.SetGoHomeButton(AppContext: AppUI, GoHomeButton: GoHomeButton!);
        GoHomeButton.Click += ClosedWindow;

        InputUrlField = new();
        InputUrl.SetInputUrl(AppContext: AppUI, InputUrlField: InputUrlField);

        ChoosePathButton = new();
        ChoosePath.SetChoosePathButton(AppContext: AppUI, ChoosePathButton: ChoosePathButton);

        ShowPathLog = new();
        ShowPath.SetShowPath(AppContext: AppUI, ShowPathLog: ShowPathLog);

        DownloadButton = new();
        Download.SetDownloadButton(AppContext: AppUI, DownloadButton: DownloadButton);

        DownloadLog = new();
        ResultLogDownload.SetLogDownload(AppContext: AppUI, ResultLog: DownloadLog);

        CancelButton = new();
        CancelDownload.SetCancelButton(AppContext: AppUI, CancelButton: CancelButton);

        AppUI.FormClosing += WindowClosing;
    }

    private void WindowClosing(object? sender, FormClosingEventArgs formClosingEventArgs) {
        AppScene.Visible = true;
    }

    private void ClosedWindow(object? sender, EventArgs eventArgs) {
        AppScene.Visible = true;
        AppUI!.Close();
    }
}