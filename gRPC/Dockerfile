FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["gRPC/gRPC.csproj", "gRPC/"]
RUN dotnet restore "gRPC/gRPC.csproj"
COPY . .
WORKDIR "/src/gRPC"
RUN dotnet build "gRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gRPC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gRPC.dll"]
