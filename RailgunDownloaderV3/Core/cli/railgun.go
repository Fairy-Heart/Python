// # RAILGUN DOWNLOADER MAIN CLI VERSION 3.0.0
//
// # railgun.go  By Reim developer
//
// You can also find other version of this project here:
//
// https://github.com/Fairy-Heart/RailgunDownloader

package main

import (
	"RailgunDownloaderV2/cli"
	"fmt"

	"github.com/spf13/cobra"
)

var root_command = &cobra.Command{
	Use:   "railgun",
	Short: "Railgun downloader is a ulti tool for download",
	Run: func(command *cobra.Command, args []string) {
		fmt.Printf("Use railun --help for more infomation\n")
	},
}

func init() {
	cli.TruyenQQDownloadCommand.Flags().StringP(
		"d",
		"",
		"",
		"URL to download",
	)
	cli.TruyenQQDownloadCommand.MarkFlagRequired("d")
	root_command.AddCommand(cli.TruyenQQDownloadCommand)

	cli.NettruyenDownloadCommand.Flags().StringP(
		"d",
		"",
		"",
		"URL to download",
	)
	cli.NettruyenDownloadCommand.MarkFlagRequired("d")
	root_command.AddCommand(cli.NettruyenDownloadCommand)

}

func main() {
	root_command.Execute()
}
