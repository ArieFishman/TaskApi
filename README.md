# taskApi

A simple .NET 7 Web API for managing tasks

## Features

- Create, Read, Update, and Delete (CRUD) task items
- Task model includes title, description, priority, status, and due date
- API returns standardized response DTOs for success and error handling
- ISO 8601 date validation
- Integrated Swagger documentation for easy API testing

## Requirements

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- IDE (e.g., Visual Studio 2022, Rider, VS Code)
- Node.js (if used with Angular frontend)
- task.json file in the root folder (wher program.cs located)

## How to Run

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/taskApi.git
   cd taskApi
   ```

   S

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Build the project**

   ```bash
   dotnet build
   ```

4. **Run the API**

   ```bash
   dotnet run
   ```

## API Endpoints

### GET /api/tasks

Fetch all tasks

### GET /api/tasks/{id}

Fetch a single task by ID

### POST /api/tasks

Create a new task  
**Body Example:**

```json
{
  "title": "My Task",
  "description": "Optional",
  "priority": "גבוהה",
  "dueDate": "2025-08-01T20:00:00",
  "status": "ממתינה"
}
```

## Project Structure

```text
taskApi/
├── Controllers/
│   └── TaskController.cs         # Handles HTTP requests for task operations
├── DTOs/
│   ├── CreateTaskDto.cs          # DTO for creating tasks
│   ├── UpdateTaskDto.cs          # DTO for updating tasks
│   └── GetTasksResponseDto.cs    # DTO for returning task lists
├── Models/
│   └── TaskModel.cs              # Task entity definition
├── Services/
│   ├── ITaskService.cs           # Interface for task logic
│   └── TaskService.cs            # Implementation of task logic
├── Program.cs                    # Entry point and service configuration
├── appsettings.json              # Configuration file
```
