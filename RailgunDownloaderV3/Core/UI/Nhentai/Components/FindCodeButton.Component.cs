/*
* Railgun Downloader - Version 3.0.0.
* Public repo: https://github.com/Fairy-Heart/RailgunDownloaderV3
*/

namespace RailgunDownloaderV3.Core.UI.Nhentai.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

public partial class FindByCodeButtonComponent {
    private readonly NhentaiUI AppScene;
    private readonly CLI_Component CLI_Component;
    private readonly IsTaskRun IsTaskRun;
    public FindByCodeButtonComponent(NhentaiUI AppScene) {
        this.AppScene = AppScene;
        CLI_Component = new(AppScene: AppScene);
        IsTaskRun = new();
    }
    public void SetFindByCodeButton(Form AppContext, Button FindByCodeButton) {
        ToolTip Placeholder = new();

        FindByCodeButton.Size = new Size(width: 50, height: 50);
        FindByCodeButton.FlatAppearance.BorderSize = 0;
        FindByCodeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        FindByCodeButton.FlatStyle = FlatStyle.Flat;
        FindByCodeButton.Location = new Point(x: 465 , y: 405);

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Search.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height: 50));

            FindByCodeButton.Image = Img;
            FindByCodeButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        Placeholder.SetToolTip(FindByCodeButton, "Tải Doujinshi từ Nhentai.net qua code");
        
        FindByCodeButton.Click += DownloadByCode;

        AppContext.Controls.Add(FindByCodeButton);
    }

    private void DownloadByCode(object? sender, EventArgs eventArgs) {
        string UrlValue = AppScene.InputUrlBox!.Text;
        string ChoosePathValue = AppScene.ChoosePathBox!.Text;

        if(string.IsNullOrWhiteSpace(UrlValue)) {
            MessageBox.Show(
                "Code của Doujinshi không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(!Directory.Exists(ChoosePathValue)) {
            MessageBox.Show(
                "Đường dẫn lưu Doujinshi không hợp lệ, bị chỉnh sửa hoặc đã bị xóa",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(!int.TryParse(UrlValue, out _)) {
            MessageBox.Show(
                "Nhentai code chỉ tồn tại dưới dạng số, vui lòng nhập code hợp lệ",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        
        if(IsTaskRun.TaskIsAlreadyRun("railgun_ntd_code") == true) {
            MessageBox.Show(
                "Tiến trình tải xuống hiện đang trong quá trình khởi chạy!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        AppScene.ResultLog!.Text = "";
        CLI_Component.CLI_Run($"--c \"{UrlValue}\" --p \"{ChoosePathValue}\"", @"Core\bin\railgun_ntd_code.exe");
    }
}