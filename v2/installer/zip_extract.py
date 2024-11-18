import zipfile
import tkinter as tk

def extract_zip(zip_path: str, 
        extract_path: str, 
        extract_progress: tk.Text
    ) -> None:

    extract_progress.config(state = "normal")
    extract_progress.delete("1.0", tk.END)
    extract_progress.insert(
            tk.END,
            "Đang giải nén các tệp của ứng dụng vào\n" + 
            f"{extract_path}\n"
    )
    extract_progress.update_idletasks()
    
    with zipfile.ZipFile(zip_path, 'r') as zip_file:
        # EXTRACT all files:
        zip_file.extractall(extract_path)

        extract_progress.insert(
            tk.END,
            f"Cài đặt hoàn tất vào đường dẫn:\n{extract_path}\n"
        )
        extract_progress.config(state = "disabled")