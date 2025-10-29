# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
ARG ProjectPath

# copy csproj and restore as distinct layers
COPY $ProjectPath .
RUN dotnet restore --use-current-runtime &&\ 
    dotnet publish -c Release -o /app --use-current-runtime --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
RUN apt update && apt install -y curl
WORKDIR /app
COPY --from=build /app .
ARG SiteName
ENV assembly="${SiteName}.dll"
ENTRYPOINT dotnet "${assembly}"
