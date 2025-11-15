# CSharpRisohEditor

A C# version of RisohEditor - a free Win32 resource editor for development.

## About

This project is a C# replication of [RisohEditor](https://github.com/katahiromz/RisohEditor) by Katayama Hirofumi MZ. The original RisohEditor is a powerful resource editor for Win32 development written in C++. This C# version aims to provide similar functionality using .NET technologies.

## Features

- Read/write resource data in RC/RES/EXE/DLL files
- Support for common resource types:
  - Dialogs
  - Menus
  - Icons and Cursors
  - String Tables
  - Accelerators
  - Bitmaps
  - Version Information
- Cross-platform core library (Windows, Linux, macOS)

## Project Structure

- `src/CSharpRisohEditor.Core/` - Core library with resource handling classes
- `src/CSharpRisohEditor.WinUI3/` - **WinUI3 application** with modern Windows 11 UI
- `src/CSharpRisohEditor.CLI/` - Command-line demonstration tool
- `tests/CSharpRisohEditor.Tests/` - Unit tests

## User Interfaces

### WinUI3 Application (Windows Only)

A modern Windows 11 application built with WinUI3, providing a native Windows experience for resource editing.

**Features:**
- Modern Windows 11 UI with Fluent Design
- Visual resource tree with preview
- Real-time RC format display
- File operations (Open/Save RC/RES/EXE/DLL files)
- Add/Edit/Delete resources through GUI

See [WinUI3 README](src/CSharpRisohEditor.WinUI3/README.md) for details.

### CLI Tool (Cross-platform)

Command-line tool for demonstration and automation:
```bash
dotnet run --project src/CSharpRisohEditor.CLI
```

## Building

Requirements:
- .NET 8.0 SDK or later
- **For WinUI3 app**: Windows 10 (build 17763) or later, Windows 11 recommended

Build the entire solution:
```bash
dotnet build
```

Build only the WinUI3 app (Windows only):
```powershell
dotnet build src/CSharpRisohEditor.WinUI3/CSharpRisohEditor.WinUI3.csproj
```

Run the WinUI3 app:
```powershell
dotnet run --project src/CSharpRisohEditor.WinUI3/CSharpRisohEditor.WinUI3.csproj
```

Build the CLI tool (cross-platform):
```bash
dotnet build src/CSharpRisohEditor.CLI/CSharpRisohEditor.CLI.csproj
```

Run tests:
```bash
dotnet test
```

## License

This is an independent C# implementation inspired by RisohEditor. Please refer to the [original RisohEditor](https://github.com/katahiromz/RisohEditor) for its license terms.

## Reference

Original RisohEditor: https://github.com/katahiromz/RisohEditor