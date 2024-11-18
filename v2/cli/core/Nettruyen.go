package core

/******************************************
*										  *
*  NET TRUYEN DOWNLOADER                  *
*  RAILGUN DOWNLOADER V2                  *
*  BY REIM DEVELOPER					  *
*  CONTACT DISCORD USERNAME: kaxtr 		  *
*										  *
******************************************/

import (
	"RailgunDownloaderV2/etc"
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

func NettruyenDownload(_url_web string) {

	// Channel for optimal performance
	_channels_link := make(chan string)

	var _wait_group sync.WaitGroup

	_chapter_colly := colly.NewCollector()
	_chapter_colly.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36"

	_img_urls_colly := colly.NewCollector()
	_img_urls_colly.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36"

	var _real_sub_dir_path string

	_img_urls_colly.OnHTML("div.reading div.reading-detail.box_doc img.lozad", func(e *colly.HTMLElement) {
		_img_links := e.Attr("data-src")
		_img_name_parser := strings.Split(_img_links, "?")[0]
		_img_name_parser = path.Base(_img_name_parser)

		client := &http.Client{
			Timeout: time.Second * 30,
		}

		_request, _ := http.NewRequest("GET", _img_links, nil)

		_request.Header.Set("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36")
		_request.Header.Set("Referer", _url_web)
		_request.Header.Set("Accept", "image/webp,image/apng,image/*,*/*;q=0.8")
		_request.Header.Set("Accept-Encoding", "gzip, deflate, br")

		_response, _response_err := client.Do(_request)
		if _response_err != nil {
			etc.Error("[ERR!] Can't send request!")
		}

		defer _response.Body.Close()

		_img, _ := os.Create(filepath.Join(_real_sub_dir_path, _img_name_parser))
		defer _img.Close()

		_, err := io.Copy(_img, _response.Body)
		if err != nil {
			fmt.Printf("%s %s\n", err, _img_name_parser)
		}

		etc.Download("Save %s as %s", _img_name_parser, _real_sub_dir_path)
	})

	go func() {
		for _web_url := range _channels_link {

			_wait_group.Add(1)

			defer _wait_group.Done()

			err := _img_urls_colly.Visit(_web_url)

			if err != nil {
				etc.Error("Please check your Nettruyen URL!")
			}

		}
	}()

	var _folder_name string
	_chapter_colly.OnHTML("h1.title-detail", func(e *colly.HTMLElement) {
		_folder_name = e.Text
		// fmt.Printf("%s", _folder_name)
	})

	var _dir_path string
	// Handler to find all chapter links and send them to the channel
	_chapter_colly.OnHTML("nav ul#desc a", func(e *colly.HTMLElement) {
		_web_url_parse := e.Request.AbsoluteURL(e.Attr("href"))

		_channels_link <- _web_url_parse

		var _sub_folder_name string = e.Text

		_current_path, _get_path_failed := os.Getwd()
		if _get_path_failed != nil {
			etc.Error("Can't create directory %s", _folder_name)
		}
		_dir_path = path.Join(_current_path, _folder_name)
		_create_dir_err := os.MkdirAll(_current_path+"\\"+_folder_name, os.ModePerm)

		if _create_dir_err != nil {
			etc.Error("Can't create directory!")
		}

		_real_dir_path, _get_dir_path_err := filepath.Abs(_dir_path)
		if _get_dir_path_err != nil {
			etc.Error("Can't get directory path")
		}

		_create_sub_dir_err := os.MkdirAll(_real_dir_path+"\\"+_sub_folder_name, os.ModePerm)
		if _create_sub_dir_err != nil {
			etc.Error("Can't create sub-directory %s", _sub_folder_name)
		}

		var _get_sub_dir_err error
		_real_sub_dir_path, _get_sub_dir_err = filepath.Abs(_dir_path + "\\" + _sub_folder_name)

		if _get_sub_dir_err != nil {
			etc.Error("Can't download image to %s", _real_dir_path)
		}

	})

	// Close the channel when scraping is done
	_chapter_colly.OnScraped(func(r *colly.Response) {
		close(_channels_link)
	})

	// Start scraping the main page that contains the list of chapters

	if len(_url_web) > 5 {
		etc.Info("Download from: %s", _url_web)
	}

	err := _chapter_colly.Visit(_url_web)

	if err != nil {
		etc.Error("Please check your Nettruyen URL!")
	}

	// Wait for all tasks is done
	_wait_group.Wait()

	if len(_url_web) > 5 {
		etc.Info(
			"Done! Successfully download all image as:\n" +
				_dir_path,
		)
	}
}
