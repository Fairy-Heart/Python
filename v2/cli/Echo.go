package cli

/*
*
*  ECHO COMMAND | Just test cli is working
*  RAILGUN DOWNLOADER V2
*  BY REIM DEVELOPER
*  CONTACT DISCORD USERNAME: kaxtr
*
 */

import (
	"RailgunDownloaderV2/etc"

	"github.com/spf13/cobra"
)

var EchoCommand = &cobra.Command{
	Use:   "echo --message <message to print>",
	Short: "Print a message",
	PreRunE: func(_command *cobra.Command, args []string) error {
		msg, _ := _command.Flags().GetString("msg")

		if len(msg) == 0 {
			etc.Error(
				"Invalid argument.\n",
				"Use: railgun echo --msg \"<your message>\"\n",
				"Example: railgun echo --msg \"Hello Railgun!\"",
			)
		}
		return nil
	},
	Run: func(_command *cobra.Command, args []string) {
		msg, _ := _command.Flags().GetString("msg")
		etc.Info(msg)
	},
}
