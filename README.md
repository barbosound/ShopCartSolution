# ShoppingCartSolution

## Overview
The **ShoppingCartSolution** is a modular and extensible API designed to manage shopping carts in an e-commerce system. This project follows the principles of **Clean Architecture** and **MediatR**, ensuring a separation of concerns and high maintainability.

## Project Structure
The project is divided into several layers:

- **Domain**: Contains core business logic and entities.
  - `Entities/ShoppingCart.cs`: Defines the shopping cart structure.
  - `Interfaces/IShoppingCartRepository.cs`: Interface for the repository handling cart persistence.

- **Application**: Implements application-specific logic, such as commands and queries.
  - `Commands`: Includes `AddItemCommand` and its handler.
  - `Queries`: Includes `GetShoppingCartQuery` and its handler.

- **Infrastructure**: Handles external concerns like repositories and logging.
  - `Repositories/InMemoryShoppingCartRepository.cs`: In-memory implementation of the repository.
  - `Logging/ShoppingCartLogger.cs`: Logs actions such as creating a cart or adding items.

- **API**: Exposes endpoints to interact with the application.
  - `Controllers/ShoppingCartController.cs`: Handles HTTP requests.

- **Tests**: Ensures the functionality of the project with unit and integration tests.
  - `UnitTests`: Validates logic in isolation.

## How to Run the Project

1. Build the solution:
   ```bash
   dotnet build
   ```

2. Run the API:
   ```bash
   dotnet run --project ShoppingCartSolution.API
   ```

3. Access the API:
   - Base URL: `http://localhost:5000`
   - Swagger: `http://localhost:5000/swagger`

   **We MUST use Swagger UI to test the application.**

## Running Tests

1. Navigate to the `Tests` directory:
   ```bash
   cd ShoppingCartSolution.Tests
   ```

2. Run all tests:
   ```bash
   dotnet test
   ```

## Key Features

- **Add Items to Cart**:
  Endpoint to add products to the user's shopping cart.
  ```http
  POST /api/ShoppingCart
  Content-Type: application/json
  {
    "UserId": "01",
    "ProductId": "10001",
    "Quantity": 2
  }
  ```

- **Get Cart**:
  Endpoint to retrieve the contents of the user's shopping cart.
  ```http
  GET /api/ShoppingCart?userId=test_user
  ```

## Logging
Logging is implemented via `ShoppingCartLogger`:
- Logs creation of shopping carts.
- Logs addition of items to carts.

## Extensibility
- **Replace In-Memory Repository**: Swap `InMemoryShoppingCartRepository` with a database-backed implementation.
- **Add New Features**: Extend the `Application` layer with additional commands and queries.
