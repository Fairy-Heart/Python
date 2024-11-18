import tkinter as tk

def show_extract_progress(app: tk) -> tk.Text: 
    extract_progress = tk.Text(
        app,
        width = 40,
        height = 5
    )

    return extract_progress