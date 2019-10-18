# Bitwise Extensions
Educational bitwise extentions for fun only. Not suitable for production

## Prerequisites
Build requires only docker with linux containers and development requires only Visual Studio 2019.
```
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
choco install -y docker-desktop
choco install -y visualstudio2019community
```
## Build
Build is executed within docker container so it does not require any pre-installed software except docker with linux containers.
```
./build.ps1
```

## Run
It can be run on desktop via `./run.ps1` or within docker container via `./run_in_container.ps1`