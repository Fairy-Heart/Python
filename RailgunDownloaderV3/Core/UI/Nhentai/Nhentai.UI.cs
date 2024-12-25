/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai;
using System.Windows.Forms;
using System.Drawing;
using RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Reflection;

public partial class NhentaiUI {
    public readonly App AppScene;
    private GohomeComponent? GohomeComponent;
    private ResultLogComponent? ResultLogComponent;
    private ChoosePathComponent? ChoosePathComponent;
    private ChoosePathButtonComponent? ChoosePathButtonComponent;
    private FindByCodeButtonComponent? FindByCodeButtonComponent;
    private InputUrlComponent? InputUrlComponent;
    private DownloadButtonComponent? DownloadButtonComponent;
    private CancelDownloadComponent? CancelDownloadComponent;
    public Form? AppUI;

    private Button? GohomeButton;
    private Button? ChoosePathButton;
    private Button? DownloadButton;
    private Button? FindByCodeButton;
    private Button? CancelDownloadButton;
    public RichTextBox? ResultLog;
    public RichTextBox? ChoosePathBox;
    public RichTextBox? InputUrlBox;
    
    public NhentaiUI(App AppScene) {
        this.AppScene = AppScene;
     
    }
    public void ShowNhentaiUI(bool Visible = true) {
        AppUI = new();
        AppUI.Size = new Size(width: 600, height: 600);
        AppUI.FormBorderStyle = FormBorderStyle.FixedSingle;
        AppUI.MaximizeBox = false;
        AppUI.StartPosition = FormStartPosition.CenterScreen;
        AppUI.Text = "Tải doujinshi từ Nhentai.net";
        AppUI.BackColor = Color.FromArgb(21, 21, 21);
        AppUI.Font = new Font("Consolas", 10);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.AppIcon.ico")) {
            Image OriginalImg = Image.FromStream(Stream!);
            
            Stream!.Seek(0, SeekOrigin.Begin);
            AppUI.Icon = new Icon(Stream!);
        }

        AppUI.Visible = Visible;

        GohomeComponent = new(this);
        GohomeButton = new();
        GohomeComponent.SetGohomeButton(AppContext: AppUI, GohomeButton: GohomeButton);

        ResultLogComponent = new();
        ResultLog = new();
        ResultLogComponent.SetResultLog(AppContext: AppUI, ResultLog: ResultLog);

        ChoosePathComponent = new();
        ChoosePathBox = new();
        ChoosePathComponent.SetShowChoosePath(AppContext: AppUI, ChoosePath: ChoosePathBox);

        ChoosePathButtonComponent = new(this);
        ChoosePathButton = new();
        ChoosePathButtonComponent.SetChoosePathButton(AppContext: AppUI, ChoosePathButton: ChoosePathButton);

        InputUrlComponent = new();
        InputUrlBox = new();
        InputUrlComponent.SetInputUrl(AppContext: AppUI, InputUrl: InputUrlBox);

        DownloadButtonComponent = new(this);
        DownloadButton = new();
        DownloadButtonComponent.SetDownloadButton(AppContext: AppUI, DownloadButton: DownloadButton);

        FindByCodeButtonComponent = new(this);
        FindByCodeButton = new();
        FindByCodeButtonComponent.SetFindByCodeButton(AppContext: AppUI, FindByCodeButton: FindByCodeButton);

        CancelDownloadComponent = new(this);
        CancelDownloadButton = new();
        CancelDownloadComponent.SetCancelDownload(AppContext: AppUI, CancelButton: CancelDownloadButton);

        AppUI.FormClosing += ShowMainWindow;
        AppUI.Shown += ShowNotification;
    }

    private void ShowMainWindow(object? sender, FormClosingEventArgs formClosingEventArgs) {
        AppScene.Visible = true;
    }

    private void ShowNotification(object? sender, EventArgs eventArgs) {
            MessageBox.Show(
            "Bạn cần tải về ứng dụng Cloudflare Warp, hay còn gọi là 1.1.1.1 để có thể tải xuống doujinshi từ Nhentai.net!",
            "Lưu Ý",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        );
    }
}