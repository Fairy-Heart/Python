namespace UI.buttons;
using System;
using System.Windows.Forms;

public partial class NettruyenDownload {
    private dialog.NettruyenDialog? NettruyenDialog;
    private cmd.NetTruyenCmd NettruyenCommand = new();

    public NettruyenDownload(dialog.NettruyenDialog NettruyenDialog) {
        this.NettruyenDialog = NettruyenDialog;
    }

    public void NettruyenDownloadProcess(object? sender, EventArgs eventArgs) {
        string ChoosePathValue = NettruyenDialog!.PathField!.Text;
        string InputURLValue = NettruyenDialog!.URLField!.Text;

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
                "Đường dẫn bạn chọn không hợp lệ, bị xóa hoặc không có quyền truy cập",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        NettruyenCommand.NettruyenDownload(
            URL: InputURLValue,
            SavePath: ChoosePathValue
        );
    }
}