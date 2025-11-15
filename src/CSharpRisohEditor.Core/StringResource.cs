namespace CSharpRisohEditor.Core;

/// <summary>
/// Represents a string table resource
/// Similar to StringRes.hpp in the original RisohEditor
/// </summary>
public class StringResource : ResourceEntry
{
    /// <summary>
    /// String table entries (ID -> String)
    /// </summary>
    public Dictionary<int, string> Strings { get; set; } = new();

    public StringResource()
    {
        Type = ResourceType.String;
    }

    public override string ToRC()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("STRINGTABLE");
        sb.AppendLine("BEGIN");
        foreach (var kvp in Strings.OrderBy(x => x.Key))
        {
            sb.AppendLine($"    {kvp.Key}, \"{kvp.Value}\"");
        }
        sb.AppendLine("END");
        return sb.ToString();
    }

    public override bool LoadFromBinary(byte[] data)
    {
        // TODO: Implement string table binary parsing
        Data = data;
        return true;
    }

    public override byte[] ToBinary()
    {
        // TODO: Implement string table binary generation
        return Data;
    }
}
