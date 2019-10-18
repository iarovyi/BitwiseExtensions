FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /sources
COPY . .