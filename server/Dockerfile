FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./AmbiSocial.Web/AmbiSocial.Web.csproj"
RUN dotnet publish "./AmbiSocial.Web/AmbiSocial.Web.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80

ENTRYPOINT ["dotnet", "AmbiSocial.Web.dll"]