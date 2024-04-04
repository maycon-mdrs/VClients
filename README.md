# 💻 VClients

VClients is a project that aims to manage customer information. It provides a backend API for creating, updating, delete and retrieving customer data.

The frontend code can be found in the following [repository](https://github.com/LuigiVanin/customer-manager-sample).

### ⚙️ Project Setup 

Before running the project, ensure to create an .env file following the structure outlined in .env.example. This file should contain all necessary environment variables for Docker to function properly.

| Variable      | Description                                        |
|---------------|----------------------------------------------------|
| ASPNETCORE__DB__NAME | The name of your database. |
| ASPNETCORE__DB__USER | The username of your database. |
| ASPNETCORE__DB__PASSWORD | The password of your database. |

Make sure the variables in `./VClients.Api/appsettings.json` match the values in the `.env` file. 
- Database=ASPNETCORE__DB__NAME
- Username=ASPNETCORE__DB__USER 
- Password=ASPNETCORE__DB__PASSWORD

### Example:
#### .env
```
ASPNETCORE__DB__NAME=vclients
ASPNETCORE__DB__USER=postgres
ASPNETCORE__DB__PASSWORD=12345
```

#### appsettings.json
```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Host=vclients.database;Port=5432;Database=vclients;Username=postgres;Password=12345"
    },
    // ...
}
```
<br>

# 🐋 Run with Docker 

> [!warning]
> For this projector to work, it's necessary to have [Docker](https://www.docker.com/products/docker-desktop/). <br>
> Case: if the commands via prompts don't work to use `docker compose`, download one of these IDEs:
> - [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)
> - [Rider](https://www.jetbrains.com/pt-br/rider/)

To run the project, use the following command:
```bash
$ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
# http://localhost:5000/swagger/
```

Another alternative to run the project, using Rider:<br>
![Rider run](https://github.com/maycon-mdrs/web-2/assets/81583731/1bd45aef-3268-4032-ac4c-0a4424ae81e0)

Another alternative to run the project, using Visual Studio 2022:<br>
![Visual Studio 2022 run](https://github.com/maycon-mdrs/web-2/assets/81583731/7f3a66d4-7a5f-415f-9a81-124cb9cec4e8)

<br>

# 💻 Run with local machine

> [!warning]
> Remember to configure the `DefaultConnection` in `./VClients.Api/appsettings.json` correctly according to your PostgreSQL database settings. <br>
> For this projector to work, it's necessary to have:
> - [PostgreSQL](https://www.postgresql.org/)
> - [SDK .NET](https://dotnet.microsoft.com/pt-br/download)

Access the VClients.Api package:
```bash
$ cd ./VClients.Api/
```

To run the project, use the following command:
```bash
$ dotnet run
# http://localhost:5138/swagger/
```