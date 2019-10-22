# Bitwise Extensions

![ci](https://github.com/iarovyi/BitwiseExtensions/workflows/Run%20CI/badge.svg)
![release](https://github.com/iarovyi/BitwiseExtensions/workflows/Release/badge.svg)

Educational bitwise extentions for fun only. Not suitable for production

## Prerequisites
DotNetCore is required for building and visual studio for development
```
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1')) 
choco install -y docker-desktop
choco install dotnetcore-sdk --version=2.2.0
choco install dotnetcore-sdk
choco install -y visualstudio2019community
```

## Build with no dependencies
It is possible to build in container so no dependencies are required except docker
```
./build_in_container.ps1
```

## Build
```
./build.ps1
```

## Run
It can be run on desktop via `./run.ps1` or within docker container via `./run_in_container.ps1`