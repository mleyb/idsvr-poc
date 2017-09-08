FROM microsoft/aspnetcore-build:1.1.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:1.1.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "IdentityServer.dll"]
