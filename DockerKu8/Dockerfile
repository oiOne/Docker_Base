FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["DockerKu8/DockerKu8.csproj", "DockerKu8/"]

RUN dotnet restore "DockerKu8/DockerKu8.csproj"
COPY . .
WORKDIR "/src/DockerKu8"
RUN dotnet build "DockerKu8.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerKu8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerKu8.dll"]