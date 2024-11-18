import requests
import os
import re
from bs4 import BeautifulSoup
from urllib.parse import urljoin
from concurrent.futures import ThreadPoolExecutor
import argparse


parser = argparse.ArgumentParser(description="Tải truyện từ TruyenQQ miễn phí")

subparsers = parser.add_subparsers(dest='command')

download_parser = subparsers.add_parser("download", help="Tải truyện từ URL")
download_parser.add_argument("url", type=str, help="Link truyện bạn muốn download.")

args = parser.parse_args()

if args.command == "download":
    base_url = args.url  # Lấy URL từ đối số

    if not re.match(r'https?://', base_url):
        print("URL của bạn không hợp lệ. Vui lòng kiểm tra lại")
        exit(1)

    image_class = "lazy"
    chapter_container_class = "works-chapter-list"

    response = requests.get(base_url)
    soup = BeautifulSoup(response.text, "html.parser")

    chapter_container = soup.find("div", class_=chapter_container_class)
    folder_name = soup.title.string

    folder_name = re.sub(r'[<>:"/\\|?*]', '', folder_name)

    chapter_links = chapter_container.find_all("a", href=True) if chapter_container else []

    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36',
        'Referer': f'{base_url}' 
    }

    def download_img(img_url, chapter_folder):
        img_name = os.path.basename(img_url.split("?")[0])  
        img_path = os.path.join(chapter_folder, img_name)  

        try:
            img_response = requests.get(img_url, headers=headers, timeout = 5, verify = False)
            img_response.raise_for_status()
            
            with open(img_path, "wb") as img_file:
                img_file.write(img_response.content)

            print(f"Đã tải: {img_name} vào thư mục {chapter_folder}")
        except Exception as e:
            print(f"Lỗi khi tải ảnh {img_url}: {e}")

    for chapter_link in chapter_links:
        chapter_name = chapter_link.text.strip()  
        if "Chương" in chapter_name:  
            chapter_name = chapter_name.replace(" ", "_")  
            chapter_name = ''.join(e for e in chapter_name if e.isalnum() or e in "_-")  
            chapter_folder = os.path.join(folder_name, chapter_name)  

            os.makedirs(chapter_folder, exist_ok=True)

            chapter_url = urljoin(base_url, chapter_link['href'])  
            print(f"Tải từ: {chapter_url}")

            chapter_response = requests.get(chapter_url)
            chapter_soup = BeautifulSoup(chapter_response.text, "html.parser")
            img_tags = chapter_soup.find_all("img", class_=image_class) 

            if not img_tags:
                print(f"Không tìm thấy ảnh trong {chapter_url}")
                continue

            img_urls = [urljoin(chapter_url, img_tag.get("src")) for img_tag in img_tags]

            with ThreadPoolExecutor(max_workers=50) as executor:
                futures = [executor.submit(download_img, img_url, chapter_folder) for img_url in img_urls]

            for future in futures:
                future.result()

    print("Đã hoàn tất tải tất cả ảnh.")
else:
    print("Lệnh không hợp lệ. Sử dụng 'railgun download <URL>' để tải truyện.")
