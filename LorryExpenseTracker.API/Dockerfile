# Use the official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore dependencies
COPY *.sln .
COPY LorryExpenseTracker.API/*.csproj LorryExpenseTracker.API/
RUN dotnet restore LorryExpenseTracker.API

# Copy the remaining files and build the release version
COPY . .
WORKDIR /src/LorryExpenseTracker.API
RUN dotnet publish -c Release -o /app/publish

# Use the smaller runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 for Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "LorryExpenseTracker.API.dll"]
