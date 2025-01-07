# RadioActivityMonitor Console App

This is a .NET 8-based console application, `RadioActivityMonitor`, which monitors radioactivity levels.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Running Locally](#running-locally)
- [Running with Docker](#running-with-docker)
- [Testing](#testing)

## Prerequisites

- .NET 8 SDK
- Docker (if using Docker)

## Running Locally

1. Clone the repository:

    ```bash
    git clone https://github.com/abhilashvrao/RadioActivityMonitor.git
    cd RadioActivityMonitor
    ```

2. Navigate to the `RadioActivityMonitor.ConsoleApp` directory:

    ```bash
    cd src/RadioActivityMonitor.ConsoleApp
    ```

3. Restore dependencies:

    ```bash
    dotnet restore
    ```

4. Run the console app:

    ```bash
    dotnet run
    ```

## Running with Docker

1. Make sure Docker is installed and running on your machine.
   
2. Navigate to the `RadioActivityMonitor.ConsoleApp` folder where the `Dockerfile` is located:

    ```bash
    cd src/RadioActivityMonitor.ConsoleApp
    ```

3. Build the Docker image:

    ```bash
    docker build -t radioactivitymonitor .
    ```

4. Run the Docker container:

    ```bash
    docker run --rm radioactivitymonitor
    ```

## Testing

1. Navigate to the `RadioActivityMonitor.Tests` directory:

    ```bash
    cd ../RadioActivityMonitor.Tests
    ```

2. Run the tests:

    ```bash
    dotnet test
    ```
