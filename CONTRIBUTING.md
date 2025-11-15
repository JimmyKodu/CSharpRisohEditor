# Contributing to CSharpRisohEditor

Thank you for your interest in contributing to CSharpRisohEditor!

## Development Setup

### Prerequisites
- .NET 8.0 SDK or later
- A code editor (Visual Studio, Visual Studio Code, or Rider recommended)

### Getting Started

1. Clone the repository:
```bash
git clone https://github.com/JimmyKodu/CSharpRisohEditor.git
cd CSharpRisohEditor
```

2. Build the project:
```bash
dotnet build
```

3. Run the tests:
```bash
dotnet test
```

4. Run the CLI demo:
```bash
dotnet run --project src/CSharpRisohEditor.CLI
```

## Project Structure

- `src/CSharpRisohEditor.Core/` - Core library with resource handling
- `src/CSharpRisohEditor.CLI/` - Command-line demonstration tool
- `tests/CSharpRisohEditor.Tests/` - Unit tests

## Adding New Resource Types

To add support for a new resource type:

1. Add the type to `ResourceType.cs` enum
2. Create a new class inheriting from `ResourceEntry`
3. Implement the abstract methods:
   - `ToRC()` - Generate RC (Resource Script) text
   - `LoadFromBinary()` - Parse binary resource data
   - `ToBinary()` - Generate binary resource data
4. Add unit tests in the Tests project

## Coding Guidelines

- Follow standard C# naming conventions
- Use nullable reference types (`#nullable enable`)
- Add XML documentation comments for public APIs
- Write unit tests for new functionality
- Keep classes focused and single-responsibility

## Testing

- All changes should include unit tests
- Tests should be focused and test one thing
- Use meaningful test names that describe what is being tested

## Pull Request Process

1. Create a feature branch from `main`
2. Make your changes with clear, descriptive commits
3. Ensure all tests pass
4. Update documentation as needed
5. Submit a pull request

## Reference

This project is inspired by [RisohEditor](https://github.com/katahiromz/RisohEditor). When implementing features, refer to the original C++ implementation for guidance on Win32 resource formats.

## License

By contributing, you agree that your contributions will be licensed under the MIT License.
