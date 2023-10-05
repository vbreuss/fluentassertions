namespace FluentAssertions.Primitives;

/// <summary>
/// Builder to create a <see cref="StringComparerOptions"/> using fluent syntax.
/// </summary>
public class StringComparerOptionsBuilder
{
    private bool ignoreLeadingWhitespace;
    private bool ignoreTrailingWhitespace;
    private bool ignoreNewlines;
    private bool ignoreCase;

    /// <summary>
    /// Ignore leading whitespace when comparing strings.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringLeadingWhitespace()
    {
        ignoreLeadingWhitespace = true;
        return this;
    }

    /// <summary>
    /// Ignore trailing whitespace when comparing strings.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringTrailingWhitespace()
    {
        ignoreTrailingWhitespace = true;
        return this;
    }

    /// <summary>
    /// Ignore new lines within the string.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringNewlines()
    {
        ignoreNewlines = true;
        return this;
    }

    /// <summary>
    /// Use a case-insensitive comparison.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringCase()
    {
        ignoreCase = true;
        return this;
    }

    /// <summary>
    /// Build the <see cref="StringComparerOptions"/>.
    /// </summary>
    internal StringComparerOptions Build()
    {
        return new StringComparerOptions
        {
            IgnoreLeadingWhitespace = ignoreLeadingWhitespace,
            IgnoreTrailingWhitespace = ignoreTrailingWhitespace,
            IgnoreNewlines = ignoreNewlines,
            IgnoreCase = ignoreCase
        };
    }
}
