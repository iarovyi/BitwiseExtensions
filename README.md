# Bitwise Extensions

![](https://github.com/iarovyi/BitwiseExtensions/workflows/Run%20CI/badge.svg)

Educational bitwise extentions for fun only. Not suitable for production

## Prerequisites
Building a package requires only docker for linux:
```
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
choco install -y docker-desktop
```

Code development requires only VisualStudio 2019:
```
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
choco install -y visualstudio2019community
```
## Build
Build is executed within docker container so it does not require any pre-installed software except docker with linux containers.
```
./build.ps1
```

## Run
It can be run on desktop via `./run.ps1` or within docker container via `./run_in_container.ps1`