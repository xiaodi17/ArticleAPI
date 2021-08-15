# ArticleAPI

## Setup
1. Download .net 5 SDK (https://dotnet.microsoft.com/download) and mssql server.
2. Update connection string, user name and password in appsettings.json
3. Go to ArticleAPI\ArticleAPI and enter command: dot net run

## Solution
I have used .net core web api to complete this project with EF core library, mssql with repository patterns.

## Assumptions
1. Assume the users using this API are in the same timezone, so when query by date, it is always going to be the correct date
2. Assume every article must include a tag

## Things to be improve
If I have more time, i will spend more time to make a cleaner architecture and adding unit test. I will implement the followings:
1. create a specific logging library
2. create a specific exception library
3. Unit tests
4. Use create database approach first instead of code-first approach. Using code-first approach for local testing purpose it is okay, but it is not good for remote dev server or production because of concurrency.

