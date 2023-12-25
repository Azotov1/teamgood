#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ManagmentLibrary.console/ManagmentLibrary.console.csproj", "ManagmentLibrary.console/"]
COPY ["LAB3Library1/ManagmentLibrary.Core.csproj", "LAB3Library1/"]
RUN dotnet restore "ManagmentLibrary.console/ManagmentLibrary.console.csproj"
COPY . .
WORKDIR "/src/ManagmentLibrary.console"
RUN dotnet build "ManagmentLibrary.console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManagmentLibrary.console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManagmentLibrary.console.dll"]