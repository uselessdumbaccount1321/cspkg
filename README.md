# cspkg
package format, creation and deployment in C#. Creates and parses `*.cspkg` package files.
# cspkgBuild
`cspkgBuild` allows you to create `*.cspkg` files from the command-line. Usage instructions:
```
cspkgBuild [author.PackageName] [versionMajor.versionMinor] [zipLocation]
```
It will output `author.PackageName.cspkg`, which can be used in the cspkg library or cspkgInstaller. Take note that advanced installation procedures such as installing files to the "Program Files" folder will require manual editing of the `meta.json` file within the archive created by cspkgBuild.
# cpkgInstaller
`cpkgInstaller` is a minimal redistributable binary for creating package installers. By default, it will try to open the `main.cspkg` file, but if you pass a path to a cspkg to the installer (via command-line or dropping it into the binary in Windows explorer) it will load that one instead. It automatically loads some information about the cspkg and automates its installation, overwriting previous installations if it exists.
