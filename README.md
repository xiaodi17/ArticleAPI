# ArticleAPI

## Setup
1. Download .net 5 SDK (https://dotnet.microsoft.com/download)
2. Download docker MSSQL image using :


docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=someThingComplicated1234' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest


3. Go to ArticleAPI and enter command: dotnet restore
4. Go to ArticleAPI\ArticleAPI and enter command: dot net run

## Instructions
### Get: localhost:3000/articles/id

### Post: localhost:3000/articles

Param example:

Title: Title 1

Body: BODY 1

Tags: Tag 1

Tags: Tag 2

### Get: localhost:3000/tag

tagName: Title 1

Date: 20210815

## Solution
I have used .net core web api to complete this project with EF core library, mssql. Sepration of concerns concept has been used in this project. Api project handles the controllers, application project handles the business logic and data access project handles all the repository.

I have used repository patterns in this project. Repository pattern help to separate service from directly manipulate data from the database, hence it helps to reduce the code duplication.

Something interesting I've found in this project is that, it is quite difficult to handle the tag detail query. There are a lot of considerations are required to get the correct result. Firstly, do we allow case insensitive, or duplicated tags in same article. At first glance, I thought it is an easy api test, but at the end I realize that I need to consider a lot of scenarios.


## Assumptions
1. Assume the users using this API are in the same timezone, so when query by date, it is always going to be the correct date
2. Assume every article must include a tag

## Things to be improve
If I have more time, i will spend more time to make a cleaner architecture and adding unit test. I will implement the followings:
1. create a specific logging library
2. create a specific exception library
3. Unit tests
4. Use create database approach first instead of code-first approach. Using code-first approach for local testing purpose it is okay, but it is not good for remote dev server or production because of concurrency.

