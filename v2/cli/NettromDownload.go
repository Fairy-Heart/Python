package cli

/******************************************
*										  *
*  NET TROM DOWNLOAD CLI                  *
*  RAILGUN DOWNLOADER V2                  *
*  BY REIM DEVELOPER					  *
*  CONTACT DISCORD USERNAME: kaxtr 		  *
*										  *
******************************************/

import (
	"RailgunDownloaderV2/cli/core"
	"RailgunDownloaderV2/etc"

	"github.com/spf13/cobra"
)

var NettruyenDownloadCommand = &cobra.Command{
	Use:   "nettruyen",
	Short: "Download all chapters from Net Truyen",
	PreRunE: func(_command *cobra.Command, args []string) error {
		url, _ := _command.Flags().GetString("d")

		if len(url) == 0 {
			etc.Error(
				"Invalid argument.\n" +
					"Use: railgun nettruyen --d \"<net truyen url>\"\n" +
					"Example: railgun nettruyen --d \"https://nettruyenww.com/truyen-tranh/haikyuu-526\"",
			)
		}
		return nil
	},
	Run: func(_command *cobra.Command, args []string) {
		url, _ := _command.Flags().GetString("d")
		core.NettruyenDownload(url)
	},
}
