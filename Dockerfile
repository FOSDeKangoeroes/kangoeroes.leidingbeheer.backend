FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY kangoeroes.leidingBeheer/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish kangoeroes.leidingBeheer -c Debug -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/kangoeroes.leidingBeheer/out .
ENTRYPOINT ["dotnet", "kangoeroes.leidingBeheer.dll"]