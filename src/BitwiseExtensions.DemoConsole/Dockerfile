FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BitwiseExtensions.DemoConsole/BitwiseExtensions.DemoConsole.csproj", "BitwiseExtensions.DemoConsole/"]
COPY ["BitwiseExtensions/BitwiseExtensions.csproj", "BitwiseExtensions/"]
RUN dotnet restore "BitwiseExtensions.DemoConsole/BitwiseExtensions.DemoConsole.csproj"
COPY . .
WORKDIR "/src/BitwiseExtensions.DemoConsole"
RUN dotnet build "BitwiseExtensions.DemoConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BitwiseExtensions.DemoConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BitwiseExtensions.DemoConsole.dll"]