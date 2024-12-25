package etc

import (
	"fmt"

	"github.com/gookit/color"
)

type _color struct {
	Error    color.Color
	Load     color.Color
	Info     color.Color
	Download color.Color
}

var _colors = _color{
	Error:    color.FgRed,
	Load:     color.FgGray,
	Info:     color.FgCyan,
	Download: color.FgYellow,
}

func Error(msg string, format ...interface{}) {
	message := fmt.Sprintf(msg, format...)

	_colors.Error.Println("[ERR!] " + message)
}

func Load(msg string, format ...interface{}) {
	message := fmt.Sprintf(msg, format...)

	_colors.Load.Println("[LOAD] " + message)
}

func Info(msg string, format ...interface{}) {
	message := fmt.Sprintf(msg, format...)

	_colors.Info.Println("[INFO] " + message)
}

func Download(msg string, format ...interface{}) {
	message := fmt.Sprintf(msg, format...)

	_colors.Download.Println("[DOWNLOAD] " + message)
}
