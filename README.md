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

### Endpoints

Base URL: [https://localhost:5001]

#### HTTP Request Structure

Get /api/Animals/random
Get /api/Animals/popular
Delete /api/Animals/{id}
Put /api/Animals/{id}
Get /api/Animals/{id}
Get /api/Animals
Post /api/Animals

#### Example Query

```json
https://localhost:5001/api/Animals/1
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

**Parameter** || **Type** || **Default** || **Required** || **Description**

animalType   ||     string  ||      none     ||      false     ||     Returns matches based on type of animal

animalAge    ||      int    ||      none     ||      false     ||     Returns matches based on age of animal

## Known Bugs

None

## License

MIT

Copyright (c) _2023_ _Max Betich_