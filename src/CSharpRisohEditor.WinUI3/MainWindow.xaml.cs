using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CSharpRisohEditor.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CSharpRisohEditor.WinUI3;

/// <summary>
/// Main window for the RisohEditor WinUI3 application
/// </summary>
public sealed partial class MainWindow : Window
{
    private ResourceFile _resourceFile;
    private ObservableCollection<ResourceEntry> _resources;

    public MainWindow()
    {
        this.InitializeComponent();
        _resourceFile = new ResourceFile();
        _resources = new ObservableCollection<ResourceEntry>();
        ResourceListView.ItemsSource = _resources;
        
        Title = "CSharp RisohEditor - WinUI3";
    }

    private void NewFile_Click(object sender, RoutedEventArgs e)
    {
        _resourceFile = new ResourceFile();
        _resources.Clear();
        UpdateStatusBar("New file created");
    }

    private async void OpenFile_Click(object sender, RoutedEventArgs e)
    {
        var picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.FileTypeFilter.Add(".rc");
        picker.FileTypeFilter.Add(".res");
        picker.FileTypeFilter.Add(".exe");
        picker.FileTypeFilter.Add(".dll");

        // Get the window handle
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        var file = await picker.PickSingleFileAsync();
        if (file != null)
        {
            if (_resourceFile.Load(file.Path))
            {
                _resources.Clear();
                foreach (var resource in _resourceFile.Resources)
                {
                    _resources.Add(resource);
                }
                UpdateStatusBar($"Opened: {file.Name}");
            }
            else
            {
                await ShowErrorDialog("Failed to open file", "Could not load the resource file.");
            }
        }
    }

    private async void SaveFile_Click(object sender, RoutedEventArgs e)
    {
        var picker = new Windows.Storage.Pickers.FileSavePicker();
        picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
        picker.FileTypeChoices.Add("Resource Script", new[] { ".rc" });
        picker.FileTypeChoices.Add("Compiled Resource", new[] { ".res" });
        picker.SuggestedFileName = "resources";

        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

        var file = await picker.PickSaveFileAsync();
        if (file != null)
        {
            if (_resourceFile.Save(file.Path))
            {
                UpdateStatusBar($"Saved: {file.Name}");
            }
            else
            {
                await ShowErrorDialog("Failed to save file", "Could not save the resource file.");
            }
        }
    }

    private void AddDialog_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new DialogResource
        {
            Name = $"IDD_DIALOG{_resources.Count + 1}",
            Caption = "New Dialog",
            Width = 320,
            Height = 200,
            X = 0,
            Y = 0,
            FontName = "MS Shell Dlg",
            FontSize = 8,
            Style = 0x80C80000
        };

        // Add default OK button
        dialog.Controls.Add(new DialogControl
        {
            ClassName = "BUTTON",
            Text = "OK",
            Id = 1,
            X = 200,
            Y = 170,
            Width = 50,
            Height = 14,
            Style = 0x50010001
        });

        _resourceFile.AddResource(dialog);
        _resources.Add(dialog);
        UpdateStatusBar("Dialog added");
    }

    private void AddMenu_Click(object sender, RoutedEventArgs e)
    {
        var menu = new MenuResource
        {
            Name = $"IDR_MENU{_resources.Count + 1}"
        };

        var fileMenu = new MenuItem
        {
            Text = "&File",
            IsPopup = true
        };
        fileMenu.SubItems.Add(new MenuItem { Text = "E&xit", Id = 100 });

        menu.Items.Add(fileMenu);

        _resourceFile.AddResource(menu);
        _resources.Add(menu);
        UpdateStatusBar("Menu added");
    }

    private void AddStringTable_Click(object sender, RoutedEventArgs e)
    {
        var strings = new StringResource
        {
            Name = $"{_resources.Count + 1}"
        };
        strings.Strings[100] = "Sample String";

        _resourceFile.AddResource(strings);
        _resources.Add(strings);
        UpdateStatusBar("String table added");
    }

    private void DeleteResource_Click(object sender, RoutedEventArgs e)
    {
        if (ResourceListView.SelectedItem is ResourceEntry selectedResource)
        {
            _resourceFile.RemoveResource(selectedResource);
            _resources.Remove(selectedResource);
            UpdateStatusBar("Resource deleted");
        }
    }

    private void ResourceListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ResourceListView.SelectedItem is ResourceEntry resource)
        {
            DisplayResourceDetails(resource);
        }
    }

    private void DisplayResourceDetails(ResourceEntry resource)
    {
        var details = $"Type: {resource.Type}\nName: {resource.Name}\nLanguage: {resource.Language}\n\n";
        
        switch (resource)
        {
            case DialogResource dialog:
                details += $"Caption: {dialog.Caption}\n";
                details += $"Size: {dialog.Width}x{dialog.Height}\n";
                details += $"Controls: {dialog.Controls.Count}\n";
                break;
            case MenuResource menu:
                details += $"Items: {menu.Items.Count}\n";
                break;
            case StringResource strings:
                details += $"Strings: {strings.Strings.Count}\n";
                break;
        }

        details += "\n--- RC Format ---\n\n";
        details += resource.ToRC();

        ResourceDetailsTextBox.Text = details;
    }

    private void UpdateStatusBar(string message)
    {
        StatusBarText.Text = message;
    }

    private async System.Threading.Tasks.Task ShowErrorDialog(string title, string message)
    {
        var dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK",
            XamlRoot = this.Content.XamlRoot
        };

        await dialog.ShowAsync();
    }
}
