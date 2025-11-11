# Tasks API

This project is a simple RESTful API for managing a list of tasks. It is built with ASP.NET Core and runs on .NET 8. It uses an in-memory database to store the tasks.

## API Endpoints

The following endpoints are available:

### Get All Tasks

- **GET** `/tasks`

Returns a list of all tasks.

**Example Response:**

```json
[
  {
    "taskId": 1,
    "description": "My first task",
    "done": false
  }
]
```

### Create a New Task

- **POST** `/tasks`

Creates a new task.

**Example Request:**

```json
{
  "description": "My new task"
}
```

**Example Response:**

```json
{
  "taskId": 2,
  "description": "My new task",
  "done": false
}
```

### Toggle Task Status

- **PATCH** `/tasks/{taskId}/toggle-status/{done}`

Updates the `done` status of a task.

**URL Parameters:**

- `taskId` (integer, required): The ID of the task to update.
- `done` (boolean, required): The new status of the task.

**Example Response:**

```json
{
  "taskId": 1,
  "description": "My first task",
  "done": true
}
```

## Project Structure

The project is structured as follows:

- `Data/`: Contains the `TaskDbContext` for the in-memory database.
- `Model/`: Contains the `MyTask` data model.
- `Repository/`: Contains the `MyTaskRepository` which handles data access.
- `Routes/`: Contains the `TaskRoutes` which define the API endpoints.
- `Service/`: Contains the `TaskService` which handles the business logic.
- `Program.cs`: The main entry point of the application.
