namespace UI.dialog;
using System;
using System.Windows.Forms;

public class NettruyenDialog {
    private App? AppContext;
    public RichTextBox? URLField;
    public RichTextBox? PathField;
    private Button? ChooseButton;
    private Button? DownloadButton;
    private buttons.NettruyenDownload? NettruyenDownload;
    public NettruyenDialog(App AppContext) {
        this.AppContext =  AppContext;
    }
    public void ShowNettruyenDialog(bool Visible = false) {
        Form Dialog = new();
        URLField = new();
        PathField = new();
        ChooseButton = new();
        DownloadButton = new ();

        NettruyenDownload = new buttons.NettruyenDownload(this);

        Dialog.Text = "Tải truyện về từ NetTruyen";
        Dialog.StartPosition = FormStartPosition.CenterScreen;
        Dialog.Size = new Size(width: 600, height: 600);
        Dialog.FormBorderStyle = FormBorderStyle.Fixed3D;
        Dialog.MaximizeBox = false;

        Dialog.FormClosed += ShowMainApp;

        ShowInputURL(App: Dialog, URLField: URLField);
        ShowChoosePath(App: Dialog, PathField: PathField);
        ChoosePathButton(App: Dialog, ChooseButton: ChooseButton);
        ShowDownloadButton(App: Dialog, DownloadButton: DownloadButton);

        Dialog.Visible = Visible;
    }

    private void ShowInputURL(Form App, RichTextBox URLField) {
        Label Description = new();
        Description.Text = "Nhập link truyện:";
        Description.Font = new Font("Consolas", 10);
        Description.BorderStyle = BorderStyle.Fixed3D;
        Description.Size = new Size(width: 150, height: 20);
        Description.Location = new Point(x: 30, y: 140);

        URLField.Size = new Size(width: 350, height: 50);
        URLField.Font = new Font("Consolas", 10);
        URLField.Location = new Point(x: 30, y: 170);
        URLField.BorderStyle = BorderStyle.Fixed3D;

        App.Controls.Add(URLField);
        App.Controls.Add(Description);
    }

    private void ShowChoosePath(Form App, RichTextBox PathField) {
        PathField.Text = "Chưa chọn đường dẫn lưu truyện";
        PathField.Font = new Font("Consolas", 10);
        PathField.BorderStyle = BorderStyle.Fixed3D;
        PathField.Size = new Size(width: 350, height: 50);
        PathField.Location = new Point(x: 30, y: 250);

        App.Controls.Add(PathField);
    }

    private void ChoosePathButton(Form App, Button ChooseButton) {
        ChooseButton.Text = "Chọn đường dẫn lưu truyện";
        ChooseButton.FlatStyle = FlatStyle.Popup;
        ChooseButton.Size = new Size(width: 180, height: 30);
        ChooseButton.Location = new Point(x: 385, y: 270);

        ChooseButton.Click += ChoosePathButtonClicked;

        App.Controls.Add(ChooseButton);
    }

    private void ChoosePathButtonClicked(object? sender, EventArgs eventArgs) {
        using FolderBrowserDialog ChooseFolder = new();
        ChooseFolder.Description = "Chọn đường dẫn lưu truyện";
        ChooseFolder.ShowNewFolderButton = true;

        if(ChooseFolder.ShowDialog() == DialogResult.OK) {
            PathField!.Text = ChooseFolder.SelectedPath;
        }
    }

    private void ShowDownloadButton(Form App, Button DownloadButton) {
        DownloadButton.Text = "Tải về truyện";
        DownloadButton.Size = new Size(width: 250, height: 30);
        DownloadButton.FlatStyle = FlatStyle.Popup;
        DownloadButton.Location = new Point(x: 30, y: 320);

        DownloadButton.Click += NettruyenDownload!.NettruyenDownloadProcess;

        App.Controls.Add(DownloadButton);
    }

    private void ShowMainApp(object? sender, FormClosedEventArgs eventArgs) {
        AppContext!.Visible = true;
    }
}