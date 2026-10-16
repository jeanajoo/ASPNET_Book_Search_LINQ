**ASP.NET Core MVC Book Search & LINQ Query Engine**

A multi-criteria book search and filtering engine developed in C# using ASP.NET Core 8.0 MVC, LINQ (Language Integrated Query), and Entity Framework Core. 

**Project Overview**

The Book Search & LINQ application provides a performant, relational database search interface for querying extensive library and bookstore catalogs. By leveraging complex C# LINQ queries against Entity Framework Core, the system executes real-time, multi-parameter filtering while maintaining strict database optimization and SQL injection prevention.

Tech Stack & Architecture
- Backend: C#, ASP.NET Core 8.0 MVC
- Query Engine: LINQ (Language Integrated Query), Entity Framework Core (Code-First)
- Database: Azure SQL Database / Microsoft SQL Server
- Frontend: Razor Views, HTML5, CSS3, Bootstrap 5
- Tools & Environment: Visual Studio, Git & GitHub, Azure App Service

Key Features & System Architecture
Advanced LINQ Search Engine
- Multi-Criteria Filtering: Allows simultaneous AND/OR querying across Book Title, Author, Genre, Publication Date, and ISBN.
- Range & Boundary Queries: Evaluates numeric and date conditions (e.g., price ranges, minimum star ratings, publication year windows).
- Dynamic Sorting & Pagination: Implements ascending/descending sorting by title, author, price, and publication date alongside record count metrics ("Displaying X of Y records").

Relational Database Optimization
- Deferred Execution: Utilizes LINQ IQueryable chaining to build efficient SQL queries executed at the database level rather than in-memory.
- Safe Character Parsing: Ensures full support for special characters and single quotes without exposing the application to SQL injection vulnerabilities.

Interactive User Experience
- Detailed book overview pages displaying author details, price, genre categorization, availability, and user ratings.
- Clean, responsive Razor View layout powered by Bootstrap 5 for seamless desktop and mobile browsing.

Interactive User Experience
Detailed book overview pages displaying author details, price, genre categorization, availability, and user ratings.

Clean, responsive Razor View layout powered by Bootstrap 5 for seamless desktop and mobile browsing.
