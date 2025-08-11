# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Hosts/Olp.ProcessingService.WebApi/Olp.ProcessingService.WebApi.csproj", "Src/Hosts/Olp.ProcessingService.WebApi/"]
COPY ["Src/Infrastructure/Olp.ProcessingService.Infrastructure.EntityFramework/Olp.ProcessingService.Infrastructure.EntityFramework.csproj", "Src/Infrastructure/Olp.ProcessingService.Infrastructure.EntityFramework/"]
COPY ["Src/Core/Olp.ProcessingService.Core.Domain/Olp.ProcessingService.Core.Domain.csproj", "Src/Core/Olp.ProcessingService.Core.Domain/"]
COPY ["Src/Repositories/Olp.ProcessingService.Repositories.Abstractions/Olp.ProcessingService.Repositories.Abstractions.csproj", "Src/Repositories/Olp.ProcessingService.Repositories.Abstractions/"]
COPY ["Src/Core/Olp.ProcessingService.Core.Contracts/Olp.ProcessingService.Core.Contracts.csproj", "Src/Core/Olp.ProcessingService.Core.Contracts/"]
COPY ["Src/Repositories/Olp.ProcessingService.Repositories.Implementation/Olp.ProcessingService.Repositories.Implementation.csproj", "Src/Repositories/Olp.ProcessingService.Repositories.Implementation/"]
COPY ["Src/Services/Olp.ProcessingService.Services.Abstractions/Olp.ProcessingService.Services.Abstractions.csproj", "Src/Services/Olp.ProcessingService.Services.Abstractions/"]
COPY ["Src/Services/Olp.ProcessingService.Services.Implementation/Olp.ProcessingService.Services.Implementation.csproj", "Src/Services/Olp.ProcessingService.Services.Implementation/"]
RUN dotnet restore "./Src/Hosts/Olp.ProcessingService.WebApi/Olp.ProcessingService.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/Hosts/Olp.ProcessingService.WebApi"
RUN dotnet build "./Olp.ProcessingService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Olp.ProcessingService.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olp.ProcessingService.WebApi.dll"]