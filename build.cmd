docker build --tag dotnet-build -f .\build\Build.Dockerfile . || echo ERROR && exit /b
docker run --rm -it --name dotnet-build-container ^
  --mount type=bind,source="%cd%",target=/repository ^
  dotnet-build ^
  dotnet run -p ./build/build.csproj -- --mount-dir=/repository %*