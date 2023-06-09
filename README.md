# **Sweets and Treats**

### By _Max Betich_

## Technologies Used

* _C#/.NET v6_
* _ASP.NET Core MVC_
* _MySQL 8.0_
* _Swagger_

## Description
This application is an api that functions as an archive for different animals being kept by an animal shelter. The endpoints can be viewed using Swagger or Postman.

## Setup/Installation Requirements
* Clone project from this [GitHub repository](https://github.com/MaxBetich/AnimalShelterAPI.git) to your desktop.
* Navigate to the AnimalShelter directory inside this repo in your terminal and create a new file called `appsettings.json`.
* Within `appsettings.json` put in the following code, replacing the `[UID HERE]` and `[PWD HERE]` values with your own username and password for MySQL.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=animal_shelter;uid=[UID HERE];pwd=[PWD HERE];"
  }
}
```
* Run the command `dotnet restore` in your terminal to initialize the program.
* Run the command `dotnet ef database update` after ensuring your MySQL workbench is running to create the project database.
* Within the AnimalShelter directory run `dotnet watch run` in the terminal to open the Swagger interface in your default browser.

## API Documentation

### Versioning

The application utilizes versioning to support stable feature changes. V1 represents the original functional version of the code, while V2 implements paging support for controlling page sizes.

### Pagination

By default the application will return all valid results when making a GET request. Optionally, the number of results and desired page to be displayed can be adjusted by providing a pageNumber and pageSize parameter when making the request.

#### Example Query
```json
https://localhost:5001/api/v2/Animals?pageNumber=2&pageSize=2
```

### Endpoints

Base URL: https://localhost:5001

#### HTTP Request Structure

* Get /api/v{versionNumber}/Animals/random
* Get /api/v{versionNumber}/Animals/popular
* Delete /api/v{versionNumber}/Animals/{id}
* Put /api/v{versionNumber}/Animals/{id}
* Get /api/v{versionNumber}/Animals/{id}
* Get /api/v{versionNumber}/Animals
* Post /api/v{versionNumber}/Animals

#### Example Query

```json
https://localhost:5001/api/v2/Animals/1
```
#### Sample JSON Response

```json
{
  "animalId": 1,
  "animalType": "turtle",
  "animalName": "Myrtle",
  "animalAge": 11
}
```

#### Path Parameters
```json
**Parameter** || **Type** || **Default** || **Required** || **Description**

animalType    ||  string  ||     none    ||     false    ||  Returns matches based on type of animal

animalAge     ||   int    ||     none    ||     false    ||  Returns matches based on age of animal

pageSize      ||   int    ||     none    ||     false    ||  Controls the number of results per page when used in conjunction with pageNumber

pageNumber    ||   int    ||     none    ||     false    ||  Controls which page of results to return when used in conjunction with pageSize
```
## Known Bugs

None

## License

MIT

Copyright (c) _2023_ _Max Betich_