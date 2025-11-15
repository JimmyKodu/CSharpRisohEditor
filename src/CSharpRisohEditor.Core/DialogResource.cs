namespace CSharpRisohEditor.Core;

/// <summary>
/// Represents a Win32 dialog resource
/// Similar to DialogRes.hpp in the original RisohEditor
/// </summary>
public class DialogResource : ResourceEntry
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Caption { get; set; } = string.Empty;
    public string FontName { get; set; } = string.Empty;
    public int FontSize { get; set; }
    public uint Style { get; set; }
    public uint ExStyle { get; set; }
    public List<DialogControl> Controls { get; set; } = new();

    public DialogResource()
    {
        Type = ResourceType.Dialog;
    }

    public override string ToRC()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{Name} DIALOGEX {X}, {Y}, {Width}, {Height}");
        sb.AppendLine($"STYLE 0x{Style:X8}");
        if (ExStyle != 0)
            sb.AppendLine($"EXSTYLE 0x{ExStyle:X8}");
        if (!string.IsNullOrEmpty(Caption))
            sb.AppendLine($"CAPTION \"{Caption}\"");
        if (!string.IsNullOrEmpty(FontName))
            sb.AppendLine($"FONT {FontSize}, \"{FontName}\"");
        sb.AppendLine("BEGIN");
        foreach (var ctrl in Controls)
        {
            sb.AppendLine($"    {ctrl.ToRC()}");
        }
        sb.AppendLine("END");
        return sb.ToString();
    }

    public override bool LoadFromBinary(byte[] data)
    {
        // TODO: Implement dialog binary parsing
        Data = data;
        return true;
    }

    public override byte[] ToBinary()
    {
        // TODO: Implement dialog binary generation
        return Data;
    }
}

/// <summary>
/// Represents a control in a dialog
/// </summary>
public class DialogControl
{
    public string ClassName { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public uint Style { get; set; }
    public uint ExStyle { get; set; }

    public string ToRC()
    {
        return $"CONTROL \"{Text}\", {Id}, \"{ClassName}\", 0x{Style:X8}, {X}, {Y}, {Width}, {Height}";
    }
}
