FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["REST/REST.csproj", "REST/"]
RUN dotnet restore "REST/REST.csproj"
COPY . .
WORKDIR "/src/REST"
RUN dotnet build "REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REST.dll"]
