# Yummmy API

Yummmy API is a comprehensive RESTful web service built with ASP.NET Core that powers the backend for a restaurant management system. It provides endpoints for managing various aspects of a restaurant business including menu items, reservations, events, testimonials, and more.

## Features

- **Menu Management**: Full CRUD operations for menu categories and products
- **Reservation System**: Handle table bookings and customer reservations
- **Event Management**: Create and manage special events and promotions (YummyEvents)
- **Testimonials**: Collect and display customer feedback
- **Chef Profiles**: Manage chef information and details
- **Contact System**: Handle customer inquiries and messages
- **Feature Management**: Highlight special features or services
- **RESTful API**: Well-structured endpoints following REST principles
- **Data Validation**: Robust input validation with FluentValidation
- **Documentation**: Swagger/OpenAPI integration for API documentation
- **Cross-Origin Support**: CORS enabled for frontend integration

## Technologies

- **Framework**: .NET 9.0
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 9.0
- **API Documentation**: Swagger/OpenAPI (Swashbuckle)
- **Validation**: FluentValidation
- **Object Mapping**: AutoMapper
- **Cross-Origin**: CORS enabled
- **Dependency Injection**: Built-in .NET Core DI
- **Logging**: Built-in logging framework

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Atakan-Aktakka/Yummmy.Api.git
   cd Yummmy.Api
   ```

2. Configure the database connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "PostgreSql": "Host=your_host;Database=your_database;Username=your_username;Password=your_password"
     }
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation at `https://localhost:5001/swagger` or `http://localhost:5000/swagger`

## API Endpoints

### Yummy Events
- `GET /api/YummyEvents` - Get all events
- `GET /api/YummyEvents/{id}` - Get event by ID
- `POST /api/YummyEvents` - Create a new event
- `PUT /api/YummyEvents` - Update an existing event
- `DELETE /api/YummyEvents/{id}` - Delete an event

### Other Controllers
- **Categories**: `GET/POST/PUT/DELETE /api/Categories`
- **Chefs**: `GET/POST/PUT/DELETE /api/Chefs`
- **Contacts**: `GET/POST/PUT/DELETE /api/Contacts`
- **Features**: `GET/POST/PUT/DELETE /api/Features`
- **Messages**: `GET/POST/PUT/DELETE /api/Messages`
- **Products**: `GET/POST/PUT/DELETE /api/Products`
- **Reservations**: `GET/POST/PUT/DELETE /api/Rezervations`
- **Services**: `GET/POST/PUT/DELETE /api/Services`
- **Testimonials**: `GET/POST/PUT/DELETE /api/Testimonials`

## Data Models

The application uses the following main entities:

- **Category**: Represents menu categories (e.g., Appetizers, Main Course, Desserts)
- **Chef**: Stores information about the restaurant's chefs
- **Contact**: Manages contact information and customer inquiries
- **Feature**: Highlights special features or services of the restaurant
- **Image**: Handles image storage and management
- **Message**: Stores customer messages and inquiries
- **Product**: Represents menu items with details like price and description
- **Reservation**: Manages table bookings and customer reservations
- **Service**: Represents the services offered by the restaurant
- **Testimonial**: Stores customer feedback and reviews
- **YummyEvent**: Manages special events, promotions, or activities

## Error Handling

The API follows RESTful conventions for error responses:
- `200 OK`: Successful GET requests
- `201 Created`: Resource successfully created
- `204 No Content`: Successful DELETE requests
- `400 Bad Request`: Invalid request data
- `404 Not Found`: Requested resource not found
- `500 Internal Server Error`: Server-side error

## Validation

Input validation is implemented using FluentValidation to ensure data integrity. Each DTO has corresponding validation rules that check for required fields, string lengths, and proper formatting.

## Configuration

Configuration is managed through `appsettings.json` with support for environment-specific settings. The main configurations include:
- Database connection strings
- CORS policies
- Logging settings

## Testing

The API includes unit tests for controllers and services. To run the tests:

```bash
dotnet test
```

## Deployment

The application can be deployed to any platform that supports .NET Core applications, such as:
- Azure App Service
- AWS Elastic Beanstalk
- Docker containers
- Linux/Windows servers with Kestrel

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or feedback, please open an issue in the repository.

## Acknowledgments

- [ASP.NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)
