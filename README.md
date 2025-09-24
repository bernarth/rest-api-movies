# Rest Api Movies

This api demonstrates a basic path to build a rest api that can be used with any architecture.

## How to run locally

1. You need to create a `.env` file with a content similar to:

```
# .env
POSTGRES_USER=<USER>
POSTGRES_PASSWORD=<PASSWORD>
POSTGRES_DB=<DB_NAME>
```

2. You need to create a file `Movies.Api/appsettings.Development.json` with a content similar to:

```json
{
  "Database": {
    "ConnectionString": "Server=localhost;Port=5433;Database=<DB_NAME>;User ID=<USER>;Password=<PASSWORD>"
  },
  "Jwt": {
    "Key": "<The key of your auth api>",
    "Issuer": "https://id.issuer.com",
    "Audience": "https://movies.audience.com"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

3. Run the following command: `docker compose up -d --build`
4. You need a project for authentication. For example: `Identity.Api` project
5. Open in Visual Studio 2022 and run.