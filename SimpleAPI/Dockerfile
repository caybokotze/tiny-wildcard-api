﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleAPI/SimpleAPI.csproj", "SimpleAPI/"]
RUN dotnet restore "SimpleAPI/SimpleAPI.csproj"
COPY . .
WORKDIR "/src/SimpleAPI"
RUN dotnet build "SimpleAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleAPI.dll"]
