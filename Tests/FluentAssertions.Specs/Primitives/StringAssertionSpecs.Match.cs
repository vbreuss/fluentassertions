using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]Match specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class Match
    {
        [Fact]
        public async Task When_a_string_does_not_match_a_wildcard_pattern_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().Match("h*earth!", "that's the universal greeting");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_does_match_a_wildcard_pattern_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().Match("h*world?");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_does_not_match_a_wildcard_pattern_with_escaped_markers_it_should_throw()
        {
            // Arrange
            string subject = "What! Are you deaf!";

            // Act
            Action act = () => subject.Should().Match(@"What\? Are you deaf\?");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_does_match_a_wildcard_pattern_but_differs_in_casing_it_should_throw()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().Match("*World*");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_null_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().Match(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task Null_does_not_match_to_any_string()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () => subject.Should().Match("*");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_an_empty_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().Match(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class NotMatch
    {
        [Fact]
        public async Task When_a_string_does_not_match_a_pattern_and_it_shouldnt_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatch("*World*");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_does_match_a_pattern_but_it_shouldnt_it_should_throw()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatch("*world*", "because that's illegal");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_null_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatch(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_an_empty_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatch(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }
}
