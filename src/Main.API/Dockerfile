#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Main.API/Main.API.csproj", "src/Main.API/"]
COPY ["src/Infrastructure.CrossCutting/Infrastructure.CrossCutting.csproj", "src/Infrastructure.CrossCutting/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Application.CrossCutting/Application.CrossCutting.csproj", "src/Application.CrossCutting/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
RUN dotnet restore "src/Main.API/Main.API.csproj"
COPY . .
WORKDIR "/src/src/Main.API"
RUN dotnet build "Main.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Main.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Main.API.dll"]