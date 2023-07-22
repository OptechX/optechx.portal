FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env-7.0
WORKDIR /app
COPY Shared/*.csproj Shared/
RUN dotnet restore Shared/*.csproj
COPY Client/*.csproj Client/
RUN dotnet restore Client/*.csproj
COPY Server/*.csproj Server/
RUN dotnet restore Server/*.csproj
COPY . .
WORKDIR /app/Client
RUN dotnet build
WORKDIR /app/Server
RUN dotnet build
WORKDIR /app/Server
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env-6.0
WORKDIR /app
COPY Shared/*.csproj Shared/
RUN dotnet restore Shared/*.csproj
COPY Client/*.csproj Client/
RUN dotnet restore Client/*.csproj
COPY Server/*.csproj Server/
RUN dotnet restore Server/*.csproj
COPY . .
WORKDIR /app/Client
RUN dotnet build
WORKDIR /app/Server
RUN dotnet build
WORKDIR /app/Server
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview-alpine AS build-env-8.0-preview-alpine
WORKDIR /app
COPY Shared/*.csproj Shared/
RUN dotnet restore Shared/*.csproj
COPY Client/*.csproj Client/
RUN dotnet restore Client/*.csproj
COPY Server/*.csproj Server/
RUN dotnet restore Server/*.csproj
COPY . .
WORKDIR /app/Client
RUN dotnet build
WORKDIR /app/Server
RUN dotnet build
WORKDIR /app/Server
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env-7.0 /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "OptechX.Portal.Server.dll"]
