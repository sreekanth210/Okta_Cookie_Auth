FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish Okta_Cookie_Auth.csproj -c Release -o /app/publish

FROM mrc.microsoft.com/dotnet/sdk:8.0 As runtime
WORKDIR /app

COPY --from=build /app/puplish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Okta_Cookie_Auth.dll"]
