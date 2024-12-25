/*
* Railgun Downloader - Version 3.0.0
* Download.Component.cs
* Github repo: https://github.com/Fairy-Heart/RailgunDownloader
*/

namespace RailgunDownloaderV3.Core.UI.Youtube.Components;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

/// <summary>
/// Setup download all Youtube Playlist with customize quality and format file 
/// </summary>
public partial class Download {
    private readonly Youtube YoutubeUIScene;
    private readonly CLIRunComponent CLI;
    public Download(Youtube YoutubeUIScene) {
        this.YoutubeUIScene = YoutubeUIScene;
        CLI = new(YoutubeUIScene: YoutubeUIScene);
    }
    /// <summary>
    /// Front-end: Download Button front-end
    /// </summary>
    /// <param name="AppContext"></param>
    /// <param name="DownloadButton"></param>
    public void SetDownloadButton(Form AppContext, Button DownloadButton) {
        DownloadButton.Size = new Size(width: 50, height: 50);
        DownloadButton.Location = new Point(x: 550, y: 400);
        DownloadButton.FlatAppearance.BorderSize = 0;
        DownloadButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
        DownloadButton.FlatStyle = FlatStyle.Flat;

        using(var Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RailgunDownloaderV3.Core.UI.resource.Download.png")) {
            Image OriginalImg = Image.FromStream(Stream!);
            Bitmap Img = new(original: OriginalImg, new Size(width: 50, height :50));

            DownloadButton.Image = Img;
            DownloadButton.ImageAlign = ContentAlignment.MiddleCenter;
        }

        DownloadButton.Click += DownloadPlaylist;

        AppContext.Controls.Add(DownloadButton);
    }
    /// <summary>
    /// The playlist will be downloaded when the button is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    private void DownloadPlaylist(object? sender, EventArgs eventArgs) {
        // Get playlist URL and SavePath:
        string UrlInput = YoutubeUIScene.InputUrlBox!.Text;
        string SavePath = YoutubeUIScene.ChoosePathBox!.Text;

        if(string.IsNullOrWhiteSpace(UrlInput)) {
            MessageBox.Show(
                "URL của bạn không được để trống",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(!Directory.Exists(SavePath)) {
            MessageBox.Show(
                "Đường dẫn tệp bạn chọn không hợp lệ, vui lòng chọn lại",
                "Thông báo",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
            );
            return;
        }

        int QualityChoose = YoutubeUIScene.QualityChooseBox!.SelectedIndex;
        
        switch(QualityChoose) {
            // User chooses the best quality
            case 0:
            CLI.RunDownloadHelper(
            PlaylistUrl: UrlInput,
            SavePath: SavePath,
            "best"
            );
            break;

            // User chooses the worst quality
            case 1:
            CLI.RunDownloadHelper(
                PlaylistUrl: UrlInput,
                SavePath: SavePath,
                "worst"
            );
            break;
            
            // Video only, with best quality
            case 2:
            CLI.RunDownloadHelper(
                PlaylistUrl: UrlInput,
                SavePath: SavePath,
                "bestvideo"
            );
            break;

            // Video only, with worst quality
            case 3:
            CLI.RunDownloadHelper(
                PlaylistUrl: UrlInput,
                SavePath: SavePath,
                "worstvideo"
            );
            break;

            // Audio only, with best quality
            case 4:
            CLI.RunDownloadHelper(
                PlaylistUrl: UrlInput,
                SavePath: SavePath,
                "bestaudio"
            );
            break;

            // Audio only, with worst quality
            case 5:
            CLI.RunDownloadHelper(
                PlaylistUrl: UrlInput,
                SavePath: SavePath,
                "worstaudio"
            );
            break;
        }
    }
}