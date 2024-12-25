// # RAILGUN DOWNLOADER CLI CORE VERSION 3.0.0
//
// # TruyenQQDownload.go  By Reim developer
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

var TruyenQQDownloadCommand = &cobra.Command{
	Use:   "truyenqq",
	Short: "Download all chapters from TruyenQQ",
	PreRunE: func(_command *cobra.Command, args []string) error {
		url, _ := _command.Flags().GetString("d")

		if len(url) == 0 {
			fmt.Printf(
				"Invalid argument.\n" +
					"Use: railgun truyenqq --d \"<truyenqq url>\"\n" +
					"Example: railgun truyenqq --d \"https://truyenqqto.com/truyen-tranh/lang-khach-4970\"",
			)
		}
		return nil
	},
	Run: func(_command *cobra.Command, args []string) {
		url, _ := _command.Flags().GetString("d")
		core.TruyenQQDownload(url)
	},
}
