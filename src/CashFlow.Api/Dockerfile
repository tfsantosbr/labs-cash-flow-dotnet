FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /build
COPY ["src/CashFlow.Api/CashFlow.Api.csproj", "src/CashFlow.Api/"]
COPY ["src/CashFlow.Application/CashFlow.Application.csproj", "src/CashFlow.Application/"]
COPY ["src/CashFlow.Infrastructure/CashFlow.Infrastructure.csproj", "src/CashFlow.Infrastructure/"]
RUN dotnet restore "src/CashFlow.Api/CashFlow.Api.csproj"
COPY . .
WORKDIR "/build/src/CashFlow.Api"
RUN dotnet build "CashFlow.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashFlow.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

RUN apt-get update
RUN apt-get --yes install curl

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.Api.dll"]
