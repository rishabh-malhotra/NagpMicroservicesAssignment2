#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AggregateService/AggregateService.csproj", "AggregateService/"]
RUN dotnet restore "AggregateService/AggregateService.csproj"
COPY . .
WORKDIR "/src/AggregateService"
RUN dotnet build "AggregateService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AggregateService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AggregateService.dll"]