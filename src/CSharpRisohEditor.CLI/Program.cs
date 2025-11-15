using CSharpRisohEditor.Core;

Console.WriteLine("CSharpRisohEditor - C# Resource Editor");
Console.WriteLine("======================================");
Console.WriteLine();

// Demonstrate creating a simple resource file
var resourceFile = new ResourceFile();

// Create a sample dialog resource
var dialog = new DialogResource
{
    Name = "IDD_SAMPLE",
    X = 0,
    Y = 0,
    Width = 320,
    Height = 200,
    Caption = "Sample Dialog",
    FontName = "MS Shell Dlg",
    FontSize = 8,
    Style = 0x80C80000, // WS_POPUP | WS_CAPTION | WS_SYSMENU | DS_MODALFRAME
};

// Add some controls
dialog.Controls.Add(new DialogControl
{
    ClassName = "BUTTON",
    Text = "OK",
    Id = 1,
    X = 200,
    Y = 170,
    Width = 50,
    Height = 14,
    Style = 0x50010001, // WS_CHILD | WS_VISIBLE | WS_TABSTOP | BS_DEFPUSHBUTTON
});

dialog.Controls.Add(new DialogControl
{
    ClassName = "BUTTON",
    Text = "Cancel",
    Id = 2,
    X = 260,
    Y = 170,
    Width = 50,
    Height = 14,
    Style = 0x50010000, // WS_CHILD | WS_VISIBLE | WS_TABSTOP
});

resourceFile.AddResource(dialog);

// Create a sample menu resource
var menu = new MenuResource
{
    Name = "IDR_MAINMENU"
};

var fileMenu = new MenuItem
{
    Text = "&File",
    IsPopup = true
};
fileMenu.SubItems.Add(new MenuItem { Text = "&Open", Id = 101 });
fileMenu.SubItems.Add(new MenuItem { Text = "&Save", Id = 102 });
fileMenu.SubItems.Add(new MenuItem { IsSeparator = true });
fileMenu.SubItems.Add(new MenuItem { Text = "E&xit", Id = 103 });

var editMenu = new MenuItem
{
    Text = "&Edit",
    IsPopup = true
};
editMenu.SubItems.Add(new MenuItem { Text = "&Copy", Id = 201 });
editMenu.SubItems.Add(new MenuItem { Text = "&Paste", Id = 202 });

menu.Items.Add(fileMenu);
menu.Items.Add(editMenu);

resourceFile.AddResource(menu);

// Create a sample string table
var stringTable = new StringResource
{
    Name = "1"
};
stringTable.Strings[100] = "Application Name";
stringTable.Strings[101] = "Copyright Information";
stringTable.Strings[102] = "Version 1.0";

resourceFile.AddResource(stringTable);

// Create an accelerator table
var accel = new AcceleratorResource
{
    Name = "IDR_ACCELERATOR"
};
accel.Entries.Add(new AcceleratorEntry
{
    Key = 'O',
    Id = 101,
    Control = true,
    VirtKey = false
});
accel.Entries.Add(new AcceleratorEntry
{
    Key = 'S',
    Id = 102,
    Control = true,
    VirtKey = false
});

resourceFile.AddResource(accel);

// Display summary
Console.WriteLine($"Created resource file with {resourceFile.Resources.Count} resources:");
foreach (var resource in resourceFile.Resources)
{
    Console.WriteLine($"  - {resource.Type}: {resource.Name}");
}
Console.WriteLine();

// Save to RC file
var outputPath = Path.Combine(Path.GetTempPath(), "sample.rc");
if (resourceFile.Save(outputPath))
{
    Console.WriteLine($"Successfully saved to: {outputPath}");
    Console.WriteLine();
    Console.WriteLine("RC File Contents:");
    Console.WriteLine("================");
    Console.WriteLine(File.ReadAllText(outputPath));
}
else
{
    Console.WriteLine("Failed to save resource file.");
}

