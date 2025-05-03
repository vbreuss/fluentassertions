﻿using Xunit;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    /* TODO VAB
    public class BeEquivalentTo
    {
        [Fact]
        public async Task Can_ignore_casing_while_comparing_objects_with_string_properties()
        {
            // Arrange
            var actual = new { foo = "test" };
            var expectation = new { foo = "TEST" };

            // Act / Assert
            await Expect.That(actual).IsEquivalentTo(expectation).Because(o => o.IgnoringCase());
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_comparing_objects_with_string_properties()
        {
            // Arrange
            var actual = new { foo = "  test" };
            var expectation = new { foo = "test" };

            // Act / Assert
            await Expect.That(actual).IsEquivalentTo(expectation).Because(o => o.IgnoringLeadingWhitespace());
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_comparing_objects_with_string_properties()
        {
            // Arrange
            var actual = new { foo = "test  " };
            var expectation = new { foo = "test" };

            // Act / Assert
            await Expect.That(actual).IsEquivalentTo(expectation).Because(o => o.IgnoringTrailingWhitespace());
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_comparing_objects_with_string_properties()
        {
            // Arrange
            var actual = new { foo = "A\nB\r\nC" };
            var expectation = new { foo = "A\r\nB\nC" };

            // Act / Assert
            await Expect.That(actual).IsEquivalentTo(expectation).Because(o => o.IgnoringNewlineStyle());
        }
    }
    */
}
