FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /sources
COPY . .
RUN dotnet run --project ./build/build.csproj -- --mount-dir=/repository 

FROM base AS final
WORKDIR /app
COPY --from=build /repository/.artifacts .
ENTRYPOINT dotnet $APP_DLL_NAME