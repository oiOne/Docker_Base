FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BookSeller.Tests/BookSeller.Tests.csproj", "BookSeller.Tests/"]
RUN dotnet restore "BookSeller.Tests/BookSeller.Tests.csproj"
COPY . .
WORKDIR "/src/BookSeller.Tests"
RUN dotnet build "BookSeller.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookSeller.Tests.csproj" -c Release -o /app/publish

FROM build as unittest
WORKDIR /src/

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookSeller.Tests.dll"]