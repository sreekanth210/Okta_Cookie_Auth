FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY . .

RUN dotnet publish Okta_Cookie_Auth.csproj -c Release -o /app/publish

EXPOSE 8080

ENTRYPOINT ["dotnet", "Okta_Cookie_Auth.dll"]

