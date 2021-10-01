# build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet publish -c Release Crumbs.sln -o out

# image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# standard entrypoint
ENTRYPOINT [ "dotnet", "Crumbs.Api.dll" ]

# Use the following instead for Heroku
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet Crumbs.Api.dll
 