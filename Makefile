dev:
	cd client && npm run dev
api:
	cd server/AmbiSocial.Startup && dotnet run AmbiSocial.Startup.csproj
rebuild-server:
	find . -type d \( -name "bin" -o -name "obj" \) -exec rm -r "{}" + \
	&& dotnet restore ./server/AmbiSocial.sln
migration:
	cd server/AmbiSocial.Infrastructure \
	&& dotnet ef migrations add "${name}" -o ./Common/Persistance/Migrations
update-db:
	cd server/AmbiSocial.Infrastructure/Common/Persistance \
	&& dotnet ef database update --project ../../AmbiSocial.Infrastructure.csproj
undo-migration:
	cd server/AmbiSocial.Infrastructure/Common/Persistance \
	&& dotnet ef migrations remove --project ../../AmbiSocial.Infrastructure.csproj --force