# Railgun Downloader - Version 3.0.0
# Nhentai Downloader Helper
import argparse
import os
import requests
import io
import sys
from concurrent.futures import ThreadPoolExecutor
from bs4 import BeautifulSoup
from pathlib import Path


headers: dict[str, str] = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36'
}

parser: argparse.ArgumentParser = argparse.ArgumentParser()

def clean_console(exc_type, exc_value, exc_traceback) -> None:
    print("")

sys.excepthook = clean_console
sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding = "utf-8")

def download(code: str, directory_path: str) -> None:
    web_url = f"https://nhentai.net/g/{code}/"
    print(f"Tải xuống doujinshi: {web_url}..", flush = True)
    response = requests.get(web_url)
    soup = BeautifulSoup(response.text, "html.parser")

    folder_name = soup.find("h3", id = "gallery_id")

    if not folder_name:
        print(f"Code {code} không tồn tại trên Nhentai.net!", flush = True)
        return

    dir_name = str(folder_name.text).replace("#", "")
    full_dir_path = os.path.abspath(os.path.join(directory_path, dir_name))

    if os.path.isdir(full_dir_path):
        print(f"Doujinshi với code {dir_name} đã được tải rồi, bạn không cần tải nữa!")
        return
    
    print("Tạo folder lưu doujinshi..", flush = True)
    dir_path = Path(full_dir_path)
    dir_path.mkdir()

    print("Tìm các hình ảnh..")
    div_container = soup.find("div", class_ = "thumbs")
    img_tags = div_container.find_all("img", class_ = "lazyload")

    print("Chuẩn bị tải xuống..", flush = True)
    for img in img_tags:
        img_url = img.get("data-src")
        base_name = os.path.basename(img_url)
        save_path = os.path.join(full_dir_path, base_name)
        response = requests.get(img_url, headers = headers)

        print(f"Tải xuống hình ảnh với tên {base_name} vào {save_path}", flush = True)

        with open(save_path, "wb") as img_file:
            img_file.write(response.content)

    print(f"Tải xuống hoàn tất\nDoujinshi Code: {folder_name.text}\nVào đường dẫn {full_dir_path}", flush = True)

parser.add_argument(
    "--c",
    type = str,
    required = True
)
parser.add_argument(
    "--p",
    type = str,
    required = True
)

argument = parser.parse_args()

try:
    with ThreadPoolExecutor(max_workers = 50) as Executor:
        Executor.submit(download, argument.c, argument.p)
except Exception as e:
    print(f"Không thể tải xuống doujinshi, gặp lỗi {e}")
