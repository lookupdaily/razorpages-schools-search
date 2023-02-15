FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SchoolPerformanceTablesMock/SchoolPerformanceTablesMock.csproj", "SchoolPerformanceTablesMock/"]
RUN dotnet restore "SchoolPerformanceTablesMock/SchoolPerformanceTablesMock.csproj"
COPY . .
WORKDIR "/src/SchoolPerformanceTablesMock"
RUN dotnet build "SchoolPerformanceTablesMock.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolPerformanceTablesMock.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolPerformanceTablesMock.dll"]
