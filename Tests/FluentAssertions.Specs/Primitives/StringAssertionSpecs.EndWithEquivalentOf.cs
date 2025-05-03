using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]EndWithEquivalentOf specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class EndWithEquivalentOf
    {
        [Fact]
        public void Succeed_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expect, o => o.Using(comparer));
        }

        [Fact]
        public async Task Fail_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act
            Action act = () => actual.Should().EndWithEquivalentOf(expect, o => o.Using(comparer));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void Can_ignore_casing_while_checking_a_string_to_end_with_another()
        {
            // Arrange
            string actual = "prefix for test";
            string expect = "TEST";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expect, o => o.IgnoringCase());
        }

        [Fact]
        public void Can_ignore_leading_whitespace_while_checking_a_string_to_end_with_another()
        {
            // Arrange
            string actual = "  prefix for test";
            string expect = "test";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());
        }

        [Fact]
        public void Can_ignore_trailing_whitespace_while_checking_a_string_to_end_with_another()
        {
            // Arrange
            string actual = "prefix for test  ";
            string expect = "test";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());
        }

        [Fact]
        public void Can_ignore_newline_style_while_checking_a_string_to_end_with_another()
        {
            // Arrange
            string actual = "prefix for \rA\nB\r\nC";
            string expect = "A\r\nB\nC";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expect, o => o.IgnoringNewlineStyle());
        }

        [Fact]
        public void When_suffix_of_string_differs_by_case_only_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedSuffix = "bC";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expectedSuffix);
        }

        [Fact]
        public void When_end_of_string_differs_by_case_only_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedSuffix = "AbC";

            // Act / Assert
            actual.Should().EndWithEquivalentOf(expectedSuffix);
        }

        [Fact]
        public async Task When_end_of_string_does_not_meet_equivalent_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().EndWithEquivalentOf("ab", "because it should end");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_end_of_string_is_compared_with_equivalent_of_null_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().EndWithEquivalentOf(null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_end_of_string_is_compared_with_equivalent_of_empty_string_it_should_not_throw()
        {
            // Act
            Action act = () => "ABC".Should().EndWithEquivalentOf("");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_string_ending_is_compared_with_equivalent_of_string_that_is_longer_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().EndWithEquivalentOf("00abc");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected string to end with equivalent of " +
                "\"00abc\", but " +
                "\"ABC\" is too short.").AsWildcard();
        }

        [Fact]
        public async Task When_string_ending_is_compared_with_equivalent_and_actual_value_is_null_then_it_should_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                someString.Should().EndWithEquivalentOf("abC");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotEndWithEquivalentOf
    {
        [Fact]
        public void Succeed_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act / Assert
            actual.Should().NotEndWithEquivalentOf(expect, o => o.Using(comparer));
        }

        [Fact]
        public async Task Fail_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act
            Action act = () => actual.Should().NotEndWithEquivalentOf(expect, o => o.Using(comparer));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_casing_while_checking_a_string_to_not_end_with_another()
        {
            // Arrange
            string actual = "prefix for test";
            string expect = "TEST";

            // Act
            Action act = () => actual.Should().NotEndWithEquivalentOf(expect, o => o.IgnoringCase());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_checking_a_string_to_not_end_with_another()
        {
            // Arrange
            string actual = "  prefix for test";
            string expect = "test";

            // Act
            Action act = () => actual.Should().NotEndWithEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_checking_a_string_to_not_end_with_another()
        {
            // Arrange
            string actual = "prefix for test  ";
            string expect = "test";

            // Act
            Action act = () => actual.Should().NotEndWithEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_checking_a_string_to_not_end_with_another()
        {
            // Arrange
            string actual = "prefix for \rA\nB\r\nC\n";
            string expect = "A\r\nB\nC\r";

            // Act
            Action act = () => actual.Should().NotEndWithEquivalentOf(expect, o => o.IgnoringNewlineStyle());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_equivalent_of_a_value_and_it_does_not_it_should_succeed()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotEndWithEquivalentOf("aB");

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_equivalent_of_a_value_but_it_does_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotEndWithEquivalentOf("Bc", "because of some {0}", "reason");

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_equivalent_of_a_value_that_is_null_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotEndWithEquivalentOf(null);

            // Assert
            await Expect.That(action).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_equivalent_of_a_value_that_is_empty_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotEndWithEquivalentOf("");

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_equivalent_of_a_value_and_actual_value_is_null_it_should_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                someString.Should().NotEndWithEquivalentOf("Abc", "some {0}", "reason");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
