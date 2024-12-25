namespace UI.dialog;
using System;
using System.Windows.Forms;
using UI.buttons;

/* 
* RAILGUN DOWNLOADER V2
* BY REIM DEVELOPER
* CONTACT DISCORD: kaxtr
*/


public partial class QQDialog {

    public RichTextBox? URLField;
    public RichTextBox? PathField;
    private Button? ChoosePathButton;
    private Button? DownloadButton;
    private QQDownload? QQDownload;
    private App AppContext;
    public QQDialog(App AppContext) {
        this.AppContext = AppContext;
    }
    public void ShowDialog(bool Visible = false) {
        Form Dialog = new Form();
        URLField = new();
        PathField = new();

        QQDownload = new buttons.QQDownload(this);

        Dialog.Text = "Tải về từ TruyenQQ";
        Dialog.StartPosition = FormStartPosition.CenterScreen;
        Dialog.MaximizeBox = false;
        Dialog.FormBorderStyle = FormBorderStyle.FixedSingle;
        Dialog.Size = new Size(width: 600, height: 600);

        ShowInputURL(AppContext: Dialog, URLField: URLField!);

        ShowChoosePath(AppContext: Dialog, PathField: PathField!);

        ChoosePathButton = new Button();
        ShowChoosePathButton(AppContext: Dialog, ChoosePathButton: ChoosePathButton);

        DownloadButton = new Button();
        ShowDownloadButton(AppContext: Dialog, DownloadButton: DownloadButton);


        Dialog.FormClosed += ShowMainApp;
        Dialog.Visible = Visible;
    }

    private void ShowInputURL(Form AppContext, RichTextBox URLField) {
        Label Description = new Label();
        Description.Text = "Nhập link truyện:";
        Description.Size = new Size(width: 150, height: 20);
        Description.Location = new Point(x: 30, y: 170);
        Description.BorderStyle = BorderStyle.Fixed3D;
        Description.Font = new Font("Consolas", 10);

        URLField.Size = new Size(width: 350, height: 50);
        URLField.Location = new Point(x: 30, y: 200);
        URLField.Font = new Font("Consolas", 10);
        URLField.BorderStyle = BorderStyle.Fixed3D;

        AppContext.Controls.Add(URLField);
        AppContext.Controls.Add(Description);
    }

    private void ShowChoosePath(Form AppContext, RichTextBox PathField) {
        PathField.Size = new Size(width: 350, height: 50);
        PathField.Location = new Point(x: 30, y: 270);
        PathField.Font = new Font("Consolas", 10);
        PathField.Text = "Chưa chọn đường dẫn lưu truyện...";
        PathField.ReadOnly = true;
        PathField.BorderStyle = BorderStyle.Fixed3D;

        AppContext.Controls.Add(PathField);
    }

    private void ShowChoosePathButton(Form AppContext, Button ChoosePathButton) {
        ChoosePathButton.Size = new Size(width: 180, height: 30);
        ChoosePathButton.Text = "Chọn đường dẫn lưu truyện";
        ChoosePathButton.Location = new Point(x: 390, y: 290);
        ChoosePathButton.FlatStyle = FlatStyle.Popup;

        ChoosePathButton.Click += ChoosePathButtonClicked;

        AppContext.Controls.Add(ChoosePathButton);
    }

    private void ChoosePathButtonClicked(object? sender, EventArgs eventArgs) {
        using FolderBrowserDialog FolderDialog = new();
        FolderDialog.Description = "Chọn đường dẫn lưu truyện";
        FolderDialog.ShowNewFolderButton = true;

        if (FolderDialog.ShowDialog() == DialogResult.OK) {
            PathField!.Text = FolderDialog.SelectedPath;
        }
    }

    private void ShowDownloadButton(Form AppContext, Button DownloadButton) {
        DownloadButton.Text = "Tải về truyện!";
        DownloadButton.Size = new Size(width: 180, height: 30);
        DownloadButton.Location = new Point(x: 30, y: 330);
        DownloadButton.FlatStyle = FlatStyle.Popup;

        DownloadButton.Click += QQDownload!.Download;

        AppContext.Controls.Add(DownloadButton);
    }

    private void ShowMainApp(object? sender, FormClosedEventArgs eventArgs) {
        AppContext!.Visible = true;   
    }
}