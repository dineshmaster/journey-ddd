#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Journey.API/Journey.API.csproj", "Journey.API/"]
RUN dotnet restore "Journey.API/Journey.API.csproj"
COPY . .
WORKDIR "/src/Journey.API"
RUN dotnet build "Journey.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Journey.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Journey.API.dll"]