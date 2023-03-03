FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore "Web/AmbiSocial.Web/AmbiSocial.Web.csproj"
RUN dotnet publish "Web/AmbiSocial.Web/AmbiSocial.Web.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "AmbiSocial.Web.dll"]