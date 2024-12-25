// # RAILGUN DOWNLOADER CLI CORE VERSION 3.0.0
//
// # TruyenQQ.go  By Reim developer
//
// You can also find other version of this project here:
//
// https://github.com/Fairy-Heart/RailgunDownloader
package core

import (
	"fmt"
	"io"
	"net/http"
	"os"
	"path"
	"path/filepath"
	"strings"
	"sync"
	"time"

	"github.com/gocolly/colly"
)

// Function to download all images from chapter on TruyenQQ
func TruyenQQDownload(url_web string) {

	// Channel for optimal performance
	channels_link := make(chan string)

	var wait_group sync.WaitGroup

	chapter_colly := colly.NewCollector()
	chapter_colly.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36"

	img_urls_colly := colly.NewCollector()
	img_urls_colly.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36"

	var real_sub_dir_path string

	img_urls_colly.OnHTML("img.lazy", func(e *colly.HTMLElement) {
		img_links := e.Attr("src")
		img_name_parser := strings.Split(img_links, "?")[0]
		img_name_parser = path.Base(img_name_parser)

		// Setup time out
		client := &http.Client{
			Timeout: time.Second * 30,
		}

		request, _ := http.NewRequest("GET", img_links, nil)

		request.Header.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")
		request.Header.Set("Referer", url_web)
		request.Header.Set("Accept", "image/webp,image/apng,image/*,*/*;q=0.8")
		request.Header.Set("Accept-Encoding", "gzip, deflate, br")

		response, response_err := client.Do(request)
		if response_err != nil {
			fmt.Printf("Không thể gửi yêu cầu tải xuống hình ảnh với lỗi: %s\n", response_err)
		}

		defer response.Body.Close()

		img, _ := os.Create(filepath.Join(real_sub_dir_path, img_name_parser))
		defer img.Close()

		_, write_file_img_err := io.Copy(img, response.Body)

		if write_file_img_err != nil {
			fmt.Printf("Không thể tải xuống hình ảnh %s với lỗi %s", img_name_parser, write_file_img_err)
		}

		fmt.Printf("Tải xuống %s vào %s\n", img_name_parser, real_sub_dir_path)
	})

	go func() {
		for web_url := range channels_link {

			wait_group.Add(1)

			// Don't care this warning if has one.
			defer wait_group.Done()

			download_error := img_urls_colly.Visit(web_url)

			if download_error != nil {
				fmt.Printf("Đã có lỗi xảy ra khi tải xuống truyện của bạn: %s\n", download_error)
			}

		}
	}()

	var folder_name string
	chapter_colly.OnHTML("h1[itemprop=name]", func(e *colly.HTMLElement) {
		folder_name = e.Text
	})

	var dir_path string
	// Handler to find all chapter links and send them to the channel
	chapter_colly.OnHTML("div.works-chapter-list a[href]", func(e *colly.HTMLElement) {
		web_url_parse := e.Request.AbsoluteURL(e.Attr("href"))

		channels_link <- web_url_parse

		var sub_folder_name string = e.Text

		current_path, _get_path_failed := os.Getwd()
		if _get_path_failed != nil {
			fmt.Printf("Không thể lấy đường dẫn tới %s với lỗi %s\n", current_path, _get_path_failed)
			return
		}

		dir_path = path.Join(current_path, folder_name)
		create_dir_err := os.MkdirAll(current_path+"\\"+folder_name, os.ModePerm)

		if create_dir_err != nil {
			fmt.Printf("Không thể tạo folder %s với lỗi %s\n", folder_name, create_dir_err)
			return
		}

		real_dir_path, get_dir_path_err := filepath.Abs(dir_path)
		if get_dir_path_err != nil {
			fmt.Printf("Không thể lấy đường dẫn tải truyện chính với lỗi %s\n", get_dir_path_err)
			return
		}

		create_sub_dir_err := os.MkdirAll(real_dir_path+"\\"+sub_folder_name, os.ModePerm)
		if create_sub_dir_err != nil {
			fmt.Printf("Không thể tạo sub-folder %s với lỗi %s\n", folder_name, create_sub_dir_err)
			return
		}

		var get_sub_dir_err error
		real_sub_dir_path, get_sub_dir_err = filepath.Abs(dir_path + "\\" + sub_folder_name)

		if get_sub_dir_err != nil {
			fmt.Printf("Không thể tải xuống hình ảnh vào %s", real_dir_path)
		}

	})

	// Close the channel when scraping is done
	chapter_colly.OnScraped(func(r *colly.Response) {
		close(channels_link)
	})

	// Start scraping the main page that contains the list of chapters
	fmt.Printf("Tải xuống hình ảnh từ: %s\n", url_web)

	visit_web_err := chapter_colly.Visit(url_web)

	if visit_web_err != nil {
		fmt.Printf("Tải xuống truyện từ URL %s thất bại với lỗi: %s\n", url_web, visit_web_err)
		return
	}

	wait_group.Wait()

	fmt.Printf("Hoàn tất tải xuống toàn bộ chương truyện vào %s\n", dir_path)
}
