using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]MatchEquivalentOf specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class MatchEquivalentOf
    {
        [Fact]
        public void Can_ignore_casing_while_checking_a_string_to_match_another()
        {
            // Arrange
            string actual = "test";
            string expect = "T*T";

            // Act / Assert
            actual.Should().MatchEquivalentOf(expect, o => o.IgnoringCase());
        }

        [Fact]
        public void Can_ignore_leading_whitespace_while_checking_a_string_to_match_another()
        {
            // Arrange
            string actual = "  test";
            string expect = "t*t";

            // Act / Assert
            actual.Should().MatchEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());
        }

        [Fact]
        public void Can_ignore_trailing_whitespace_while_checking_a_string_to_match_another()
        {
            // Arrange
            string actual = "test  ";
            string expect = "t*t";

            // Act / Assert
            actual.Should().MatchEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());
        }

        [Fact]
        public void Can_ignore_newline_style_while_checking_a_string_to_match_another()
        {
            // Arrange
            string actual = "\rA\nB\r\nC\n";
            string expect = "\nA\r\n?\nC\r";

            // Act / Assert
            actual.Should().MatchEquivalentOf(expect, o => o.IgnoringNewlineStyle());
        }

        [Fact]
        public async Task When_a_string_does_not_match_the_equivalent_of_a_wildcard_pattern_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchEquivalentOf("h*earth!", "that's the universal greeting");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected subject to match the equivalent of*\"h*earth!\" " +
                "because that's the universal greeting, but*\"hello world!\" does not.").AsWildcard();
        }

        [Fact]
        public async Task When_a_string_does_match_the_equivalent_of_a_wildcard_pattern_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchEquivalentOf("h*WORLD?");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_with_newline_matches_the_equivalent_of_a_wildcard_pattern_it_should_not_throw()
        {
            // Arrange
            string subject = "hello\r\nworld!";

            // Act
            Action act = () => subject.Should().MatchEquivalentOf("helloworld!");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_the_equivalent_of_null_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().MatchEquivalentOf(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_the_equivalent_of_an_empty_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().MatchEquivalentOf(string.Empty);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class NotMatchEquivalentOf
    {
        [Fact]
        public async Task Can_ignore_casing_while_checking_a_string_to_not_match_another()
        {
            // Arrange
            string actual = "test";
            string expect = "T*T";

            // Act
            Action act = () => actual.Should().NotMatchEquivalentOf(expect, o => o.IgnoringCase());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_checking_a_string_to_not_match_another()
        {
            // Arrange
            string actual = "  test";
            string expect = "t*t";

            // Act
            Action act = () => actual.Should().NotMatchEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_checking_a_string_to_not_match_another()
        {
            // Arrange
            string actual = "test  ";
            string expect = "t*t";

            // Act
            Action act = () => actual.Should().NotMatchEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_checking_a_string_to_not_match_another()
        {
            // Arrange
            string actual = "\rA\nB\r\nC\n";
            string expect = "\nA\r\n?\nC\r";

            // Act
            Action act = () => actual.Should().NotMatchEquivalentOf(expect, o => o.IgnoringNewlineStyle());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_not_equivalent_to_a_pattern_and_that_is_expected_it_should_not_throw()
        {
            // Arrange
            string subject = "Hello Earth";

            // Act
            Action act = () => subject.Should().NotMatchEquivalentOf("*World*");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_does_match_the_equivalent_of_a_pattern_but_it_shouldnt_it_should_throw()
        {
            // Arrange
            string subject = "hello WORLD";

            // Act
            Action act = () => subject.Should().NotMatchEquivalentOf("*world*", "because that's illegal");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Did not expect subject to match the equivalent of*\"*world*\" because that's illegal, " +
                    "but*\"hello WORLD\" matches.").AsWildcard();
        }

        [Fact]
        public async Task When_a_string_with_newlines_does_match_the_equivalent_of_a_pattern_but_it_shouldnt_it_should_throw()
        {
            // Arrange
            string subject = "hello\r\nworld!";

            // Act
            Action act = () => subject.Should().NotMatchEquivalentOf("helloworld!");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_the_equivalent_of_null_pattern_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatchEquivalentOf(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_the_equivalent_of_an_empty_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatchEquivalentOf(string.Empty);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public void Does_not_treat_escaped_newlines_as_newlines()
        {
            // Arrange
            string actual = "te\r\nst";
            string expect = "te\\r\\nst";

            // Act / Assert
            actual.Should().NotMatchEquivalentOf(expect);
        }
    }
}
