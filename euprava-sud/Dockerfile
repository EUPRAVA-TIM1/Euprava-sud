#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
# EXPOSE 8003

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["euprava-sud/euprava-sud/euprava-sud.csproj", "euprava-sud/"]
# RUN dotnet restore "euprava-sud/euprava-sud/euprava-sud.csproj"
COPY . .
WORKDIR "/src/euprava-sud"
RUN dotnet build "euprava-sud/euprava-sud.csproj" -c Release -o /app/build

FROM build AS publish
# RUN dotnet publish "euprava-sud/euprava-sud.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet publish "euprava-sud/euprava-sud.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8003
ENTRYPOINT ["dotnet", "euprava-sud.dll"]

ENV ASPNETCORE_URLS=http://+:8003