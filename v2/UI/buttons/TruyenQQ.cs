namespace UI.buttons;
using System;
using System.Windows.Forms;

/* 
* RAILGUN DOWNLOADER V2
* BY REIM DEVELOPER
* CONTACT DISCORD: kaxtr
*/

public partial class TruyenQQ {
    private readonly App AppContext;
    private dialog.QQDialog? QQDialog;
    public TruyenQQ(App AppContext) {
        this.AppContext = AppContext;
    }
    public void ShowButton(Button TruyenQQButton) {
        TruyenQQButton.Text = "Tải truyện về từ TruyenQQ";
        TruyenQQButton.Size = new Size(width: 250, height: 30);
        TruyenQQButton.Location = new Point(x: 165, y: 10);
        TruyenQQButton.FlatStyle = FlatStyle.Popup;
        
        TruyenQQButton.Click += ButtonClicked;


        QQDialog = new dialog.QQDialog(AppContext: AppContext);
        AppContext.Controls.Add(TruyenQQButton);
    }


    private void ButtonClicked(object? sender, EventArgs eventArgs) {
        AppContext.Visible = false;
        QQDialog!.ShowDialog(Visible: true);
    }
}