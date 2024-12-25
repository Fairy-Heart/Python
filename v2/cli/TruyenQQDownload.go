package cli

/******************************************
*										  *
*  TRUYEN QQ DOWNLOAD CLI                 *
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

var TruyenQQDownloadCommand = &cobra.Command{
	Use:   "truyenqq",
	Short: "Download all chapters from TruyenQQ",
	PreRunE: func(_command *cobra.Command, args []string) error {
		url, _ := _command.Flags().GetString("d")

		if len(url) == 0 {
			etc.Error(
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
