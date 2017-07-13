FROM microsoft/dotnet:1.1-sdk AS build-env
WORKDIR /app
COPY source/random-avatar /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:1.1-runtime
MAINTAINER chsword
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Staging
ENV PORT 80
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "random-avatar.dll"]