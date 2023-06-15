# **Sweets and Treats**

### By _Max Betich_

## Technologies Used

* _C#/.NET v6_
* _ASP.NET Core MVC_
* _MySQL 8.0_
* _Swagger_
* _Postman_

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
* Within the AnimalShelter directory run `dotnet run` in the terminal to have access to the application in Postman or your browser.

## API Documentation

### Swagger

To use the application with the Swagger interface, run the command `dotnet watch run` within the AnimalShelter directory, or the command `dotnet run` and input the following URL into your browser: http://localhost:5000/swagger

### Versioning

The application utilizes versioning to support stable feature changes. V1 represents the original functional version of the code, while V2 implements paging support for controlling page sizes, and includes a bugfix to enable delete functionality.

### Pagination

By default the application will return all valid results when making a GET request. Optionally, the number of results and desired page to be displayed can be adjusted by providing a pageNumber and pageSize parameter when making the request.

#### **Example Query**
```json
https://localhost:5001/api/v2/Animals?pageNumber=2&pageSize=2
```

### Endpoints

Base URL: https://localhost:5001

#### **HTTP Request Structure**

* Get /api/v{versionNumber}/Animals/random
* Get /api/v{versionNumber}/Animals/popular
* Delete /api/v{versionNumber}/Animals/{id}
* Put /api/v{versionNumber}/Animals/{id}
* Get /api/v{versionNumber}/Animals/{id}
* Get /api/v{versionNumber}/Animals
* Post /api/v{versionNumber}/Animals

#### **Example Query**
* Get/{id}
```json
https://localhost:5001/api/v2/Animals/1
```
#### **Sample JSON Response**

```json
{
  "animalId": 1,
  "animalType": "turtle",
  "animalName": "Myrtle",
  "animalAge": 11
}
```

#### **Path Parameters**
```json
**Parameter** || **Type** || **Default** || **Required** || **Description**

animalType    ||  string  ||     none    ||     false    ||  Returns matches based on type of animal

animalAge     ||   int    ||     none    ||     false    ||  Returns matches based on age of animal

pageSize      ||   int    ||     none    ||     false    ||  Controls the number of results per page when used in conjunction with pageNumber

pageNumber    ||   int    ||     none    ||     false    ||  Controls which page of results to return when used in conjunction with pageSize
```

#### **Additional Requirements for POST Request**
* Endpoint for POST:
```json
https://localhost:5001/api/v2/Animals
```
* When making a POST request, you must submit a body with the animal's information:
```json
{
  "animalType": "cat",
  "animalName": "Bruce",
  "animalAge": 7
}
```
* Note that the animal's `animalId` property is generated automatically by the database, and should not be included in the body.

#### **Additional Requirements for PUT Request**
* Example Endpoint for PUT:
```json
https://localhost:5001/api/v2/Animals/2
```
* When making a PUT request, the body must also include the `animalId` property of the animal to be updated:
```json
{
  "animalId": 2,
  "animalType": "cat",
  "animalName": "Bruce",
  "animalAge": 8
}
```
## Known Bugs

None

## License

MIT

Copyright (c) _2023_ _Max Betich_