namespace FluentAssertions.Primitives;

/// <summary>
/// Options for comparing strings in <see cref="StringAssertions{T}.BeEquivalentTo(string, StringComparerOptions, string, object[])"/>
/// </summary>
public class StringComparerOptions
{
    /// <summary>
    /// If set, ignores leading whitespace when comparing strings.
    /// </summary>
    public bool IgnoreLeadingWhitespace { get; init; }

    /// <summary>
    /// If set, ignores trailing whitespace when comparing strings.
    /// </summary>
    public bool IgnoreTrailingWhitespace { get; init; }

    /// <summary>
    /// If set, ignores new lines within the string.
    /// </summary>
    public bool IgnoreNewlines { get; init; }

    /// <summary>
    /// If set, uses a case-insensitive comparison.
    /// </summary>
    public bool IgnoreCase { get; init; }
}
