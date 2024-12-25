namespace RailgunDownloaderV3.Core.UI.Nettruyen;
using System.Windows.Forms;
using System.Reflection;

public partial class NetTruyenUI {
    private Form? AppUI;
    private readonly App AppScene;
    private Button? GoHomeButton;
    private Buttons.GoHomeButton? GoHome;
    public RichTextBox? InputArea;
    private TextInput.URL? URLInput;
    private Log.ChoosePathLog? ShowChoosePath;
    public RichTextBox? PathChoose;
    public Button? DownloadButton;
    private Buttons.Download? Download;
    private Buttons.ChoosePath? ChoosePath;
    public Button? ChoosePathButton;
    public RichTextBox? DownloadLog;
    private Log.ResultLogDownload? ResultLogDownload;
    private Buttons.CancelDownload? CancelDownload;
    private Button? CancelDownloadButton;
    
    public NetTruyenUI(App AppScene) {
        this.AppScene = AppScene;
    }
    public void ShowUI(bool Visible = false) {
        AppUI = new();
        AppUI.Text = "Tải truyện về từ Net Truyen";
        AppUI.Size = new Size(width: 600, height: 600);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.AppIcon.ico")) {
            Image AppIcon = Image.FromStream(Stream!);
            Stream!.Seek(0, SeekOrigin.Begin);
            AppUI.Icon = new Icon(Stream!);
        }

        AppUI.StartPosition = FormStartPosition.CenterScreen;
        AppUI.MaximizeBox = false;
        AppUI.FormBorderStyle = FormBorderStyle.FixedSingle;
        AppUI.BackColor = Color.FromArgb(21, 21, 21);

        AppUI.FormClosing += WindowClosing;

        GoHomeButton = new();
        GoHome = new();
        GoHome.SetGoHomeButton(AppContext: AppUI, GoHomeButton: GoHomeButton);
        GoHomeButton.Click += GoBackHome;

        
        URLInput = new TextInput.URL();
        InputArea = new();
        URLInput.SetURLInputArea(AppContext: AppUI, InputArea: InputArea);

        PathChoose = new();
        ShowChoosePath = new Log.ChoosePathLog();
        ShowChoosePath.SetShowChoosePath(AppContext: AppUI, ChoosePathArea: PathChoose);

        DownloadButton = new();
        Download = new Buttons.Download(this);
        Download.SetChoosePathButton(AppContext: AppUI, ChoosePathButton: DownloadButton);

        ChoosePathButton = new();
        ChoosePath = new Buttons.ChoosePath(this);
        ChoosePath.SetChoosePath(AppContext: AppUI, ChoosePathButton: ChoosePathButton);

        DownloadLog = new();
        ResultLogDownload = new Log.ResultLogDownload();
        ResultLogDownload.SetLogDownload(AppContext: AppUI, ResultLog: DownloadLog);
        
        CancelDownloadButton = new();
        CancelDownload = new(this);
        CancelDownload.SetCancelDownloadButton(AppContext: AppUI, CancelButton: CancelDownloadButton);
    

        AppUI.Visible = Visible;
    }

    private void WindowClosing(object? sender, FormClosingEventArgs formClosingEventArgs) {
        AppScene.Visible =  true;
    } 
    
    private void GoBackHome(object? sender, EventArgs eventArgs) {
        AppUI!.Close();
    } 
}