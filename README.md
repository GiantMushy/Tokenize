# Tokenize API

Minimal JWT-secured books API.

Run
- From Api/: `dotnet ef database update` (creates SQLite token.db)
- `dotnet run` (use the URL printed on startup, e.g., http://localhost:5262 or https://localhost:7017)

Config (appsettings.json)
- ConnectionStrings: TokenizeDbConnectionString
- TokenAuthentication: Issuer, Audience, SigningKey, Salt

Routes
- POST /Account/register
  - Registers a user.
  - Body (JSON): { "fullName": "...", "emailAddress": "...", "password": "..." }
  - Returns: 201 Created

- POST /Account/login
  - Authenticates and returns a JWT.
  - Body (JSON): { "emailAddress": "...", "password": "..." }
  - Returns: 200 OK with token string

- GET /books
  - Requires Bearer token. Returns all books.

- GET /books/{id}
  - Requires Bearer token. Returns one book.

- POST /books
  - Requires Bearer token. Creates a book.
  - Body: JSON matching your BookInputModel

Postman
1) Register (optional), then Login to get the token.
2) For books endpoints, set Header: Authorization = Bearer <token>.
3) Set Header: Content-Type = application/json.
4) Use the exact base URL/port printed by the app (e.g., http://localhost:5262).