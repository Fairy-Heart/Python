import os
import winshell
from win32com.client import Dispatch

def create_short_cut(exe_path: str) -> None:
    desktop_path = winshell.desktop()
    shortcut_path = os.path.join(desktop_path, "RailgunDownloaderV2.lnk")

    full_path = os.path.join(
        exe_path,
        "RailgunDownloaderV2",
        "RailgunDownloaderV2.exe"
    )
    
    shell = Dispatch("WScript.Shell")
    shortcut = shell.CreateShortcut(shortcut_path)

    shortcut.TargetPath = full_path
    shortcut.WorkingDirectory = os.path.dirname(full_path)
    shortcut.Description = "Railgun Downloader V2"
    shortcut.Save()