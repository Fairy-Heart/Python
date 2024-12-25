// # RAILGUN DOWNLOADER CLI  NetTruyen VERSION 3.0.0
//
// # NetTruyenDownload.go  By Reim developer
//
// You can also find other version of this project here:
//
// https://github.com/Fairy-Heart/RailgunDownloader

package cli

import (
	"RailgunDownloaderV2/cli/core"
	"fmt"

	"github.com/spf13/cobra"
)

var NettruyenDownloadCommand = &cobra.Command{
	Use:   "nettruyen",
	Short: "Download all chapters from Net Truyen",
	PreRunE: func(_command *cobra.Command, args []string) error {
		url, _ := _command.Flags().GetString("d")

		if len(url) == 0 {
			fmt.Printf(
				"Invalid argument.\n" +
					"Use: railgun nettruyen --d \"<net truyen url>\"\n" +
					"Example: railgun nettruyen --d \"https://nettruyenww.com/truyen-tranh/haikyuu-526\"\n",
			)
		}
		return nil
	},
	Run: func(_command *cobra.Command, args []string) {
		url, _ := _command.Flags().GetString("d")
		core.NettruyenDownload(url)
	},
}
