namespace FluentAssertions.Primitives;

/// <summary>
/// Builder to specify string comparison options via fluent syntax.
/// </summary>
public class StringComparerOptionsBuilder
{
    internal bool IgnoreLeadingWhitespace
    {
        get;
        private set;
    }

    internal bool IgnoreTrailingWhitespace
    {
        get;
        private set;
    }

    internal bool IgnoreNewlines
    {
        get;
        private set;
    }

    internal bool IgnoreCase
    {
        get;
        private set;
    }

    /// <summary>
    /// Ignore leading whitespace when comparing strings.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringLeadingWhitespace()
    {
        IgnoreLeadingWhitespace = true;
        return this;
    }

    /// <summary>
    /// Ignore trailing whitespace when comparing strings.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringTrailingWhitespace()
    {
        IgnoreTrailingWhitespace = true;
        return this;
    }

    /// <summary>
    /// Ignore new lines within the string.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringNewlines()
    {
        IgnoreNewlines = true;
        return this;
    }

    /// <summary>
    /// Use a case-insensitive comparison.
    /// </summary>
    public StringComparerOptionsBuilder IgnoringCase()
    {
        IgnoreCase = true;
        return this;
    }
}
