using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]Be specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task When_both_values_are_the_same_it_should_not_throw()
        {
            // Act / Assert
            await Expect.That("ABC").IsEqualTo("ABC");
        }

        [Fact]
        public async Task When_both_subject_and_expected_are_null_it_should_succeed()
        {
            // Arrange
            string actualString = null;
            string expectedString = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actualString).IsEqualTo(expectedString));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_two_strings_differ_unexpectedly_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ADC").IsEqualTo("ABC").Because($"because we {"do"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_strings_differ_unexpectedly_containing_double_curly_closing_braces_it_should_throw()
        {
            // Act
            const string expect = "}}";
            const string actual = "}}}}";
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_strings_differ_unexpectedly_containing_double_curly_opening_braces_it_should_throw()
        {
            // Act
            const string expect = "{{";
            const string actual = "{{{{";
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_shorter_than_the_actual_string_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsEqualTo("AB"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_longer_than_the_actual_string_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("AB").IsEqualTo("ABC"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_empty_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsEqualTo(""));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_subject_string_is_empty_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("").IsEqualTo("ABC"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_is_expected_to_equal_null_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("AB").IsEqualTo(null));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_is_expected_to_be_null_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("AB").IsNull().Because($"we like {"null"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).IsEqualTo("ABC"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_the_same_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsEqualTo("ABC ").Because($"because I say {"so"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_actual_string_is_the_same_as_the_expected_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC ").IsEqualTo("ABC").Because($"because I say {"so"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_strings_differ_and_one_of_them_is_long_it_should_display_both_strings_on_separate_line()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("1234567890").IsEqualTo("0987654321"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("""
                Expected string to be the same string, but they differ at index 0:
                   ↓ (actual)
                  "1234567890"
                  "0987654321"
                   ↑ (expected).
                """).AsWildcard();
        }

        [Fact]
        public async Task When_two_strings_differ_and_one_of_them_is_multiline_it_should_display_both_strings_on_separate_line()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("A\r\nB").IsEqualTo("A\r\nC"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Use_arrows_for_text_longer_than_8_characters()
        {
            const string subject = "this is a long text that differs in between two words";
            const string expected = "this is a long text which differs in between two words";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected).Because("because we use arrows now"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("""
                Expected subject to be the same string because we use arrows now, but they differ at index 20:
                                   ↓ (actual)
                  "…is a long text that…"
                  "…is a long text which…"
                                   ↑ (expected).
                """).AsWildcard();
        }

        [Fact]
        public async Task Only_add_ellipsis_for_long_text()
        {
            const string subject = "this is a long text that differs";
            const string expected = "this was too short";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected).Because("because we use arrows now"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("""
                Expected subject to be the same string because we use arrows now, but they differ at index 5:
                        ↓ (actual)
                  "this is a long text that…"
                  "this was too short"
                        ↑ (expected).
                """).AsWildcard();
        }

        [Theory]
        [InlineData("ThisIsUsedTo Check a difference after 5 characters")]
        [InlineData("ThisIsUsedTo CheckADifferenc e after 15 characters")]
        public async Task Will_look_for_a_word_boundary_between_5_and_15_characters_before_the_mismatching_index_to_highlight_the_mismatch(string expected)
        {
            const string subject = "ThisIsUsedTo CheckADifferenceInThe WordBoundaryAlgorithm";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData("ThisIsUsedTo Chec k a difference after 4 characters", "\"…sedTo CheckADifferen")]
        [InlineData("ThisIsUsedTo CheckADifference after 16 characters", "\"…Difference")]
        public async Task Will_fallback_to_10_characters_if_no_word_boundary_can_be_found_before_the_mismatching_index(
                string expected, string expectedMessagePart)
        {
            const string subject = "ThisIsUsedTo CheckADifferenceInThe WordBoundaryAlgorithm";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage($"*{expectedMessagePart}*").AsWildcard();
        }

        [Theory]
        [InlineData("ThisLongTextIsUsedToCheckADifferenceAtTheEnd after 10 + 5 characters")]
        [InlineData("ThisLongTextIsUsedToCheckADifferen after 10 + 15 characters")]
        public async Task Will_look_for_a_word_boundary_between_15_and_25_characters_after_the_mismatching_index_to_highlight_the_mismatch(string expected)
        {
            const string subject = "ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_empty_string_is_always_shorter_than_a_long_text()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("").IsEqualTo("ThisIsALongText"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_mismatch_below_index_11_includes_all_text_preceding_the_index_in_the_failure()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("This is a long text").IsEqualTo("This is a text that differs at index 10"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData("ThisLongTextIsUsedToCheckADifferenceAtTheEndO after 10 + 4 characters", "eAtTheEndOfThe WordB…\"")]
        [InlineData("ThisLongTextIsUsedToCheckADiffere after 10 + 16 characters", "ckADifferenceAtTheEn…\"")]
        public async Task Will_fallback_to_20_characters_if_no_word_boundary_can_be_found_after_the_mismatching_index(
                string expected, string expectedMessagePart)
        {
            const string subject = "ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage($"*{expectedMessagePart}*").AsWildcard();
        }

        [Fact]
        public async Task Mismatches_in_multiline_text_includes_the_line_number()
        {
            var expectedIndex = 100 + (4 * Environment.NewLine.Length);

            var subject = """
            @startuml
            Alice -> Bob : Authentication Request
            Bob --> Alice : Authentication Response

            Alice -> Bob : Another authentication Request
            Alice <-- Bob : Another authentication Response
            @enduml
            """;

            var expected = """
            @startuml
            Alice -> Bob : Authentication Request
            Bob --> Alice : Authentication Response

            Alice -> Bob : Invalid authentication Request
            Alice <-- Bob : Another authentication Response
            @enduml
            """;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsEqualTo(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage($"""
                Expected subject to be the same string, but they differ on line 5 and column 16 (index {expectedIndex}):
                             ↓ (actual)
                  "…-> Bob : Another…"
                  "…-> Bob : Invalid…"
                             ↑ (expected).
                """).AsWildcard();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task When_different_strings_are_expected_to_differ_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string unexpected = "DEF";

            // Act / Assert
            await Expect.That(actual).IsNotEqualTo(unexpected);
        }

        [Fact]
        public async Task When_equal_strings_are_expected_to_differ_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsNotEqualTo("ABC").Because($"because we don't like {"ABC"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_non_empty_string_is_not_equal_to_empty_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string unexpected = "";

            // Act / Assert
            await Expect.That(actual).IsNotEqualTo(unexpected);
        }

        [Fact]
        public async Task When_empty_string_is_not_supposed_to_be_equal_to_empty_it_should_throw()
        {
            // Arrange
            string actual = "";
            string unexpected = "";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(unexpected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_valid_string_is_not_supposed_to_be_null_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string unexpected = null;

            // Act / Assert
            await Expect.That(actual).IsNotEqualTo(unexpected);
        }

        [Fact]
        public async Task When_null_string_is_not_supposed_to_be_equal_to_null_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).IsNotEqualTo(null));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_null_string_is_not_supposed_to_be_null_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).IsNotNull().Because($"we don't like {"null"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
