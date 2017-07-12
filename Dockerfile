FROM microsoft/dotnet
COPY source/random-avatar /app
WORKDIR /app

RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]
#ENTRYPOINT ["dotnet", "myapp.dll"]