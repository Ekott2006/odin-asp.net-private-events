# Private Events: A Private Eventbrite Clone

This project aims to build a web application similar to a private Eventbrite, allowing users to create events and manage user signups within a closed group. Inspired by The Odin Project's curriculum, this project uses C# and Entity Framework Core (EF Core) for development.

**Features:**

- **User Registration and Login:** Users can create accounts with secure password hashing.
- **Event Creation:** Authorized users can create events with details like title, description, location (string format), and date.
- **Event Management:** Event organizers can edit or cancel their events.
- **Event Attendance:** Users can browse events and sign up to attend them.

**Technologies:**

- C#
- ASP.NET Razor Pages
- Entity Framework Core
- ASP.NET Identity (optional)
- PostgreSQL (Database)

**Getting Started:**

1. **Prerequisites:** Ensure you have .NET SDK and Git installed on your system. Download them from the official Microsoft and Git websites, respectively.
2. **Clone the Repository:** Use Git to clone the project codebase:

   ```bash
   git clone https://github.com/Ekott2006/odin-asp.net-private-events
   ```

3. **Navigate to Project Directory:** Change directories to the project folder:

   ```bash
   cd odin-asp.net-private-events/WebApp
   ```

4. **Install Dependencies:** Restore required NuGet packages:

   ```bash
   dotnet restore
   ```

**Database Setup:**

1. **Install PostgreSQL:** Download and install PostgreSQL from the [official website](https://www.postgresql.org/download/).
2. **Create Database:** Use PostgreSQL tools or command-line to create a database for your project.
I'd be glad to assist you with installing `dotnet ef` and creating a PostgreSQL user with password `postgres` in a secure manner:

**Installing `dotnet ef`**

The `dotnet ef` toolset is typically included by default when you install the .NET SDK. However, if you're unsure, here's how to verify and install it if necessary:

1. **Check Version (Optional):**
   - Open a terminal or command prompt and run the following command:

     ```bash
     dotnet --info
     ```

   - Look for the "SDK" section in the output. If it's present, you likely have the necessary tools installed.

2. **Install .NET SDK (if not already installed):**
   - Download the .NET SDK installer from the [official Microsoft website](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
   - Run the downloaded installer and follow the on-screen instructions. Ensure you select the workload that includes "ASP.NET and web development" or similar (the workload name might vary slightly depending on the .NET SDK version).

3. **Create the New User:**
   - Once connected, execute the following command to create a new user named `postgres` with the password `postgres` (replace with your desired password if different):

     ```sql
     CREATE USER postgres WITH PASSWORD 'postgres';
     ```

4. **Configure Connection String:** Update the connection string in your application's settings (e.g., `appsettings.json`) to point to the newly created PostgreSQL database.
5. **Apply Migrations:** If you need to apply the migrations immediately, execute the `Update-Database` command:

    ```bash
    dotnet ef database update
    ```

**Running the Application:**

1. **Command-Line Execution:** Execute the following command in your terminal to launch the application:

   ```bash
   dotnet run
   ```

2. **Open Your Website in the Browser:** Enter this url in your browser to see the website

   ```bash
   http://localhost:5261
   ```
