# JWT-API
Json web token
This Project is related to make demo of access API using Json web token

Techstack
1] dotnet core 8
2' Entity frame work

--> Steps as follows 

dn-3] Microsoft.EntityFrameworkCore.Sqlite : Package Name
dn-3.1] Microsoft.EntityFrameworkCore.Design - Package Name
dn-3.2] Create folder(Data) in API and add dbcontext file inside it
dn-4] 	dotnet tool install --global dotnet-ef --version 5.0.1 - command
dn-4-i]	dotnet tool update --global dotnet-ef 
dn 4-ii] 	dotnet ef migrations add InitialCreate -o Data/Migrations(folder path) -Add migration
dn 4-iii]	dotnet ef database update - Create database form migration 
      
dn-5] type Ctr+Shift+p select .Net : Generate Assets for build and debug 
dn-6] System.IdentityModel.Tokens.Jwt : Install this package from nugget library
dn-7] Microsoft.AspNetCore.Authentication.JwtBearer  3.1.7


AutoMapper.Extensions.Microsoft.Dependency 12.0.0
dn-9] Install  Cloudinary Nuget package V 1.11.0 - for cloud photo gallery 
dn-10] Install Microsoft.AspNetCore.Identity.EntityFrame - for Apnet Identity
