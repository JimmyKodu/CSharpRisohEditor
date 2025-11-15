# WinUI3 Application Design

## Overview

The CSharpRisohEditor WinUI3 application provides a modern Windows 11 interface for editing Win32 resources, inspired by the original RisohEditor.

## UI Layout

```
┌────────────────────────────────────────────────────────────────┐
│ File | Add | Help                                              │
├────────────────────────────────────────────────────────────────┤
│                                                                │
│  ┌─────────────────┬─────────────────────────────────────────┐│
│  │ Resources       │ Resource Details                        ││
│  ├─────────────────┤                                         ││
│  │ ┌─────────────┐ │ Type: Dialog                           ││
│  │ │ Dialog      │ │ Name: IDD_MAIN                         ││
│  │ │ - IDD_MAIN  │ │ Caption: Main Window                   ││
│  │ │ - IDD_ABOUT │ │ Size: 320x200                          ││
│  │ │             │ │ Controls: 2                            ││
│  │ │ Menu        │ │                                         ││
│  │ │ - IDR_MENU  │ │ --- RC Format ---                      ││
│  │ │             │ │                                         ││
│  │ │ String      │ │ IDD_MAIN DIALOGEX 0, 0, 320, 200      ││
│  │ │ - 1         │ │ STYLE 0x80C80000                       ││
│  │ │             │ │ CAPTION "Main Window"                  ││
│  │ └─────────────┘ │ FONT 8, "MS Shell Dlg"                 ││
│  │                 │ BEGIN                                   ││
│  │ [Add Dialog]    │     CONTROL "OK", 1, "BUTTON", ...     ││
│  │ [Delete]        │ END                                     ││
│  └─────────────────┴─────────────────────────────────────────┘│
│                                                                │
├────────────────────────────────────────────────────────────────┤
│ Ready                                                          │
└────────────────────────────────────────────────────────────────┘
```

## Key Components

### Menu Bar
- **File Menu**: New, Open, Save, Exit
- **Add Menu**: Add Dialog, Add Menu, Add String Table
- **Help Menu**: About

### Resource List (Left Pane)
- Hierarchical tree view of resources
- Grouped by type (Dialog, Menu, String, Icon, etc.)
- Shows resource names
- Single selection mode
- Toolbar buttons: Add Dialog, Delete

### Resource Details (Right Pane)
- Top section: Resource metadata
  - Type, Name, Language
  - Type-specific properties (Caption, Size, etc.)
- Bottom section: RC Format preview
  - Read-only text showing the RC script format
  - Syntax highlighted (future enhancement)

### Status Bar
- Shows current operation status
- File name when file is open

## User Workflows

### Creating a New Resource
1. Click "Add" menu
2. Select resource type (Dialog, Menu, String Table)
3. Resource appears in list with default name
4. Select to view/edit properties

### Opening a File
1. File > Open
2. Select RC/RES/EXE/DLL file
3. Resources load into the tree view
4. Select any resource to view details

### Editing a Resource
1. Select resource from list
2. View properties in details pane
3. View RC format in real-time
4. (Future: Edit properties directly in UI)

### Saving a File
1. File > Save
2. Choose RC or RES format
3. Specify output location
4. File is saved with all resources

## Technology Stack

- **Framework**: WinUI3 (Windows App SDK 1.5)
- **Language**: C# 12 / .NET 8.0
- **UI**: XAML with Fluent Design
- **Architecture**: MVVM pattern (future enhancement)
- **Core Logic**: CSharpRisohEditor.Core library

## Future Enhancements

- [ ] Direct property editing in UI (not just RC view)
- [ ] Drag and drop for dialog controls
- [ ] Visual dialog editor
- [ ] Syntax highlighting for RC format
- [ ] Resource search/filter
- [ ] Recent files list
- [ ] Undo/Redo support
- [ ] Resource import/export
- [ ] Multi-language support
- [ ] Dark/Light theme toggle
- [ ] Resource comparison view

## Comparison with Original RisohEditor

| Feature | Original RisohEditor | CSharpRisohEditor WinUI3 |
|---------|---------------------|--------------------------|
| Platform | Win32 (C++) | WinUI3 (C#) |
| UI Framework | Native Win32 | WinUI3/XAML |
| Design | Classic Windows | Modern Fluent Design |
| Language Support | C++ | C# |
| .NET Integration | No | Yes |
| Modern Controls | Limited | Full WinUI3 controls |
| Touch Support | No | Yes |
| DPI Scaling | Manual | Automatic |

## Screenshots

(To be added when running on Windows 11)

The WinUI3 version provides a modern, touch-friendly interface while maintaining compatibility with the original RisohEditor's file formats and functionality.
