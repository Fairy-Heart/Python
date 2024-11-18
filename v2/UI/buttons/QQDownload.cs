namespace UI.buttons;
using System;
using System.Windows.Forms;
using UI.dialog;

public partial class QQDownload {
    private QQDialog? QQDialog;
    private cmd.TruyenQQCmd? Command = new();
    public QQDownload(QQDialog DialogContext) {
        this.QQDialog = DialogContext;
    }
    

    public void Download(object? sender, EventArgs eventArgs) {
        string ChoosePathValue = QQDialog!.PathField!.Text;
        string InputURLValue = QQDialog!.URLField!.Text;
 
        if(string.IsNullOrEmpty(InputURLValue)) {
            MessageBox.Show(
                "URL bạn nhập không tồn tại!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        if(!Directory.Exists(ChoosePathValue)) {
            MessageBox.Show(
                "Đường dẫn tới thư mục lưu truyện không tồn tại!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        Command!.Download(
            URL: InputURLValue,
            SavePath: ChoosePathValue
        );
    }
}