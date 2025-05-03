using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeEquivalentTo specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeEquivalentTo
    {
        [Fact]
        public async Task Succeed_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expect);
        }

        [Fact]
        public async Task Fail_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_casing_while_comparing_strings_to_be_equivalent()
        {
            // Arrange
            string actual = "test";
            string expect = "TEST";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expect);
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_comparing_strings_to_be_equivalent()
        {
            // Arrange
            string actual = "  test";
            string expect = "test";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expect);
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_comparing_strings_to_be_equivalent()
        {
            // Arrange
            string actual = "test  ";
            string expect = "test";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expect);
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_comparing_strings_to_be_equivalent()
        {
            // Arrange
            string actual = "A\nB\r\nC";
            string expect = "A\r\nB\nC";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expect);
        }

        [Fact]
        public async Task When_strings_are_the_same_while_ignoring_case_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedEquivalent = "abc";

            // Act / Assert
            await Expect.That(actual).IsEqualTo(expectedEquivalent);
        }

        [Fact]
        public async Task When_strings_differ_other_than_by_case_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ADC").IsEquivalentTo("abc").Because($"we will test {2} + {2}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_non_empty_string_is_expected_to_be_equivalent_to_empty_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsEquivalentTo(""));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_is_equivalent_but_too_short_it_should_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("AB").IsEquivalentTo("ABCD"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_equivalence_is_asserted_and_actual_value_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).IsEqualTo("abc").Because($"we will test {2} + {2}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_expected_string_is_equivalent_to_the_actual_string_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsEquivalentTo("abc ").Because($"because I say {"so"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_actual_string_equivalent_to_the_expected_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC ").IsEquivalentTo("abc").Because($"because I say {"so"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact]
        public async Task Succeed_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act / Assert
            await Expect.That(actual).IsNotEqualTo(expect);
        }

        [Fact]
        public async Task Fail_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_casing_while_comparing_strings_to_not_be_equivalent()
        {
            // Arrange
            string actual = "test";
            string expect = "TEST";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_comparing_strings_to_not_be_equivalent()
        {
            // Arrange
            string actual = "  test";
            string expect = "test";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_comparing_strings_to_not_be_equivalent()
        {
            // Arrange
            string actual = "test  ";
            string expect = "test";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_comparing_strings_to_not_be_equivalent()
        {
            // Arrange
            string actual = "\rA\nB\r\nC\n";
            string expect = "\nA\r\nB\nC\r";

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(expect));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_are_the_same_while_ignoring_case_it_should_throw()
        {
            // Arrange
            string actual = "ABC";
            string unexpected = "abc";

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNotEqualTo(unexpected).Because($"because I say {"so"}"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_differ_other_than_by_case_it_should_not_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ADC").IsNotEquivalentTo("abc"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_non_empty_string_is_expected_to_be_equivalent_to_empty_it_should_not_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsNotEquivalentTo(""));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_string_is_equivalent_but_too_short_it_should_not_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("AB").IsNotEquivalentTo("ABCD"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_string_equivalence_is_asserted_and_actual_value_is_null_then_it_should_not_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someString).IsNotEqualTo("abc"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_expected_string_is_equivalent_to_the_actual_string_but_with_trailing_spaces_it_should_not_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC").IsNotEquivalentTo("abc "));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_the_actual_string_equivalent_to_the_expected_but_with_trailing_spaces_it_should_not_throw()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That("ABC ").IsNotEquivalentTo("abc"));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
