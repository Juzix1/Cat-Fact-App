# Cat Fact App Solution

This repository contains three C# projects:
- **CatFactLibrary** (Class Library)
- **CatFact_ConsoleApp** (Console Application)
- **CatFact_WebApp** (Blazor Web Application)

---

## 1. CatFactLibrary
A reusable class library that provides core logic and services for working with cat facts.

### Features
- Models for cat facts
- Services for managing, requesting, and storing cat facts
- Can be referenced by other .NET projects
- Checks for duplicates in CatFacts file
- Retries connection to API host

### Structure
- `Model/FactModel.cs`: Data model for cat facts
- `Service/`: Contains service interfaces and implementations:
  - `CatFactManager/`
  - `FileService/`
  - `RequestService/`

---

## 2. CatFact_ConsoleApp
A simple .NET console application that demonstrates usage of the `CatFactLibrary`.

### Features
- Fetches and displays cat facts in the terminal
- Example of dependency injection and library usage

### How to Run
1. Build the solution:
   ```powershell
   dotnet build
   ```
2. Run the console app:
   ```powershell
   dotnet run --project CatFact_ConsoleApp/CatFact_ConsoleApp.csproj
   ```

---

## 3. CatFact_WebApp
A Blazor application for browsing cat facts in the browser.

### Features
- Modern web UI using Blazor
- Fetches and displays cat facts
- Uses `CatFactLibrary` for business logic

### How to Run
1. Build the solution:
   ```powershell
   dotnet build
   ```
2. Run the web app:
   ```powershell
   dotnet run --project CatFact_WebApp/CatFact_WebApp.csproj
   ```
3. Open the provided URL in your browser (usually `https://localhost:7257/` or similar).

---

## Solution Structure
```
CatFactLibrary.sln
CatFactLibrary/         # Class library
CatFact_ConsoleApp/     # Console app
CatFact_WebApp/         # Blazor web app
```

---

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code (recommended)

---

