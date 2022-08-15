#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Core/Tenant/IX.Platform.Microservice.Tenant/IX.Platform.Microservice.Tenant.fsproj", "src/Services/Core/Tenant/IX.Platform.Microservice.Tenant/"]
RUN dotnet restore "src/Services/Core/Tenant/IX.Platform.Microservice.Tenant/IX.Platform.Microservice.Tenant.fsproj"
COPY . .
WORKDIR "/src/src/Services/Core/Tenant/IX.Platform.Microservice.Tenant"
RUN dotnet build "IX.Platform.Microservice.Tenant.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IX.Platform.Microservice.Tenant.fsproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IX.Platform.Microservice.Tenant.dll"]
