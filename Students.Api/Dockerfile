FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Students.Api.csproj", "./"]
RUN dotnet restore "Students.Api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Students.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Students.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Students.Api.dll"]
