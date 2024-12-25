import tkinter as tk
import os
import ctypes
import sys
from progress_show import *
from zip_extract import *
from add_path import *
from create_shortcut import *
from tkinter import filedialog, messagebox


def is_admin() -> bool:
    try:
        return ctypes.windll.shell32.IsUserAnAdmin() != 0
    except:
        return False
    
def check_admin_perm() -> None:
    if not is_admin():
        messagebox.showerror(
            "Lỗi",
            "Vui lòng chạy trình cài đặt bằng quyền Admin!"
        )
        sys.exit()


check_admin_perm()
app = tk.Tk()


path_choose = tk.Entry(app,
                       width = 60,
                       font = ("Consolas", 11)
)
path_choose.pack(pady = 20)
path_choose.insert(
    tk.END, 
    "Hiện chưa chọn đường dẫn cài đặt..."
)

path_choose.config(state = "readonly")

extract_progress = show_extract_progress(app = app)
extract_progress.place(x = 58, y = 60)
extract_progress.insert("1.0", "Hiện chưa cài đặt ứng dụng...")
extract_progress.config(state = "disabled")



# default app property
def app_init() -> None:
    app.title("Railgun DownloaderV2 Installer")
    app.eval("tk::PlaceWindow . center")
    app.resizable(False, False)
    app.geometry("600x250")
    

# Show a directory install application
selected_path: str = None
def show_directory_install() -> None:
    global selected_path
    directory_path = filedialog.askdirectory(
        title = "Chọn đường dẫn cài đặt ứng dụng"
    )
    if not directory_path:
        messagebox.showwarning(
            title = "Cảnh báo",
            message = (
                "Bạn chưa chọn đường dẫn cài đặt ứng dụng\n" + 
                "Vui lòng chỉ định một đường dẫn hợp lệ!"
            )
        )
        return
        
    if directory_path:
        selected_path = directory_path
        path_choose.config(state = "normal")
        path_choose.delete(0, tk.END)
        path_choose.insert(0, directory_path)
        path_choose.config(state = "readonly")


# Select a directory button
def select_path_to_install() -> None:
    install_button = tk.Button(
        app, text = "Chọn đường dẫn cài đặt",
        command = show_directory_install
    )
    install_button.place(x = 405, y = 60)

# install app command
def install_app() -> None:
    if selected_path is None:
        messagebox.showinfo(
            title = "Thông báo",
            message = (
                "Bạn chưa chọn đường dẫn\n" +
                "cài đặt ứng dụng!" +
                "Vui lòng chọn đường dẫn hợp lệ"
            )
        )
        return

    if not os.path.exists(selected_path):
        messagebox.showwarning(
            title = "Cảnh báo",
            message = (
                "Đường dẫn cài đặt bạn vừa lựa chọn\n" + 
                "không hợp lệ, bị xóa hoặc trình cài đặt\n" +
                "không có quyền truy cập"
            )
        )
        return
    
    extract_zip("./RailgunDownloaderV2.zip", selected_path, extract_progress = extract_progress)
    add_exe_to_path(selected_path)
    create_short_cut(selected_path)
    

def install_app_button() -> None:
    install_button = tk.Button(
        app,
        text = "Cài đặt ứng dụng",
         command = install_app
    )
    install_button.place(x = 440, y = 100)


def start_app() -> None:
    app_init()
    select_path_to_install()
    install_app_button()
    app.mainloop()

start_app()
