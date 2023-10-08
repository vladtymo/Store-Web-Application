FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY Core/*.csproj ./Core/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY MVC_apple_store/*.csproj ./MVC_apple_store/

RUN dotnet restore

COPY Core/. ./Core/
COPY Infrastructure/. ./Infrastructure/
COPY MVC_apple_store/. ./MVC_apple_store/

WORKDIR /app/MVC_apple_store
RUN dotnet publish -c release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app

COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "MVC_apple_store.dll"]