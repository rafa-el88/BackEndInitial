#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PositivoCore.WebApi/PositivoCore.WebApi.csproj", "PositivoCore.WebApi/"]
COPY ["PositivoCore.Domain/PositivoCore.Domain.csproj", "PositivoCore.Domain/"]
COPY ["PositivoCore.Shared/PositivoCore.Shared.csproj", "PositivoCore.Shared/"]
COPY ["PositivoCore.Application/PositivoCore.Application.csproj", "PositivoCore.Application/"]
COPY ["PositivoCore.Data/PositivoCore.Data.csproj", "PositivoCore.Data/"]
RUN dotnet restore "PositivoCore.WebApi/PositivoCore.WebApi.csproj"

COPY . .
WORKDIR "/src/PositivoCore.WebApi"
RUN dotnet build "PositivoCore.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PositivoCore.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PositivoCore.WebApi.dll"]