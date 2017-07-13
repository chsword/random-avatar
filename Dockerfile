FROM microsoft/dotnet:1.1.2-sdk-jessie AS build-env

MAINTAINER chsword
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Staging
ENV PORT 80

COPY source/random-avatar /app
WORKDIR /app

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:1.1.2-runtime-jessie
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "random-avatar.dll"]