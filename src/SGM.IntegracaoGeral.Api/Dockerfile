#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SGM.IntegracaoGeral.Api/SGM.IntegracaoGeral.Api.csproj", "src/SGM.IntegracaoGeral.Api/"]
RUN dotnet restore "src/SGM.IntegracaoGeral.Api/SGM.IntegracaoGeral.Api.csproj"

COPY . .
WORKDIR "/src/src/SGM.IntegracaoGeral.Api"
RUN dotnet build "SGM.IntegracaoGeral.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SGM.IntegracaoGeral.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SGM.IntegracaoGeral.Api.dll"]