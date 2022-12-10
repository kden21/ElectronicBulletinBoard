FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EBoardEmailService/EBoardEmailService.csproj", "EBoardEmailService/"]
RUN dotnet restore "EBoardEmailService/EBoardEmailService.csproj"
COPY . .
WORKDIR "/src/EBoardEmailService"
RUN dotnet build "EBoardEmailService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EBoardEmailService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EBoardEmailService.dll"]
