# CSharpRisohEditor.WinUI3

WinUI3 application for CSharp RisohEditor - a modern Windows UI for editing Win32 resources.

## About

This is a WinUI3 (Windows App SDK) implementation of the RisohEditor interface, providing a native Windows 11 experience for editing Win32 resources.

## Features

- **Modern Windows 11 UI**: Built with WinUI3 for a native Windows 11 look and feel
- **Resource Management**: View, add, edit, and delete resources
- **File Operations**: Open and save RC/RES/EXE/DLL files
- **Resource Types**: Support for dialogs, menus, string tables, and more
- **Real-time Preview**: View RC format of resources in real-time

## Requirements

- Windows 10 version 1809 (build 17763) or later
- Windows 11 recommended for best experience
- .NET 8.0 SDK or later
- Windows App SDK 1.5 or later

## Building

**Note**: This project requires Windows to build and run.

```powershell
# From the solution root
dotnet restore
dotnet build src/CSharpRisohEditor.WinUI3/CSharpRisohEditor.WinUI3.csproj
```

## Running

```powershell
dotnet run --project src/CSharpRisohEditor.WinUI3/CSharpRisohEditor.WinUI3.csproj
```

Or open the solution in Visual Studio 2022 and run from there.

## Architecture

The WinUI3 application uses the `CSharpRisohEditor.Core` library for all resource handling logic, providing a clean separation between UI and business logic.

### Main Components

- **MainWindow**: Main application window with menu bar, resource list, and details pane
- **App**: Application entry point and lifecycle management
- **ResourceFile**: Core library for resource file operations

### UI Layout

```
+--------------------------------------------------+
| File | Add | Help                                |
+--------------------------------------------------+
| Resources           |  Resource Details          |
| - Dialog: IDD_MAIN  |  Type: Dialog              |
| - Menu: IDR_MENU    |  Caption: Main Dialog      |
| - String: 1         |  Size: 320x200             |
|                     |                            |
| [Add Dialog] [Del]  |  --- RC Format ---         |
|                     |  IDD_MAIN DIALOGEX...      |
+--------------------------------------------------+
| Ready                                            |
+--------------------------------------------------+
```

## Usage

1. **Create a new resource file**: File > New
2. **Add resources**: Use Add menu or toolbar buttons
3. **Edit resources**: Select from the list to view/edit in details pane
4. **Save**: File > Save to export as RC or RES file

## Screenshots

(Screenshots would be added here when running on Windows)

## Reference

Original RisohEditor: https://github.com/katahiromz/RisohEditor

This implementation follows the architecture and functionality of the original while providing a modern WinUI3 interface.
