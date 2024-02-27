Here are some of the things I learned about in this course:- Creating the Angular App and ASP.NET Core Web API. Adding a client-side login and register function to our Angular application. Adding routing to the Angular application and securing routes. Using Layer Architecture, Automapper in ASP.NET Core. Building a great-looking UI using Bootstrap. Adding photo upload functionality as well as a cool-looking gallery in Angular. Angular Template forms and Reactive forms and validation paging, sorting, and filtering. Publishing the application to Firebase, IIS, and then on Azure.

Migration commands:- 
  Demo:
    Create: dotnet ef migrations add InitDatabase --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose 
    Update: dotnet ef database update InitDatabase --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose
    Remove: dotnet ef migrations remove --project YourDataAccessLibraryName -s YourWebProjectName -c YourDbContextClassName --verbose
  
  For this project:
    Create: dotnet ef migrations add InitDatabase --project HouseRentWebApi.Common -s HouseRentWebApi -c HouseRentContext --verbose
    Update: dotnet ef database update InitDatabase --project HouseRentWebApi.Common -s HouseRentWebApi -c HouseRentContext --verbose
    Remove: dotnet ef migrations remove InitDatabase --project HouseRentWebApi.Common -s HouseRentWebApi -c HouseRentContext --verbose
