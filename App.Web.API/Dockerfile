#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["App.Web.API/App.Web.API.csproj", "App.Web.API/"]
COPY ["App.Entities/App.Entities.csproj", "App.Entities/"]
COPY ["App.DAL/App.DAL.csproj", "App.DAL/"]
COPY ["App.UnitTests/App.UnitTests.csproj", "App.UnitTests/"]
RUN dotnet restore "App.Web.API/App.Web.API.csproj"
RUN dotnet restore "App.UnitTests/App.UnitTests.csproj"
COPY . . 
RUN dotnet build "App.Web.API/App.Web.API.csproj" -c Release -o /app/build
RUN dotnet build "App.UnitTests/App.UnitTests.csproj" -c Release -o /app/build

RUN dotnet test "App.UnitTests/App.UnitTests.csproj" --logger "trx;LogFileName=fastcommercelog.trx" 


FROM build AS publish
RUN dotnet publish "App.Web.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Web.API.dll", "--urls", "http://*:5000;http://*:5001"]

