#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Angular_Ex1_Backend/Angular_Ex1_Backend.csproj", "Angular_Ex1_Backend/"]
RUN dotnet restore "Angular_Ex1_Backend/Angular_Ex1_Backend.csproj"
COPY . .
WORKDIR "/src/Angular_Ex1_Backend"
RUN dotnet build "Angular_Ex1_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Angular_Ex1_Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Angular_Ex1_Backend.dll"]