namespace RailgunDownloaderV3.Core.UI.Youtube;
using System.Windows.Forms;
using System.Drawing;
using Components;
using System.Reflection;
public partial class Youtube {
    public Form? AppUI;
    private readonly App AppScene;
    private Components.ResultComponent? ResultLogComponent;
    private Components.InputUrlComponent? InputUrlComponent;
    private Components.ChoosePathComponent? ChoosePathComponent;
    private Components.Download? Download;
    private Components.QualityChoose? QualityChoose;
    private Components.GoHome? GoHome;
    private Components.CancelDownload? CancelDownload;
    private readonly Components.SavePathComponent SavePathComponent;
    public RichTextBox? ResultLog;
    public RichTextBox? InputUrlBox;
    public RichTextBox? ChoosePathBox;
    private Button? SavePathButton;
    private Button? DownloadButton;
    public ComboBox? QualityChooseBox;
    private Button? GoHomeButton;
    private Button? CancelDownloadButton;
    public Youtube(App AppScene) {
        this.AppScene = AppScene;
        SavePathComponent = new(this);
    }
    public void ShowYoutubeDownload(bool Visible = false) {
        AppUI = new();
        AppUI.Size = new(width: 800, height: 600);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.AppIcon.ico")) {
            Image AppIcon = Image.FromStream(Stream!);
            Stream!.Seek(0, SeekOrigin.Begin);
            AppUI.Icon = new Icon(Stream!);
        }

        AppUI.BackColor = Color.FromArgb(21, 21, 21);
        AppUI.FormClosing += ClosingWindow;
        AppUI.StartPosition = FormStartPosition.CenterScreen;
        AppUI.FormBorderStyle = FormBorderStyle.FixedSingle;
        AppUI.Text = "Tải Playlist Youtube";
        AppUI.MaximizeBox = false;

        AppUI.Visible = Visible;

        ResultLog = new();
        ResultLogComponent = new();
        ResultLogComponent.SetResultComponents(AppContext: AppUI, ResultLog: ResultLog);

        InputUrlBox = new();
        InputUrlComponent = new();
        InputUrlComponent.SetInputUrlComponent(AppContext: AppUI, InputBox: InputUrlBox);

        ChoosePathBox = new();
        ChoosePathComponent = new();
        ChoosePathComponent.SetChoosePathComponent(AppContext: AppUI, ChoosePathField: ChoosePathBox);

        SavePathButton = new();
        SavePathComponent.SetSavePathComponent(AppContext: AppUI, SavePathButton: SavePathButton);

        DownloadButton = new();
        Download = new(this);
        Download.SetDownloadButton(AppContext: AppUI, DownloadButton: DownloadButton);

        QualityChooseBox = new();
        QualityChoose = new();
        QualityChoose.SetQualityChoose(AppContext: AppUI, QualityChoose: QualityChooseBox);

        GoHomeButton = new();
        GoHome = new(this);
        GoHome.SetGoHomeButton(AppContext: AppUI, GoHomeButton: GoHomeButton);

        CancelDownloadButton = new();
        CancelDownload = new(this);
        CancelDownload.SetCancelDownload(AppContext: AppUI, CancelButton: CancelDownloadButton);
    }

    private void ClosingWindow(object? sender, FormClosingEventArgs formClosingEventArgs) {
        AppScene.Visible = true;
    }
}