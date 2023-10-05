using System;
using System.Collections.Generic;
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
        public void Consider_ignoring_case_on_options_builder()
        {
            // Arrange
            const string actual = "test A";
            const string expect = "test a";

            // Act / Assert
            actual.Should().BeEquivalentTo(expect, o => o.IgnoringCase());
        }

        [Fact]
        public void Fail_for_string_differing_in_casing_when_not_ignoring_case()
        {
            // Arrange
            const string actual = "test A";
            const string expect = "test a";

            // Act
            Action act = () => actual.Should().BeEquivalentTo(expect, o => o.IgnoringLeadingWhitespace());

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Consider_ignoring_leading_whitespace_on_options_builder()
        {
            // Arrange
            const string actual = "  test  ";
            const string expect = "test  ";

            // Act / Assert
            actual.Should().BeEquivalentTo(expect, o => o.IgnoringLeadingWhitespace());
        }

        [Fact]
        public void Fail_for_string_differing_in_leading_whitespace_when_not_ignoring_leading_whitespace()
        {
            // Arrange
            const string actual = "  test  ";
            const string expect = "test  ";

            // Act
            Action act = () => actual.Should().BeEquivalentTo(expect, o => o.IgnoringTrailingWhitespace());

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Consider_ignoring_trailing_whitespace_on_options_builder()
        {
            // Arrange
            const string actual = "  test  ";
            const string expect = "  test";

            // Act / Assert
            actual.Should().BeEquivalentTo(expect, o => o.IgnoringTrailingWhitespace());
        }

        [Fact]
        public void Fail_for_string_differing_in_trailing_whitespace_when_not_ignoring_trailing_whitespace()
        {
            // Arrange
            const string actual = "  test  ";
            const string expect = "  test";

            // Act
            Action act = () => actual.Should().BeEquivalentTo(expect, o => o.IgnoringLeadingWhitespace());

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Consider_ignoring_newlines_on_options_builder()
        {
            // Arrange
            const string actual = "test\r\n-second\n-third";
            const string expect = "test-sec\r\nond-third";

            // Act / Assert
            actual.Should().BeEquivalentTo(expect, o => o.IgnoringNewlines());
        }

        [Fact]
        public void Fail_for_string_differing_in_newlines_when_not_ignoring_newlines()
        {
            // Arrange
            const string actual = "test\r\n-second\n-third";
            const string expect = "test-second-third";

            // Act
            Action act = () => actual.Should().BeEquivalentTo(expect, o => o.IgnoringCase());

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void Use_custom_comparer()
        {
            // Arrange
            var comparer = new DummyEqualityComparer((_, _) => true);
            string actual = "test A";
            string expect = "test B";

            // Act / Assert
            actual.Should().BeEquivalentTo(expect, comparer);
        }

        [Fact]
        public void Fail_for_mismatch_using_custom_comparer()
        {
            // Arrange
            var comparer = new DummyEqualityComparer((_, _) => false);
            string actual = "foo";
            string expect = "foo";

            // Act
            Action act = () => actual.Should().BeEquivalentTo(expect, comparer);

            // Assert
            act.Should().Throw<XunitException>();
        }

        [Fact]
        public void When_strings_are_the_same_while_ignoring_case_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedEquivalent = "abc";

            // Act / Assert
            actual.Should().BeEquivalentTo(expectedEquivalent);
        }

        [Fact]
        public void When_strings_differ_other_than_by_case_it_should_throw()
        {
            // Act
            Action act = () => "ADC".Should().BeEquivalentTo("abc", "we will test {0} + {1}", 1, 2);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to \"abc\" because we will test 1 + 2, but \"ADC\" differs near \"DC\" (index 1).");
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void When_non_null_string_is_expected_to_be_equivalent_to_null_it_should_throw()
        {
            // Act
            Action act = () => "ABCDEF".Should().BeEquivalentTo(null);

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to <null>, but found \"ABCDEF\".");
        }

        [Fact]
        public void When_non_empty_string_is_expected_to_be_equivalent_to_empty_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().BeEquivalentTo("");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to \"\" with a length of 0, but \"ABC\" has a length of 3, differs near \"ABC\" (index 0).");
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void When_string_is_equivalent_but_too_short_it_should_throw()
        {
            // Act
            Action act = () => "AB".Should().BeEquivalentTo("ABCD");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to \"ABCD\" with a length of 4, but \"AB\" has a length of 2*");
        }

        [Fact]
        public void When_string_equivalence_is_asserted_and_actual_value_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => someString.Should().BeEquivalentTo("abc", "we will test {0} + {1}", 1, 2);

            // Assert
            act.Should().Throw<XunitException>()
                .WithMessage("Expected someString to be equivalent to \"abc\" because we will test 1 + 2, but found <null>.");
        }

        [Fact]
        public void
            When_the_expected_string_is_equivalent_to_the_actual_string_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => "ABC".Should().BeEquivalentTo("abc ", "because I say {0}", "so");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to \"abc \" because I say so, but it misses some extra whitespace at the end.");
        }

        [Fact]
        public void
            When_the_actual_string_equivalent_to_the_expected_but_with_trailing_spaces_it_should_throw_with_clear_error_message()
        {
            // Act
            Action act = () => "ABC ".Should().BeEquivalentTo("abc", "because I say {0}", "so");

            // Assert
            act.Should().Throw<XunitException>().WithMessage(
                "Expected string to be equivalent to \"abc\" because I say so, but it has unexpected whitespace at the end.");
        }

        private sealed class DummyEqualityComparer : IEqualityComparer<string>
        {
            private readonly Func<string, string, bool> callback;

            public DummyEqualityComparer(Func<string, string, bool> callback)
            {
                this.callback = callback;
            }

            public bool Equals(string x, string y)
            {
                return callback(x, y);
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact]
        public void When_strings_are_the_same_while_ignoring_case_it_should_throw()
        {
            // Arrange
            string actual = "ABC";
            string unexpected = "abc";

            // Act
            Action action = () => actual.Should().NotBeEquivalentTo(unexpected, "because I say {0}", "so");

            // Assert
            action.Should().Throw<XunitException>()
                .WithMessage("Expected actual not to be equivalent to \"abc\" because I say so, but they are.");
        }

        [Fact]
        public void When_strings_differ_other_than_by_case_it_should_not_throw()
        {
            // Act
            Action act = () => "ADC".Should().NotBeEquivalentTo("abc");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_non_null_string_is_expected_to_be_equivalent_to_null_it_should_not_throw()
        {
            // Act
            Action act = () => "ABCDEF".Should().NotBeEquivalentTo(null);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_non_empty_string_is_expected_to_be_equivalent_to_empty_it_should_not_throw()
        {
            // Act
            Action act = () => "ABC".Should().NotBeEquivalentTo("");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_string_is_equivalent_but_too_short_it_should_not_throw()
        {
            // Act
            Action act = () => "AB".Should().NotBeEquivalentTo("ABCD");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_string_equivalence_is_asserted_and_actual_value_is_null_then_it_should_not_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Action act = () => someString.Should().NotBeEquivalentTo("abc");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_the_expected_string_is_equivalent_to_the_actual_string_but_with_trailing_spaces_it_should_not_throw()
        {
            // Act
            Action act = () => "ABC".Should().NotBeEquivalentTo("abc ");

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void When_the_actual_string_equivalent_to_the_expected_but_with_trailing_spaces_it_should_not_throw()
        {
            // Act
            Action act = () => "ABC ".Should().NotBeEquivalentTo("abc");

            // Assert
            act.Should().NotThrow();
        }
    }
}
