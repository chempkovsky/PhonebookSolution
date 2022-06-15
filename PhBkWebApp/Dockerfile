#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhBkWebApp/PhBkWebApp.csproj", "PhBkWebApp/"]
COPY ["PhBkViews/PhBkViews.csproj", "PhBkViews/"]
COPY ["PhBkControllers/PhBkControllers.csproj", "PhBkControllers/"]
COPY ["PhBkEntity/PhBkEntity.csproj", "PhBkEntity/"]
COPY ["LpPhBkViews/LpPhBkViews.csproj", "LpPhBkViews/"]
COPY ["PhBkContext/PhBkContext.csproj", "PhBkContext/"]
RUN dotnet restore "PhBkWebApp/PhBkWebApp.csproj"
COPY . .
WORKDIR "/src/PhBkWebApp"
RUN dotnet build "PhBkWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhBkWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhBkWebApp.dll"]