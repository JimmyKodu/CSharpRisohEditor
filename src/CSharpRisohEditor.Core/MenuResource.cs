namespace CSharpRisohEditor.Core;

/// <summary>
/// Represents a Win32 menu resource
/// Similar to MenuRes.hpp in the original RisohEditor
/// </summary>
public class MenuResource : ResourceEntry
{
    public List<MenuItem> Items { get; set; } = new();

    public MenuResource()
    {
        Type = ResourceType.Menu;
    }

    public override string ToRC()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{Name} MENU");
        sb.AppendLine("BEGIN");
        foreach (var item in Items)
        {
            sb.AppendLine(item.ToRC(1));
        }
        sb.AppendLine("END");
        return sb.ToString();
    }

    public override bool LoadFromBinary(byte[] data)
    {
        // TODO: Implement menu binary parsing
        Data = data;
        return true;
    }

    public override byte[] ToBinary()
    {
        // TODO: Implement menu binary generation
        return Data;
    }
}

/// <summary>
/// Represents a menu item
/// </summary>
public class MenuItem
{
    public string Text { get; set; } = string.Empty;
    public int Id { get; set; }
    public bool IsPopup { get; set; }
    public bool IsSeparator { get; set; }
    public List<MenuItem> SubItems { get; set; } = new();

    public string ToRC(int indent)
    {
        var indentStr = new string(' ', indent * 4);
        if (IsSeparator)
        {
            return $"{indentStr}MENUITEM SEPARATOR";
        }
        else if (IsPopup)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"{indentStr}POPUP \"{Text}\"");
            sb.AppendLine($"{indentStr}BEGIN");
            foreach (var subItem in SubItems)
            {
                sb.AppendLine(subItem.ToRC(indent + 1));
            }
            sb.AppendLine($"{indentStr}END");
            return sb.ToString().TrimEnd();
        }
        else
        {
            return $"{indentStr}MENUITEM \"{Text}\", {Id}";
        }
    }
}
