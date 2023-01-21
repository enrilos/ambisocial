FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Web/AmbiSocial.Web/AmbiSocial.Web.csproj"
RUN dotnet publish "./Web/AmbiSocial.Web/AmbiSocial.Web.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
ENV DefaultDockerConnection=Host=db;Database=ambisocial;Username=emre;Password=test;

ENTRYPOINT ["dotnet", "AmbiSocial.Web.dll"]