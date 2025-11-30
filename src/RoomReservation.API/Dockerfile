# BASE DIR -> compose
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all CSPROJ FIRST (better for cache)
COPY src/RoomReservation.API/RoomReservation.API.csproj RoomReservation.API/
COPY src/RoomReservation.Application/RoomReservation.Application.csproj RoomReservation.Application/
COPY src/RoomReservation.Infrastructure/RoomReservation.Infrastructure.csproj RoomReservation.Infrastructure/
COPY src/RoomReservation.Domain/RoomReservation.Domain.csproj RoomReservation.Domain/

RUN dotnet restore "RoomReservation.API/RoomReservation.API.csproj"

# Copy remaning files
COPY src/ .

WORKDIR "/src/RoomReservation.API"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomReservation.API.dll"]