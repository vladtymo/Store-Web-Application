## Sample Web Application with Clean Architecture implementation

### Getting Started

1. Clone the repository:
  ```sh
  git clone https://github.com/vladtymo/Store-Web-Application.git
  ```
2. Open solution in Visual Studio.
3. Open the **Package Manager Console** from the Tools menu, select NuGet Package Manager > Package Manager Console.
4. At the `PM>` prompt enter the following commands to create the database locally:
  ```sh
  update-database
  ```
5. Run project.

#### *Checkout the `n-layer-architecture` branch to see the example of the traditional N-Layer structure.

## About Clean Architecture

A starting point for Clean Architecture with ASP.NET Core. [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) is just the latest in a series of names for the same loosely-coupled, dependency-inverted architecture. You will also find it named [hexagonal](http://alistair.cockburn.us/Hexagonal+architecture), [ports-and-adapters](http://www.dossier-andreas.net/software_architecture/ports_and_adapters.html), or [onion architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/).

### The Core Project

The Core project is the center of the Clean Architecture design, and all other project dependencies should point toward it. As such, it has very few external dependencies.

- Entities
- Aggregates (does not exist in this solution)
- Domain Events (does not exist in this solution)
- DTOs
- Interfaces
- Event Handlers (does not exist in this solution)
- Domain Services
- Specifications

### The **Infrastructure** Project

Most of your application's dependencies on external resources should be implemented in classes defined in the Infrastructure project. These classes should implement interfaces defined in Core. If you have a very large project with many dependencies, it may make sense to have multiple Infrastructure projects (e.g. Infrastructure.Data), but for most projects one Infrastructure project with folders works fine. The sample includes data access and domain event implementations, but you would also add things like email providers, file access, web api clients, etc. to this project so they're not adding coupling to your Core or UI projects.

### The **Web** Project

The entry point of the application is the ASP.NET Core web project. This is actually a console application, with a `public static void Main` method in `Program.cs`. It currently uses the default MVC organization (Controllers and Views folders) as well as most of the default ASP.NET Core project template code. This includes its configuration system, which uses the default `appsettings.json` file plus environment variables, and is configured in `Program.cs`. The project delegates to the `Infrastructure` project to wire up its services using dependency injection.
