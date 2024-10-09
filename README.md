# Banking System Application

## Assumptions
- **Minimum Transaction**: The minimum transaction amount is set to `0.01`.
- **Overdraft Limit**: The overdraft limit is applicable only to checking type accounts.
- **Account ID**: The application uses a `GUID` as the account ID. In a real-world scenario, it would likely be a formatted string.

## Run the Application

To set up and run the application, follow these steps:

1. **Restore the .NET Packages**
   ```bash
   dotnet restore

2. **Update Connection String**
Open the app configuration file (e.g., appsettings.json).
Replace the existing connection string with the one pointing to your database.

3. **Apply Migrations and Seed Data**
   Run the following command to update the database:
   ```bash
   update-database
The necessary account types and some sample accounts will be seeded automatically for testing.

## To-Do List
Some additional features and improvements that are planned for future development include:

- Authentication
- Authorization
- Logging - Partially implemented
- Interest Calculation
- Unit Test
