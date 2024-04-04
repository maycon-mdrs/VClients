# 💻 VClients

VClients is a project that aims to manage customer information. It provides a backend API for creating, updating, delete and retrieving customer data (CRUD).

The frontend code can be found in the following [repository](https://github.com/LuigiVanin/customer-manager-sample).

<!--ts-->
* [📋 Requirements](#-requirements)
* [⚙️ Project Setup](#-project-setup) 
* [🐋 Run with Docker](#-run-with-docker) 
    * [prompt](#to-run-the-project-use-the-following-command)
    * [Rider](#run-using-rider) 
    * [Virtual Studio 2022](#run-using-visual-studio-2022) 
* [💻 Run with local machine](#-run-with-local-machine) 
* [📁 Folder structure](#-folder-structure) 
<!--te-->

# 📋 Requirements
### For using Docker:
- [Docker](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [Rider](https://www.jetbrains.com/pt-br/rider/) or [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/) (optionals)

### For using local machine:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Rider](https://www.jetbrains.com/pt-br/rider/) or [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/) (optionals)

# ⚙️Project Setup

1. Clone the repository:
  ```bash
  $ git clone https://github.com/maycon-mdrs/VClients.git
  ```

2. Before running the project, ensure to create an .env file following the structure outlined in .env.example. This file should contain all necessary environment variables for Docker to function properly.
  
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
      }
  }
  ```

# 🐋 Run with Docker

> [!warning]
> If the commands via prompts don't work to use `docker compose`, download one of these IDEs and run:
> - [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/)
> - [Rider](https://www.jetbrains.com/pt-br/rider/)

### To run the project, use the following command:
```bash
$ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
# http://localhost:5000/
# http://localhost:5000/swagger/
```

### Run using Rider:
1. When importing the project, select the option docker-compose.yml: Compose Deployment.
  ![Rider run](https://github.com/maycon-mdrs/web-2/assets/81583731/4257c967-1b0a-483e-934a-2c81366dcb99)

2. After that, just click the greeen play button to run the project.
  ![Rider run](https://github.com/maycon-mdrs/web-2/assets/81583731/024d4a18-a001-4857-a561-7c2de4619366)


### Run using Visual Studio 2022:
1. When importing the project, select the option docker-compose.
  ![Visual Studio 2022 run](https://github.com/maycon-mdrs/web-2/assets/81583731/4aa63121-129f-4514-9844-c049d4b2519f)

2. After that, just click the greeen play button to run the project.
    ![Visual Studio 2022 run](https://github.com/maycon-mdrs/web-2/assets/81583731/93f876c1-547c-4906-b5e0-f3241fd1c793)

# 💻 Run with local machine

> [!warning]
> Remember to configure the `DefaultConnection` in `./VClients.Api/appsettings.json` correctly according to your PostgreSQL database settings.

Access the VClients.Api package:
```bash
$ cd ./VClients.Api/
```

To run the project, use the following command:
```bash
$ dotnet run
# http://localhost:5138/
# http://localhost:5138/swagger/
```

# 📁 Folder structure
- `/VClients.Api/*` - contains the backend code (API).
- `/Context` - contains the database context.
- `/Migrations` - contains the database migrations.
- `/Controllers` - contains classes or modules that handle the control layer of the application.
- `/Services` - contains classes and interfaces that define the application's business logic.
- `/DTOs` - contains the DTOs for the application and classes responsible for mapping data between different formats or structures.
- `/Repositories` - contains classes and interfaces that define access to database data.
- `/Models` - contains the classes that represent your application's data structure.
- `/Extensions` - contains classes that extend the functionality of other classes.