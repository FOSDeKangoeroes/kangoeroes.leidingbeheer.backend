FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY kangoeroes.webUI/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish kangoeroes.webUI -c Debug -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/kangoeroes.webUI/out .
ENTRYPOINT ["dotnet", "kangoeroes.webUI.dll"]