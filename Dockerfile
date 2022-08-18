FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

MAINTAINER chsword
ENV ASPNETCORE_URLS http://*:80
ENV PORT 80

WORKDIR /app
COPY out .
EXPOSE 80
ENTRYPOINT ["dotnet", "random-avatar.dll"]