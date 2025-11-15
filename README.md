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

## Building

Requirements:
- .NET 8.0 SDK or later

Build the project:
```bash
dotnet build
```

Run tests:
```bash
dotnet test
```

## License

This is an independent C# implementation inspired by RisohEditor. Please refer to the [original RisohEditor](https://github.com/katahiromz/RisohEditor) for its license terms.

## Reference

Original RisohEditor: https://github.com/katahiromz/RisohEditor