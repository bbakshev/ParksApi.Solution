# _National Parks API_

#### By: Brishna Bakshev

#### _This web API will list available national parks._

### <u>Table of Contents</u>
* <a href="#Description">Description</a>
* <a href="#Technologies-Used">Technologies Used</a>
* <a href="#Setup/Installation-Requirements">Setup/Installation Requirements</a>
* <a href="#Example-Query">Example Query and JSON Response</a>
* <a href="#API-Endpoints">API Endpoints</a>
* <a href="#Path-Parameters">Path Parameters</a>
* <a href="#Pagination">Pagination</a>
* <a href="#Known-Bugs">Known Bugs</a>
* <a href="#License">License</a>

## Description

_Parks API is an API that when requested to GET all parks, will return a response containing all parks with page number and number of items per page. Parks API is seeded with 10 parks in the database, but also has full Create, Update, and Delete functionality for any new or existing park._

## Technologies Used

* _C#_
* _.Net 6_
* _ASP.NET Core Web API_
* _Visual Studio Code 2019_
* _MySql_
* _MySql Workbench_
* _Entity Framework Core 6_
* _Pomelo Entity Framework Core 6 MySql_
* _ASP.NET Core Identity_
* _(Optional) Postman_

## Setup/Installation Requirements

* _Install .Net 6 SDK:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
* _Setup MySql Workbench:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* _Clone this repo to a local directory_
* _Navigate to the local directory (YourPath/ParksApi.Solution/ParksApi) and create a new file "appsettings.json" 
* _Open this file with Visual Studio Code 2019 and add:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}

```
IMPORTANT: replace [YOUR-USERNAME-HERE] and [YOUR-PASSWORD-HERE] with the your own user and password values, and [YOUR-DB-NAME] with any name you'd like to call the database, i.e. "national_parks_api"_

#### Database Migration Set-up:
1. In the root directory, run `dotnet tool install --global dotnet-ef --version 6.0.0`.
2. Navigate to the production directory and run `dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0`.
3. Run `dotnet ef migrations add Initial` to create the initial migration.
4. Update the database with `dotnet ef database update`.

#### Running the Project:
1. Open your shell (e.g., Terminal or GitBash) and add your .gitignore file and commit it before adding any other files. 
2. Navigate to this project's production directory called "ParksApi". 
3. In the command line, run the command `dotnet run` to compile and execute the console application. Optionally, you can run `dotnet build` to compile this console app without running it.
4. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
5. Open the browser to _https://localhost:5000_ or _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## API Endpoint Guide and Example
```
GET http://localhost:5000/api/parks/
```
* _Returns all parks in the database_

Postman Example:  
Start a new GET request in Postman and enter the above URL. Click Send. You should see a JSON response with all quotes in the database.  

Example Return Response:
```
[
  {
    "parkId": 1,
            "name": "Crater Lake",
            "state": "Oregon",
            "description": "Crater Lake is a caldera lake in the U.S. state of Oregon. It is the deepest lake in the United States, with a maximum depth of 1,949 feet (594 m). The lake is famous for its water clarity, with a visibility of 42 feet (13 m) in 1997, and is the fifth deepest in the world.",
            "established": "1902"
        },
        {
            "parkId": 2,
            "name": "Yellowstone",
            "state": "Wyoming",
            "description": "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872.",
            "established": "1872"
        }
]
```

```
GET http://localhost:5000/api/parks/{id}
```
* _Returns a park with the matching parkId_
* _Replace {id} with the parkId you would like to GET_
* _Tip: You can find all parkId's from requesting GET http://localhost:5000/api/parks/ end point_

Postman Example:  
Start a new GET request in Postman and enter the above URL. Click Send. You should see a JSON response with the quote that matches the parkId you entered.  
Example Return Response for parkId equals 2:
```
{
    "parkId": 2,
    "name": "Yellowstone",
    "state": "Wyoming",
    "description": "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872.",
    "established": "1872"
}
```
```
POST http://localhost:5000/api/parks/
```
* _Creates a new park in the database_

Postman Example:  
Start a new POST request in Postman and enter the above URL. A POST request must have a request body when sending. 
To create a request body, click the Body tab located under where you entered the url, and select raw. In the dropdown menu to the right change Text to JSON.
Enter a JSON request body replacing "string" with the value you would like to enter.  
Example Request Body:
```
{
  "parkId": 0,
  "name": "string",
  "state": "string",
  "description": "string",
  "established": "string"
}
```
Click Send. You should see a JSON response with the park that you entered.

```
PUT http://localhost:5000/api/parks/{id}
```
* _Updates a park in the database_

Postman Example:  
Start a new PUT request in Postman and enter the above URL. A PUT request must have a request body when sending.
To create a request body, click the Body tab located under where you entered the url, and select raw. In the dropdown menu to the right change Text to JSON.
Enter a JSON request body replacing "string" with the values you would like to enter and 0 with the parkId you would like to update. Note: You must enter an parkId in the request body, and the entire body's values must still be assigned with either new or old values.  
Example Request Body:
```
{
    "parkId": 0,
    "name": "string",
    "state": "string",
    "description": "string",
    "established": "string"
}
```
Click Send. You should see a JSON response with the park that you updated.

```
DELETE http://localhost:5000/api/parks/{id}
```
* _Deletes a park in the database_

Postman Example:  
Start a new DELETE request in Postman and enter the above URL. Click Send. You should see a return status of 204 No Content.  
Confirm the quote was deleted by requesting GET http://localhost:5000/api/parks/{id} and seeing a return status of 404 Not Found.


## Optional Path Parameters When Using Get All Quotes Endpoint
| Parameter | Type | Required | Description |
| :---: | :---: | :---: | --- |
| Name | String | Not Required | Returns the name of the park |
| State | String | Not Required | Returns which state the parks is located |
| Description | String | Not Required | Returns a brief description of the park |
| Established | String | Not Required | Returns the year the park was established |

## Example Query
```
https://localhost:5001/api/parks?name=Yosemite
```

## Example Returned JSON Response
```
{
    "parkId": 3,
    "name": "Yosemite",
    "state": "California",
    "description": "Yosemite National Park is an American national park located in the western Sierra Nevada of Central California, bounded on the southeast by Sierra National Forest and on the northwest by Stanislaus National Forest. The park is managed by the National Park Service and covers an area of 747,956 acres (1,169.22 sq mi; 3,026.18 km2) and sits in four counties: Tuolumne, Mariposa, and Madera in Central California, and Mono County, adjacent to the eastern boundary of the park.",
    "established": "1890"
}
```

## Further Exploration: Pagination
* _Paging refers to getting partial results from an API._ 
* _Change the pagesize to your desired number in the URL: https://localhost:5001/api/Parks?name=Yosemite&page=1&pageSize=5_

## Known Bugs

N/A

## License
Enjoy the site! If you have questions or suggestions for fixing the code, please contact me!

[MIT](https://github.com/git/git-scm.com/blob/main/MIT-LICENSE.txt)

Copyright (c) 2023 Brishna Bakshev