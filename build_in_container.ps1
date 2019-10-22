$ErrorActionPreference = "Stop";

docker build --tag dotnet-build -f ./build/Build.Dockerfile .
docker run --rm -it --name dotnet-build-container `
  --mount type=bind,source="$($pwd)",target=/repository `
  dotnet-build `
  dotnet run --project ./build/_build.csproj -- --ArtifactsDir ../repository/.artifacts $args