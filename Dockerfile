#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /CadastroLivros
COPY ["src/CadastroLivros.API/CadastroLivros.API.csproj", "src/CadastroLivros.API/"]
COPY ["src/CadastroLivros.Core.API/CadastroLivros.Core.API.csproj", "src/CadastroLivros.Core.API/"]
COPY ["src/CadastroLivros.Infrastructure/CadastroLivros.Infrastructure.csproj", "src/CadastroLivros.Infrastructure/"]
COPY ["src/CadastroLivros.Core/CadastroLivros.Core.csproj", "src/CadastroLivros.Core/"]
RUN dotnet restore "src/CadastroLivros.API/CadastroLivros.API.csproj"
COPY . .
WORKDIR "src/CadastroLivros.API"
RUN dotnet build "CadastroLivros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CadastroLivros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastroLivros.API.dll"]