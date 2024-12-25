**Lưu ý: Dự án này yêu cầu bạn cần có Golang, Makefile, Python & C# được cài đặt sẵn trên PC của mình**
* [Download Golang](https://go.dev/)
* [Download Python](https://www.python.org/)
* [Download C#](https://dotnet.microsoft.com/en-us/languages/csharp)
* [Download Makefile](https://gnuwin32.sourceforge.net/packages/make.htm)

* **CLI**
* Build `*.exe` cho CLI (Yêu cầu Golang)
* Sử dụng lệnh `go build railgun.go`

* **INSTALLER**
* Build `.exe` cho Installer (Yêu cầu Python)
* Tới folder `installer`
* Sử dụng lệnh `make build`

* **UI**
* Build `.exe` & các phụ thuộc khác cho ứng dụng UI (Yêu cầu Dotnet CLI & C#)
* Tới folder `UI`
* Sử dụng lệnh `make build`
