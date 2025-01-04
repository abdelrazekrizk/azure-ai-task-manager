# azure-ai-task-manager
 azure-ai-task-manager
# Azure-Powered AI-Personalized Task Manager

## Overview

The Azure-Powered AI-Personalized Task Manager is a web API that allows users to manage tasks and analyze task descriptions using Azure's Natural Language Processing (NLP) capabilities. It provides endpoints to retrieve and add tasks, making it suitable for task management applications.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the API](#testing-the-api)
- [Contributing](#contributing)
- [License](#license)

## Features

- Add new tasks with descriptions and due dates.
- Retrieve all tasks.
- Analyze task descriptions using Azure NLP to determine sentiment.

## Technologies Used

- .NET 6.0
- ASP.NET Core
- Azure AI Text Analytics
- Swagger for API documentation
- Entity Framework Core (if database is used in the future)

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- An Azure account with access to Azure Cognitive Services for NLP

### Installation

1. Clone the repository:

```bash
   git clone https://github.com/abdelrazekrizk/azure-ai-task-manager.git
   cd azure-ai-task-manager/src/TaskManager
```
2. Install the required NuGet packages:

```bash
dotnet add package Octokit --version 13.0.1
dotnet add package Azure.AI.TextAnalytics --version 5.3.0
```

### Configuration


Open the Program.cs file and update the AzureNLPService instantiation with your Azure credentials:


```console
builder.Services.AddSingleton<AzureNLPService>(sp =>
{
    return new AzureNLPService("YOUR_AZURE_ENDPOINT", "YOUR_AZURE_API_KEY");
});
```


### Running the Application


Build the application:


```console
dotnet build
```

2. Run the application:


```console
dotnet run
```

3. Access the API at https://localhost:5001.

### API Endpoints


Get All Tasks


Endpoint: GET /api/task
Description: Retrieves a list of all tasks.
Response:

```console
[
    {
        "id": 1,
        "description": "Task 1",
        "isCompleted": false,
        "dueDate": "2023-10-25T00:00:00Z"
    },
    ...
]
```


Add a New Task


Endpoint: POST /api/task
Description: Adds a new task with a description and due date.
Request Body:

```console
{
    "description": "New Task",
    "isCompleted": false,
    "dueDate": "2023-11-01T00:00:00Z"
}
```
Response:
```console

{
    "task": {
        "id": 2,
        "description": "New Task",
        "isCompleted": false,
        "dueDate": "2023-11-01T00:00:00Z"
    },
    "sentiment": "positive"  // Example response from Azure NLP
}
```


### Testing the API

You can test the API endpoints using tools like Postman or cURL.

Get All Tasks:
Send a GET request to https://localhost:5001/api/task.
Add a New Task:
Send a POST request to https://localhost:5001/api/task with the request body as shown above.
Contributing

 Contributions are welcome! Please follow these steps:
- Contributions are welcome! Please follow these steps:
Fork the repository.
Create a new branch (git checkout -b feature/YourFeature).
Make your changes.
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature/YourFeature).
Open a pull request.

### License

This project is licensed under the GNU GENERAL PUBLIC LICENSE - see the LICENSE file for details.
