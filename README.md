# Tetris
Tetris homework

## Features

- Supports shapes with more than 4 pixels;
- Supports board with more than 10 columns;
- Supports board with more than 100 rows.

## TO-DO
- Ability to set input and output from commandline or stdin-stdout

## Pre-requisites
Make sure you have [.net core](https://dotnet.microsoft.com/download "dotnet core") installed and available in your environment.

You can check by running.
```
dotnet --info
```

## Getting Started
Clone this repository
```
git clone https://github.com/jerhat/Tetris.git
cd Tetris
```
## Building
```
dotnet build
```

## Running the tests
```
dotnet test Tests/Tests.csproj
```

## Running
```
dotnet run --project Tetris/Tetris.csproj
```
Input is read from `input.txt`.
Output is written to `output.txt`.
