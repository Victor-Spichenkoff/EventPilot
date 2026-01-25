# BASE DIR -> compose
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy all CSPROJ FIRST (better for cache)
COPY src/EventPilot.API/EventPilot.API.csproj EventPilot.API/
COPY src/EventPilot.Application/EventPilot.Application.csproj EventPilot.Application/
COPY src/EventPilot.Infrastructure/EventPilot.Infrastructure.csproj EventPilot.Infrastructure/
COPY src/EventPilot.Domain/EventPilot.Domain.csproj EventPilot.Domain/

RUN dotnet restore "EventPilot.API/EventPilot.API.csproj"

# Copy remaning files
COPY src/ .

WORKDIR "/src/EventPilot.API"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
#COPY --from=publish /app/publish .

#<THIS IS NEW>
RUN mkdir -p /app/Data \
    && chown -R app:app /app/Data


RUN mkdir -p /app/Data \
    && chown -R app:app /app/Data \
    && chmod -R 775 /app/Data

COPY --from=publish /app/publish .

# ADD DB TO RUN TIME
COPY src/EventPilot.Infrastructure/Data/prod.db /app/Data/prod.db

RUN chown app:app /app/Data/prod.db \
    && chmod 664 /app/Data/prod.db

USER app
#</THIS IS NEW>

ENTRYPOINT ["dotnet", "EventPilot.API.dll"]


#
## BASE DIR -> compose
#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#
## Copy all CSPROJ FIRST (better for cache)
#COPY src/EventPilot.API/EventPilot.API.csproj EventPilot.API/
#COPY src/EventPilot.Application/EventPilot.Application.csproj EventPilot.Application/
#COPY src/EventPilot.Infrastructure/EventPilot.Infrastructure.csproj EventPilot.Infrastructure/
#COPY src/EventPilot.Domain/EventPilot.Domain.csproj EventPilot.Domain/
#
#RUN dotnet restore "EventPilot.API/EventPilot.API.csproj"
#
## Copy remaning files
#COPY src/ .
#
#WORKDIR "/src/EventPilot.API"
#RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "EventPilot.API.dll"]
