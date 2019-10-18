#!/usr/bin/env bash
set -e

docker build --tag dotnet-build -f ./build/Build.Dockerfile .
docker run --rm --name dotnet-build-container \
  --mount type=bind,source=$PWD,target=/repository \
  dotnet-build \
  dotnet run -p ./build/build.csproj -- --mount-dir=/repository "$@"