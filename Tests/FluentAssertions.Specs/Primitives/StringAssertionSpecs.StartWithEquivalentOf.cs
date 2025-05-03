﻿using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]StartWithEquivalentOf specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class StartWithEquivalentOf
    {
        [Fact]
        public void Succeed_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expect, o => o.Using(comparer));
        }

        [Fact]
        public async Task Fail_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act
            Action act = () => actual.Should().StartWithEquivalentOf(expect, o => o.Using(comparer));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void Can_ignore_casing_while_checking_a_string_to_start_with_another()
        {
            // Arrange
            string actual = "test with suffix";
            string expect = "TEST";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expect, o => o.IgnoringCase());
        }

        [Fact]
        public void Can_ignore_leading_whitespace_while_checking_a_string_to_start_with_another()
        {
            // Arrange
            string actual = "  test with suffix";
            string expect = "test";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());
        }

        [Fact]
        public void Can_ignore_trailing_whitespace_while_checking_a_string_to_start_with_another()
        {
            // Arrange
            string actual = "test with suffix  ";
            string expect = "test";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());
        }

        [Fact]
        public void Can_ignore_newline_style_while_checking_a_string_to_start_with_another()
        {
            // Arrange
            string actual = "\rA\nB\r\nC\n with suffix";
            string expect = "\r\nA\rB\nC";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expect, o => o.IgnoringNewlineStyle());
        }

        [Fact]
        public void When_start_of_string_differs_by_case_only_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedPrefix = "Ab";

            // Act / Assert
            actual.Should().StartWithEquivalentOf(expectedPrefix);
        }

        [Fact]
        public async Task When_start_of_string_does_not_meet_equivalent_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().StartWithEquivalentOf("bc", "because it should start");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_start_of_string_does_not_meet_equivalent_and_one_of_them_is_long_it_should_display_both_strings_on_separate_line()
        {
            // Act
            Action act = () => "ABCDEFGHI".Should().StartWithEquivalentOf("abcddfghi", "it should {0}", "start");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected string to start with equivalent of " +
                "*\"abcddfghi\" because it should start, but " +
                "*\"ABCDEFGHI\" differs near \"EFG\" (index 4).").AsWildcard();
        }

        [Fact]
        public async Task When_start_of_string_is_compared_with_equivalent_of_null_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().StartWithEquivalentOf(null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_start_of_string_is_compared_with_equivalent_of_empty_string_it_should_not_throw()
        {
            // Act
            Action act = () => "ABC".Should().StartWithEquivalentOf("");

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_start_of_string_is_compared_with_equivalent_of_string_that_is_longer_it_should_throw()
        {
            // Act
            Action act = () => "ABC".Should().StartWithEquivalentOf("abcdef");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected string to start with equivalent of " +
                "\"abcdef\", but " +
                "\"ABC\" is too short.").AsWildcard();
        }

        [Fact]
        public async Task When_string_start_is_compared_with_equivalent_and_actual_value_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => someString.Should().StartWithEquivalentOf("AbC");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotStartWithEquivalentOf
    {
        [Fact]
        public void Succeed_for_same_strings_using_custom_not_matching_comparer()
        {
            // Arrange
            var comparer = new NeverMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "ABC";

            // Act / Assert
            actual.Should().NotStartWithEquivalentOf(expect, o => o.Using(comparer));
        }

        [Fact]
        public async Task Fail_for_different_strings_using_custom_matching_comparer()
        {
            // Arrange
            var comparer = new AlwaysMatchingEqualityComparer();
            string actual = "ABC";
            string expect = "XYZ";

            // Act
            Action act = () => actual.Should().NotStartWithEquivalentOf(expect, o => o.Using(comparer));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_casing_while_checking_a_string_to_not_start_with_another()
        {
            // Arrange
            string actual = "test with suffix";
            string expect = "TEST";

            // Act
            Action act = () => actual.Should().NotStartWithEquivalentOf(expect, o => o.IgnoringCase());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_checking_a_string_to_not_start_with_another()
        {
            // Arrange
            string actual = "  test with suffix";
            string expect = "test";

            // Act
            Action act = () => actual.Should().NotStartWithEquivalentOf(expect, o => o.IgnoringLeadingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_checking_a_string_to_not_start_with_another()
        {
            // Arrange
            string actual = "test with suffix  ";
            string expect = "test";

            // Act
            Action act = () => actual.Should().NotStartWithEquivalentOf(expect, o => o.IgnoringTrailingWhitespace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_checking_a_string_to_not_start_with_another()
        {
            // Arrange
            string actual = "\rA\nB\r\nC\n with suffix";
            string expect = "\nA\r\nB\rC";

            // Act
            Action act = () => actual.Should().NotStartWithEquivalentOf(expect, o => o.IgnoringNewlineStyle());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_equivalent_of_a_value_and_it_does_not_it_should_succeed()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotStartWithEquivalentOf("Bc");

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_equivalent_of_a_value_but_it_does_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotStartWithEquivalentOf("aB", "because of some reason");

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_equivalent_of_a_value_that_is_null_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotStartWithEquivalentOf(null);

            // Assert
            await Expect.That(action).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_equivalent_of_a_value_that_is_empty_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
                value.Should().NotStartWithEquivalentOf("");

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_equivalent_of_a_value_and_actual_value_is_null_it_should_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Action act = () => someString.Should().NotStartWithEquivalentOf("ABC");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
