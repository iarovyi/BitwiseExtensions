$ErrorActionPreference = "Stop";

dotnet build ./src
docker build --tag dotnet-run-image -f ./src/BitwiseExtensions.DemoConsole/Dockerfile ./src
docker run --rm -it --name dotnet-run-image-container dotnet-run-image `
  dotnet BitwiseExtensions.DemoConsole.dll