FROM microsoft/dotnet:1.1.2-sdk-jessie

MAINTAINER chsword
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Staging
ENV PORT 80

COPY source/random-avatar /app
WORKDIR /app

RUN ["dotnet", "restore"]
ENTRYPOINT ["dotnet", "run"]