import os
import subprocess


def add_exe_to_path(install_path: str) -> None:
    full_path = os.path.join(
        install_path,
        "RailgunDownloaderV2",
        "core",
        "bin"
    )
    full_path = os.path.normpath(full_path)
    print(full_path)

    subprocess.run(f"setx PATH \"%PATH%;{full_path}\" /M", shell = True)