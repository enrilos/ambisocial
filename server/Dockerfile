FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore "AmbiSocial.Startup/AmbiSocial.Startup.csproj"
RUN dotnet publish "AmbiSocial.Startup/AmbiSocial.Startup.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "AmbiSocial.Startup.dll"]