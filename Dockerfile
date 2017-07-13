FROM microsoft/dotnet
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Staging
ENV PORT 80

COPY source/random-avatar /app
WORKDIR /app

RUN ["dotnet", "restore"]

# Run the app
ENTRYPOINT ["dotnet", "run"]
#ENTRYPOINT ["dotnet", "myapp.dll"]
