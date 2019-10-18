$ErrorActionPreference = "Stop";

docker build --tag dotnet-image-build -f ./Dockerfile .
docker run --rm -it --name dotnet-image-build-container `
  --env APP_DLL_NAME="BitwiseExtensions.DemoConsole.dll" `
  --mount type=bind,source="$($pwd)",target=/repository `
  dotnet-image-build `
  dotnet run --project ./build/build.csproj -- --mount-dir=/repository $args