namespace CSharpRisohEditor.Core;

/// <summary>
/// Represents an icon or cursor resource
/// Similar to IconRes.hpp in the original RisohEditor
/// </summary>
public class IconResource : ResourceEntry
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int ColorCount { get; set; }
    public int BitCount { get; set; }

    public IconResource(bool isCursor = false)
    {
        Type = isCursor ? ResourceType.Cursor : ResourceType.Icon;
    }

    public override string ToRC()
    {
        // Icons are typically referenced by file path in RC files
        return $"{Name} ICON \"{Name}.ico\"";
    }

    public override bool LoadFromBinary(byte[] data)
    {
        Data = data;
        // TODO: Parse icon header to get width, height, etc.
        return true;
    }

    public override byte[] ToBinary()
    {
        return Data;
    }
}
