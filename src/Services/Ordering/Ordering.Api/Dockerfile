#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Ordering/Ordering.Api/Ordering.Api.csproj", "Services/Ordering/Ordering.Api/"]
COPY ["Services/Ordering/Application/Application.csproj", "Services/Ordering/Application/"]
COPY ["Services/Ordering/Domain/Domain.csproj", "Services/Ordering/Domain/"]
COPY ["Common/EvenetBus.Messges/EvenetBus.Messges.csproj", "Common/EvenetBus.Messges/"]
COPY ["Services/Ordering/Infrastructure/Infrastructure.csproj", "Services/Ordering/Infrastructure/"]
RUN dotnet restore "Services/Ordering/Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]