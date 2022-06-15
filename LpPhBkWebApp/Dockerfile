#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LpPhBkWebApp/LpPhBkWebApp.csproj", "LpPhBkWebApp/"]
COPY ["LpPhBkControllers/LpPhBkControllers.csproj", "LpPhBkControllers/"]
COPY ["LpPhBkContext/LpPhBkContext.csproj", "LpPhBkContext/"]
COPY ["LpPhBkEntity/LpPhBkEntity.csproj", "LpPhBkEntity/"]
COPY ["LpPhBkViews/LpPhBkViews.csproj", "LpPhBkViews/"]
COPY ["PhBkViews/PhBkViews.csproj", "PhBkViews/"]
RUN dotnet restore "LpPhBkWebApp/LpPhBkWebApp.csproj"
COPY . .
WORKDIR "/src/LpPhBkWebApp"
RUN dotnet build "LpPhBkWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LpPhBkWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LpPhBkWebApp.dll"]