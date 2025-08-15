#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MoviesAPI/MoviesAPI.csproj", "MoviesAPI/"]
COPY ["MoviesAPI/Core/Core.csproj", "MoviesAPI/Core/"]
COPY ["MoviesAPI/Data/Data.csproj", "MoviesAPI/Data/"]
COPY ["MoviesAPI/Services/Services.csproj", "MoviesAPI/Services/"]
RUN dotnet restore "./MoviesAPI/MoviesAPI.csproj"
COPY . .
WORKDIR "/src/MoviesAPI"
RUN dotnet build "./MoviesAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MoviesAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
ENV ASPNETCORE_URLS=http://+:5000;https://+:5001

FROM base AS final
WORKDIR /src/MoviesAPI
COPY --from=build /src /src
ENTRYPOINT ["dotnet", "watch","run","--urls=https://0.0.0.0:5001"]