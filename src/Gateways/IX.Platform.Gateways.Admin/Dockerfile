#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Gateways/IX.Platform.Gateways.Admin/IX.Platform.Gateways.Admin.fsproj", "src/Gateways/IX.Platform.Gateways.Admin/"]
RUN dotnet restore "src/Gateways/IX.Platform.Gateways.Admin/IX.Platform.Gateways.Admin.fsproj"
COPY . .
WORKDIR "/src/src/Gateways/IX.Platform.Gateways.Admin"
RUN dotnet build "IX.Platform.Gateways.Admin.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IX.Platform.Gateways.Admin.fsproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IX.Platform.Gateways.Admin.dll"]