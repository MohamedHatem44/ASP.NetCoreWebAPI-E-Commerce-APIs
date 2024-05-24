# ASP.NetCoreWebAPI-E-Commerce-APIs

## E-Commerce Web APIs
This project consists of a set of Web APIs developed using ASP.NET Core for an E-Commerce platform. It follows a layered architecture with separate layers for API, Business Logic, and Data Access. The project utilizes Microsoft SQL Server for data storage and Entity Framework Core for database operations. Additionally, Identity User is employed for user authentication and authorization.

## Table of Contents:
    1- Introduction
    2- Technologies Used
    3- Project Structure
    4- Folder Structure
    5- API Endpoints
    6- Contributors

## Introduction
The E-Commerce Web APIs project aims to provide a robust and scalable API platform for online shopping. It facilitates various functionalities such as managing products, categories, orders, shopping carts, and user accounts through HTTP requests.

## Technologies Used
    1- ASP.NET Core Web API
    2- Entity Framework Core
    3- Microsoft SQL Server
    4- Identity User
    5- Visual Studio        

## Project Structure
The project follows an N-tier architecture with the following layers:

#### API Layer: Contains controllers that define the API endpoints.
#### Business Logic Layer (BL): Contains managers responsible for business logic and operations.
#### Data Access Layer (DAL): Contains database context and entities for interacting with the database.

## Folder Structure
The project follows a standard n-tier architecture with the following folder structure:

### API
    Controllers
### BL
    Managers
    Dtos
    Mapper
    Validators
### DAL
    Repositories
    Entities
    Context
    UnitOfWork


## API Endpoints


### AuthController
#### POST /api/auth/login: Login with credentials.
#### POST /api/auth/register: Register a new user.

<hr/>

### ImagesController
#### POST /api/images/Upload: Upload an image file and get the image URL.

<hr/>

### UsersController
#### GET /api/users: Get all users without details.
#### GET /api/users/GetAllUsersWithOrders: Get all users with orders.
#### GET /api/users/GetAllUsersWithShoppingCart: Get all users with shopping carts.
#### GET /api/users/{id}: Get a specific user by ID without details.
#### POST /api/users: Create a new user.
#### PATCH /api/users/{id}: Update a specific user by ID.
#### DELETE /api/users/{id}: Delete a specific user by ID.

<hr/>

### CategoriesController
#### GET /api/categories: Get all categories without products.
#### GET /api/categories/CategoriesWithProducts: Get all categories with products.
#### GET /api/categories/{id}: Get a specific category by ID without products.
#### GET /api/categories/{id}/CategoriesWithProducts: Get a specific category by ID with products.
#### POST /api/categories: Create a new category.
#### PUT /api/categories/{id}: Update a specific category by ID.
#### DELETE /api/categories/{id}: Delete a specific category by ID.

<hr/>

### BrandsController
#### GET /api/brands: Get all brands without products.
#### GET /api/brands/BrandsWithProducts: Get all brands with products.
#### GET /api/brands/{id}: Get a specific brand by ID without products.
#### GET /api/brands/{id}/BrandsWithProducts: Get a specific brand by ID with products.
#### POST /api/brands: Create a new brand.
#### PUT /api/brands/{id}: Update a specific brand by ID.
#### DELETE /api/brands/{id}: Delete a specific brand by ID.

<hr/>

### ProductsController
#### GET /api/products: Get all products without details.
#### GET /api/products/ProductsDetails: Get all products with details.
#### GET /api/products/ProductsDetails/search: Get products with optional search parameters.
#### GET /api/products/ProductsDetails/GenericSearch: Get products with optional generic search parameters.
#### GET /api/products/{id}: Get a specific product by ID without details.
#### GET /api/products/{id}/ProductsDetails: Get a specific product by ID with details.
#### POST /api/products: Create a new product.
#### PATCH /api/products/{id}/ProductsDetails: Update a specific product by ID.
#### DELETE /api/products/{id}: Delete a specific product by ID.

<hr/>

### ShoppingCartsController
#### GET /api/shoppingcarts: Get all shopping carts with details.
#### GET /api/shoppingcarts/UserShoppingCart: Get the shopping cart by user claims.
#### GET /api/shoppingcarts/UserShoppingCart/{userId}: Get the shopping cart by user ID.
#### POST /api/shoppingcarts/AddToCart: Add a product to the shopping cart.
#### DELETE /api/shoppingcarts/{productId}: Remove a specific item from the shopping cart by product ID.
#### DELETE /api/shoppingcarts/RemoveAllItemsFromCart: Remove all items from the shopping cart by user claims.
#### PATCH /api/shoppingcarts: Edit the item quantity in the shopping cart.

<hr/>

### OrdersController
#### GET /api/orders: Get all orders with details.
#### GET /api/orders/UserOrders: Get orders by user claims.
#### GET /api/orders/UserOrders/{userId}: Get orders by user ID.
#### POST /api/orders: Create a new order.
#### POST /api/orders/CreateOrderFromCart: Create an order from the shopping cart.
#### PUT /api/orders/{id}: Update a specific order by ID.
#### DELETE /api/orders/{id}: Delete a specific order by ID.

<hr/>

Contributors:
Mohamed Hatem
