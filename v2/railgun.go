package main

/******************************************
*                                         *
*  RAILGUN DOWNLOADER V2                  *
*  BY REIM DEVELOPER					  *
*  CONTACT DISCORD USERNAME: kaxtr 		  *
*										  *
******************************************/

import (
	"RailgunDownloaderV2/cli"
	"fmt"

	"github.com/spf13/cobra"
)

var _root_command = &cobra.Command{
	Use:   "railgun",
	Short: "Railgun downloader is a ulti tool for download",
	Run: func(command *cobra.Command, args []string) {
		fmt.Printf("Use railun --help for more infomation\n")
	},
}

func init() {
	cli.EchoCommand.Flags().StringP(
		"msg",
		"m",
		"",
		"Message to print",
	)
	cli.EchoCommand.MarkFlagRequired("msg")

	_root_command.AddCommand(cli.EchoCommand)

	cli.TruyenQQDownloadCommand.Flags().StringP(
		"d",
		"",
		"",
		"URL to download",
	)
	cli.TruyenQQDownloadCommand.MarkFlagRequired("d")
	_root_command.AddCommand(cli.TruyenQQDownloadCommand)

	cli.NettruyenDownloadCommand.Flags().StringP(
		"d",
		"",
		"",
		"URL to download",
	)
	_root_command.AddCommand(cli.NettruyenDownloadCommand)

}

func main() {
	_root_command.Execute()
}
