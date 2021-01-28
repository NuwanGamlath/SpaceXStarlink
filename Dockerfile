FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["SpaceXStarlink.csproj", "./"]
RUN dotnet restore "SpaceXStarlink.csproj"
COPY . .
RUN dotnet build "SpaceXStarlink.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceXStarlink.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceXStarlink.dll"]
