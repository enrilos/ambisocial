dev:
	cd client && npm run dev
api:
	cd server/AmbiSocial.Startup && dotnet run AmbiSocial.Startup.csproj
rebuild-server:
	find . -type d \( -name "bin" -o -name "obj" \) -exec rm -r "{}" + \
	&& dotnet restore ./server/AmbiSocial.sln