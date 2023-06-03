# BlogSite

**Software Architecture**
---
![BlogSiteArchitecture drawio (9)](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/c73786c3-cd7f-4e69-9b14-ffd6bbc6dfb8)

**Web Application Images**
---
Login and register
![login](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/4cbfdb1c-d779-442d-92f0-7298a4ee16a0)

Home
![Home](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/ab790750-d107-4238-85f3-fd3162bf9c15)

User Reaction
![blogOyla](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/0185644b-0fdb-4811-8d84-0bf125be3524)

Blog Reading Page
![blogIcerek](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/0a95e8df-b46c-42b3-bd65-d0ea939dfdae)

User Dashboard
![userHome](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/89c21423-1e40-4522-9a0c-689668966e1d)

Admin Dashboard
![adminIndex](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/bc125645-a64c-4b89-8110-42be840ce472)

**Solution Structure**
---
![Screenshot 2023-05-18 182806](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/43c669b9-0699-4b82-9c2d-209fde339e82)

**Database Diagram**
---
![BlogSiteDB drawio (4)](https://github.com/Serhatkacmaz/.Net7-ClassicalArchitecture-BlogSite/assets/56757412/bcb92859-7bfe-46f6-8bb3-5a4553ef4883)

**Code First**
---
The Entity Framework uses Code First to create the project's database on a code-based basis.

**N-Layer**
---
Organizes the project according to the principle of N-Layer architecture. It facilitates the maintenance and scalability of the code by making a clear Decoupling of responsibilities between layers.

**JWT Token**
---
It uses JSON Web Token (JWT) for authentication and authorization. It provides user authentication in Web APIs and provides security.


**Unit Of Work Pattern**
---
It uses the Unit of Work design pattern to manage operations as a group. It provides consistency by grouping database operations, such as initializing, saving, and retrieving a transaction.

**Options Pattern**
---
It uses the Options Pattern to edit the configuration values. This collects the application configuration in a separate class and facilitates access to the configuration values.

**FluentValidation**
---
It uses the FluentValidation library for input validation. It provides a useful method for validating entries and handling errors.

**AutoMapper**
---
It uses the AutoMapper library to facilitate data mapping operations between objects Decently. Simplifies the exchange of data between D Dec (Data Transfer Objects) and model objects.

**AutoFac**
---
It uses the AutoFac library for Dependency Injection. It manages the process of object creation and solving dependencies and improves the testability of the code.

**ASP.NET Core Web API**
---
To create RESTful APIs ASP.NET It uses the Core Web API framework.

**ASP.NET Core Web MVC**
---
To provide a web-based user interface ASP.NET It uses the Core Web MVC framework.

**Repository Pattern**
---
Implements the Repository design pattern for database operations. It is used to abstract database operations and increase the testability of code.

**Static Factory Pattern**
---
It uses a static factory class that performs object creation operations. This makes the object creation process centralized and makes the code more readable and easier to maintain.
