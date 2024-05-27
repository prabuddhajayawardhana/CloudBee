# CloudBee
Microservices

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

**MSSQL Setup**

`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Admin@123" -v mssqlvol:/var/opt/mssql -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest`

`Data Source=localhost;Initial Catalog=Obloo;User ID=sa;Trust Server Certificate=True`

**Mongo Setup**

`docker run -v mongodbvol:/var/opt/mongodbvol -p 8081:8081 --name mongo -d mongo:latest`

`docker exec -it mongo bin/bash`

`docker run -d -p 3000:3000 -v mongodbvol:/var/opt/mongodbvol mongoclient/mongoclient`

Add-Migration InitialCreate

`Update-Database`

`docker compose -f docker-compose.yml -f docker-compose.override.yml up -d`

`docker-compose run Obloo/src/Obloo.Infrastructure dotnet ef migrations add InitialCreate`

`docker-compose run Obloo dotnet ef database update`

`docker exec -it obloo.api bash`

# docker managment doc 
https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-8.0