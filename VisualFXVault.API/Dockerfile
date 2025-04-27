FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 9090
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VisualFXVault.API/VisualFXVault.API.csproj", "VisualFXVault.API/"]
RUN dotnet restore "VisualFXVault.API/VisualFXVault.API.csproj"
COPY . .
WORKDIR "/src/VisualFXVault.API"
RUN dotnet build "VisualFXVault.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VisualFXVault.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV POSTGRES_HOST=localhost
ENV POSTGRES_PASSWORD=yourStrong(!)Password
ENTRYPOINT ["dotnet", "VisualFXVault.API.dll"]