using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]MatchRegex specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class MatchRegex
    {
        [Fact]
        public async Task When_a_string_matches_a_regular_expression_string_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            // ReSharper disable once StringLiteralTypo
            Action act = () => subject.Should().MatchRegex("h.*\\sworld.$");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_a_string_does_not_match_a_regular_expression_string_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchRegex("h.*\\sworld?$", "that's the universal greeting");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_string_is_matched_against_a_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () => subject.Should().MatchRegex(".*", "because it should be a string");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_a_null_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchRegex((string)null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_an_invalid_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";
            string invalidRegex = ".**"; // Use local variable for this invalid regex to avoid static R# analysis errors

            // Act
            Action act = () => subject.Should().MatchRegex(invalidRegex);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_an_invalid_regex_string_it_should_only_have_one_failure_message()
        {
            // Arrange
            string subject = "hello world!";
            string invalidRegex = ".**"; // Use local variable for this invalid regex to avoid static R# analysis errors

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().MatchRegex(invalidRegex);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_an_empty_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().MatchRegex(string.Empty);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_a_string_matches_a_regular_expression_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            // ReSharper disable once StringLiteralTypo
            Action act = () => subject.Should().MatchRegex(new Regex("h.*\\sworld.$"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_a_string_does_not_match_a_regular_expression_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchRegex(new Regex("h.*\\sworld?$"), "that's the universal greeting");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_string_is_matched_against_a_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().MatchRegex(new Regex(".*"), "because it should be a string");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_a_null_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().MatchRegex((Regex)null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_against_an_empty_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().MatchRegex(new Regex(string.Empty));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_and_the_count_of_matches_fits_into_the_expected_it_passes()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().MatchRegex(new Regex("hello.*"), AtLeast.Once());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_is_matched_and_the_count_of_matches_do_not_fit_the_expected_it_fails()
        {
            // Arrange
            string subject = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt " +
                "ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et " +
                "ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";

            // Act
            Action act = () => subject.Should().MatchRegex("Lorem.*", Exactly.Twice());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_matched_and_the_expected_count_is_zero_and_string_not_matches_it_passes()
        {
            // Arrange
            string subject = "a";

            // Act
            Action act = () => subject.Should().MatchRegex("b", Exactly.Times(0));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_is_matched_and_the_expected_count_is_zero_and_string_matches_it_fails()
        {
            // Arrange
            string subject = "a";

            // Act
            Action act = () => subject.Should().MatchRegex("a", Exactly.Times(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_subject_is_null_it_fails()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().MatchRegex(".*", Exactly.Times(0), "because it should be a string");
            };

            // Assert
            await Expect.That(act).ThrowsExactly<XunitException>();
        }

        [Fact]
        public async Task When_the_subject_is_empty_and_expected_count_is_zero_it_passes()
        {
            // Arrange
            string subject = string.Empty;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().MatchRegex("a", Exactly.Times(0));
            };

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_subject_is_empty_and_expected_count_is_more_than_zero_it_fails()
        {
            // Arrange
            string subject = string.Empty;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().MatchRegex(".+", AtLeast.Once());
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_regex_is_null_it_fails_and_ignores_occurrences()
        {
            // Arrange
            string subject = "a";

            // Act
            Action act = () => subject.Should().MatchRegex((Regex)null, Exactly.Times(0));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_regex_is_empty_it_fails_and_ignores_occurrences()
        {
            // Arrange
            string subject = "a";

            // Act
            Action act = () => subject.Should().MatchRegex(string.Empty, Exactly.Times(0));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_regex_is_invalid_it_fails_and_ignores_occurrences()
        {
            // Arrange
            string subject = "a";

            // Act
#pragma warning disable RE0001 // Invalid regex pattern
            Action act = () => subject.Should().MatchRegex(".**", Exactly.Times(0));
#pragma warning restore RE0001 // Invalid regex pattern

            // Assert
            await Expect.That(act).ThrowsExactly<XunitException>();
        }
    }

    public class NotMatchRegex
    {
        [Fact]
        public async Task When_a_string_does_not_match_a_regular_expression_string_and_it_shouldnt_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex(".*earth.*");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_matches_a_regular_expression_string_but_it_shouldnt_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex(".*world.*", "because that's illegal");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_string_is_negatively_matched_against_a_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () => subject.Should().NotMatchRegex(".*", "because it should not be a string");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_a_null_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex((string)null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_an_invalid_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";
            string invalidRegex = ".**"; // Use local variable for this invalid regex to avoid static R# analysis errors

            // Act
            Action act = () => subject.Should().NotMatchRegex(invalidRegex);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_an_invalid_regex_string_it_only_contain_one_failure_message()
        {
            // Arrange
            string subject = "hello world!";
            string invalidRegex = ".**"; // Use local variable for this invalid regex to avoid static R# analysis errors

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().NotMatchRegex(invalidRegex);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_an_empty_regex_string_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatchRegex(string.Empty);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_a_string_does_not_match_a_regular_expression_and_it_shouldnt_it_should_not_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex(new Regex(".*earth.*"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_string_matches_a_regular_expression_but_it_shouldnt_it_should_throw()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex(new Regex(".*world.*"), "because that's illegal");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_string_is_negatively_matched_against_a_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                subject.Should().NotMatchRegex(new Regex(".*"), "because it should not be a string");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_a_null_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world!";

            // Act
            Action act = () => subject.Should().NotMatchRegex((Regex)null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_a_string_is_negatively_matched_against_an_empty_regex_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            string subject = "hello world";

            // Act
            Action act = () => subject.Should().NotMatchRegex(new Regex(string.Empty));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentException>();
        }
    }
}
