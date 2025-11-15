namespace CSharpRisohEditor.Core;

/// <summary>
/// Represents an accelerator table resource
/// Similar to AccelRes.hpp in the original RisohEditor
/// </summary>
public class AcceleratorResource : ResourceEntry
{
    public List<AcceleratorEntry> Entries { get; set; } = new();

    public AcceleratorResource()
    {
        Type = ResourceType.Accelerator;
    }

    public override string ToRC()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{Name} ACCELERATORS");
        sb.AppendLine("BEGIN");
        foreach (var entry in Entries)
        {
            sb.AppendLine($"    {entry.ToRC()}");
        }
        sb.AppendLine("END");
        return sb.ToString();
    }

    public override bool LoadFromBinary(byte[] data)
    {
        // TODO: Implement accelerator binary parsing
        Data = data;
        return true;
    }

    public override byte[] ToBinary()
    {
        // TODO: Implement accelerator binary generation
        return Data;
    }
}

/// <summary>
/// Represents an accelerator entry
/// </summary>
public class AcceleratorEntry
{
    public int Key { get; set; }
    public int Id { get; set; }
    public bool Control { get; set; }
    public bool Alt { get; set; }
    public bool Shift { get; set; }
    public bool VirtKey { get; set; }

    public string ToRC()
    {
        var modifiers = new List<string>();
        if (VirtKey) modifiers.Add("VIRTKEY");
        if (Control) modifiers.Add("CONTROL");
        if (Alt) modifiers.Add("ALT");
        if (Shift) modifiers.Add("SHIFT");

        var keyStr = VirtKey ? $"VK_{Key:X}" : $"\"{(char)Key}\"";
        var modStr = modifiers.Count > 0 ? ", " + string.Join(", ", modifiers) : "";
        return $"{keyStr}, {Id}{modStr}";
    }
}
