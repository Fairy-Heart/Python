using UI.buttons;

namespace UI;

/*
* RAILGUN DOWNLOADER UI VERSION
* BY REIM DEVELOPER
* CONTACT DISCORD: kaxtr
*
*/

public partial class App : Form {
    private readonly buttons.TruyenQQ TruyenQQ;
    private readonly buttons.Nettruyen Nettruyen;
    private Button? TruyenQQButton;
    private Button? NettruyenButton;
    public App() {
        Text = "Railgun Downloader V2";
        Icon = new System.Drawing.Icon("./icon.ico");
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Size = new Size(width: 600, height: 600);

        TruyenQQ = new buttons.TruyenQQ(this);
        TruyenQQButton = new Button();
        TruyenQQ.ShowButton(TruyenQQButton: TruyenQQButton);


        Nettruyen = new buttons.Nettruyen(this);
        NettruyenButton = new();
        Nettruyen.ShowNettruyenButton(NettruyenButton: NettruyenButton);
    }
}
