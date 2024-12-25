namespace UI.buttons;
using System;
using System.Windows.Forms;

public partial class Nettruyen {
    private readonly App AppContext;
    private dialog.NettruyenDialog? NettruyenDialog;
    public Nettruyen(App AppContext) {
        this.AppContext = AppContext;
    }

    public void ShowNettruyenButton(Button NettruyenButton) {
        NettruyenButton.Text = "Tải truyện về từ Nettruyen";
        NettruyenButton.Size = new Size(width: 250, height: 30);
        NettruyenButton.Location = new Point(x: 165, y: 50);
        NettruyenButton.FlatStyle = FlatStyle.Popup;

        NettruyenDialog = new dialog.NettruyenDialog(AppContext: AppContext);

        NettruyenButton.Click += ShowButtonClicked;
        
        AppContext.Controls.Add(NettruyenButton);
    }


    private void ShowButtonClicked(object? sender, EventArgs eventArgs) {
        AppContext.Visible = false;
        NettruyenDialog!.ShowNettruyenDialog(Visible: true);
    }
}