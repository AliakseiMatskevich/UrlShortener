# UrlShortener

The application is used to create short urls. To run the application on a local machine you should clone the applicatin from github. You can do it using next command terminal:

Solution consists of 5 projects : 
UrlShortener.Api - used to create api web application, which provides aportunities to create short url, to delete short url, to get urls list and to get url by shortguid;

UrlShortener.ApplicationCore: contains entities, global attributes and interfaces;

UrlShortener.Infrastructure: contains contexts and repositories;

UrlShortener.Web: includes UI, some busines logic, services and their interfaces;

UrlShortener.Tests: includes tests

git clone https://github.com/AliakseiMatskevich/UrlShortener.git

After that if you use not local Sql Server ((localdb)\\MSSQLLocalDB) to test the application you have to change connectionstring UrlShortenerConnection in file appsettings.json in project UrlShortener.Api and connectionstring IdentityConnection in file appsettings.json in project UrlShortener.Web. You have to change server name.

Also if you deployed you have to change UrlApiUrl in file appsettings.json in project UrlShortener.Web and change the variable apiUrl in file url.js acording to new address of API

Technologies used: .NET7, ASP.NET Core Razor Pages, ASP.NET Core Web API, EF Core, Serilog, Identity, Javascript, CSS, Bootstrap,  Github, Automapper, MediatR, xUnit, pattern Repository, pattern CQRS 

