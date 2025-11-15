namespace CSharpRisohEditor.Core;

/// <summary>
/// Base class for all Win32 resources
/// Similar to Res.hpp in the original RisohEditor
/// </summary>
public abstract class ResourceEntry
{
    /// <summary>
    /// Resource type
    /// </summary>
    public ResourceType Type { get; set; }

    /// <summary>
    /// Resource name (can be string or numeric ID)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Language ID
    /// </summary>
    public ushort Language { get; set; }

    /// <summary>
    /// Raw resource data
    /// </summary>
    public byte[] Data { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Convert resource to RC (Resource Script) format
    /// </summary>
    public abstract string ToRC();

    /// <summary>
    /// Load resource from binary data
    /// </summary>
    public abstract bool LoadFromBinary(byte[] data);

    /// <summary>
    /// Convert resource to binary format
    /// </summary>
    public abstract byte[] ToBinary();
}
