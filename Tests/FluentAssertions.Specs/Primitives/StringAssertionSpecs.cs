using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace FluentAssertions.Specs.Primitives;

public partial class StringAssertionSpecs
{
    [Fact]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public async Task When_chaining_multiple_assertions_it_should_assert_all_conditions()
    {
        // Arrange
        string actual = "ABCDEFGHI";
        string prefix = "AB";

        // Act / Assert
        await That(actual).StartsWith(prefix);
    }

    private sealed class AlwaysMatchingEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return true;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

    private sealed class NeverMatchingEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return false;
        }

        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
}
