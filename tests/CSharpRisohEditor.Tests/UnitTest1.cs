using CSharpRisohEditor.Core;

namespace CSharpRisohEditor.Tests;

public class ResourceTests
{
    [Fact]
    public void DialogResource_ToRC_GeneratesValidFormat()
    {
        // Arrange
        var dialog = new DialogResource
        {
            Name = "IDD_TEST",
            X = 0,
            Y = 0,
            Width = 200,
            Height = 100,
            Caption = "Test Dialog",
            FontName = "MS Shell Dlg",
            FontSize = 8,
            Style = 0x80C80000
        };

        dialog.Controls.Add(new DialogControl
        {
            ClassName = "BUTTON",
            Text = "OK",
            Id = 1,
            X = 100,
            Y = 80,
            Width = 50,
            Height = 14,
            Style = 0x50010001
        });

        // Act
        var rc = dialog.ToRC();

        // Assert
        Assert.Contains("IDD_TEST DIALOGEX", rc);
        Assert.Contains("CAPTION \"Test Dialog\"", rc);
        Assert.Contains("FONT 8, \"MS Shell Dlg\"", rc);
        Assert.Contains("CONTROL \"OK\", 1", rc);
    }

    [Fact]
    public void MenuResource_ToRC_GeneratesValidFormat()
    {
        // Arrange
        var menu = new MenuResource
        {
            Name = "IDR_MENU"
        };

        var popup = new MenuItem
        {
            Text = "File",
            IsPopup = true
        };
        popup.SubItems.Add(new MenuItem { Text = "Open", Id = 100 });
        popup.SubItems.Add(new MenuItem { IsSeparator = true });
        popup.SubItems.Add(new MenuItem { Text = "Exit", Id = 101 });

        menu.Items.Add(popup);

        // Act
        var rc = menu.ToRC();

        // Assert
        Assert.Contains("IDR_MENU MENU", rc);
        Assert.Contains("POPUP \"File\"", rc);
        Assert.Contains("MENUITEM \"Open\", 100", rc);
        Assert.Contains("MENUITEM SEPARATOR", rc);
        Assert.Contains("MENUITEM \"Exit\", 101", rc);
    }

    [Fact]
    public void StringResource_ToRC_GeneratesValidFormat()
    {
        // Arrange
        var strings = new StringResource
        {
            Name = "1"
        };
        strings.Strings[100] = "Test String 1";
        strings.Strings[101] = "Test String 2";

        // Act
        var rc = strings.ToRC();

        // Assert
        Assert.Contains("STRINGTABLE", rc);
        Assert.Contains("100, \"Test String 1\"", rc);
        Assert.Contains("101, \"Test String 2\"", rc);
    }

    [Fact]
    public void ResourceFile_AddResource_IncreasesCount()
    {
        // Arrange
        var file = new ResourceFile();
        var dialog = new DialogResource { Name = "IDD_TEST" };

        // Act
        file.AddResource(dialog);

        // Assert
        Assert.Single(file.Resources);
        Assert.Equal(dialog, file.Resources[0]);
    }

    [Fact]
    public void ResourceFile_RemoveResource_DecreasesCount()
    {
        // Arrange
        var file = new ResourceFile();
        var dialog = new DialogResource { Name = "IDD_TEST" };
        file.AddResource(dialog);

        // Act
        var removed = file.RemoveResource(dialog);

        // Assert
        Assert.True(removed);
        Assert.Empty(file.Resources);
    }

    [Fact]
    public void ResourceFile_FindResourcesByType_ReturnsCorrectResources()
    {
        // Arrange
        var file = new ResourceFile();
        file.AddResource(new DialogResource { Name = "IDD_DIALOG1" });
        file.AddResource(new MenuResource { Name = "IDR_MENU1" });
        file.AddResource(new DialogResource { Name = "IDD_DIALOG2" });

        // Act
        var dialogs = file.FindResourcesByType(ResourceType.Dialog);

        // Assert
        Assert.Equal(2, dialogs.Count);
        Assert.All(dialogs, d => Assert.Equal(ResourceType.Dialog, d.Type));
    }

    [Fact]
    public void AcceleratorResource_ToRC_GeneratesValidFormat()
    {
        // Arrange
        var accel = new AcceleratorResource
        {
            Name = "IDR_ACCEL"
        };
        accel.Entries.Add(new AcceleratorEntry
        {
            Key = 'N',
            Id = 100,
            Control = true,
            VirtKey = false
        });

        // Act
        var rc = accel.ToRC();

        // Assert
        Assert.Contains("IDR_ACCEL ACCELERATORS", rc);
        Assert.Contains("\"N\", 100, CONTROL", rc);
    }
}
