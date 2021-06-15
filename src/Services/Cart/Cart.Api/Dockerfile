#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Cart/Cart.Api/Cart.Api.csproj", "Services/Cart/Cart.Api/"]
COPY ["Common/EvenetBus.Messges/EvenetBus.Messges.csproj", "Common/EvenetBus.Messges/"]
RUN dotnet restore "Services/Cart/Cart.Api/Cart.Api.csproj"
COPY . .
WORKDIR "/src/Services/Cart/Cart.Api"
RUN dotnet build "Cart.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cart.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cart.Api.dll"]