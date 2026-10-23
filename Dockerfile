# Stage 1: Build e Publicação da Solução
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj e restaurar dependências
COPY ["SesiIndustria.Api/SesiIndustria.Api.csproj", "SesiIndustria.Api/"]
RUN dotnet restore "SesiIndustria.Api/SesiIndustria.Api.csproj"

# Copiar todo o código-fonte e publicar em Release
COPY . .
WORKDIR "/src/SesiIndustria.Api"
RUN dotnet publish "SesiIndustria.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime Otimizado para Produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SesiIndustria.Api.dll"]
