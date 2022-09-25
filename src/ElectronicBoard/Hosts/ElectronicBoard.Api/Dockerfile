FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ElectronicBoard/Hosts/ElectronicBoard.Api/ElectronicBoard.Api.csproj", "ElectronicBoard.Api/"]
RUN dotnet restore "src/ElectronicBoard/Hosts/ElectronicBoard.Api/ElectronicBoard.Api.csproj"
COPY . .
WORKDIR "/src/ElectronicBoard.Api"
RUN dotnet build "ElectronicBoard.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectronicBoard.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectronicBoard.Api.dll"]
