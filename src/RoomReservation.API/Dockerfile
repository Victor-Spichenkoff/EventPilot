#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["RoomReservation.csproj", "RoomReservation/"]
#RUN dotnet restore "RoomReservation.csproj"
#COPY . .
#WORKDIR "/src/RoomReservation"
#RUN dotnet build "RoomReservation.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "RoomReservation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "RoomReservation.dll"]


# V2
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os csproj (cache friendly)
COPY RoomReservation.API/RoomReservation.API.csproj RoomReservation.API/
COPY RoomReservation.Application/RoomReservation.Application.csproj RoomReservation.Application/
COPY RoomReservation.Infrastructure/RoomReservation.Infrastructure.csproj RoomReservation.Infrastructure/
COPY RoomReservation.Domain/RoomReservation.Domain.csproj RoomReservation.Domain/

RUN dotnet restore "RoomReservation.API/RoomReservation.API.csproj"

# Copia o resto
COPY . .

WORKDIR "/src/RoomReservation.API"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomReservation.API.dll"]