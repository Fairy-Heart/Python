# All lib we need
import yt_dlp
import argparse
import os
import sys
import io


# parser argument
parser: argparse.ArgumentParser = argparse.ArgumentParser()

def clean_console(exc_type, exc_value, exc_traceback) -> None:
    print("")

sys.excepthook = clean_console
sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding = "utf-8")

class LogDebug:
    def debug(self, msg):
        pass

    def warning(self, msg):
        pass

    def error(self, msg):
        print("Đã có lỗi xảy ra với việc tải xuống Playlist của bạn, vui lòng kiểm tra lại đường dẫn\n")

def ProcessHook(d: any) -> None:
    if d["status"] == "downloading":
       print(f"Đã tải về {d["_percent_str"]} của {d["_total_bytes_str"]} với tốc độ {d["_speed_str"]}\nThời gian còn lại: {d["_eta_str"]}\n", flush = True)

def YoutubePlaylistDownloader(playlist_url: str, save_path: str, quality: str) -> None:
    download_option: dict[str, any] = {
        "format": quality,
        "outtmpl":  os.path.join(save_path, '%(title)s.%(ext)s'),
        "noplaylist": False,
        "logger": LogDebug(),
        "quiet": False,
        "logtostderr": False,
        "no_warnings": True,
        "progress_hooks": [ProcessHook],
    }

    with yt_dlp.YoutubeDL(download_option) as youtube:
        youtube.download([playlist_url])


parser.add_argument(
    "--u",
    type = str,
    required = True 
)
parser.add_argument(
    "--p",
    type = str,
    required = True
)
parser.add_argument(
    "--q",
    type = str,
    required = True
)

argument = parser.parse_args()

try:
    YoutubePlaylistDownloader(argument.u, argument.p, argument.q)
except Exception as e:
    print(e)