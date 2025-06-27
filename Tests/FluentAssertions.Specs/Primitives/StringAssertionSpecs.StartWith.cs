using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;
using static System.Collections.Specialized.BitVector32;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]StartWith specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class StartWith
    {
        [Fact]
        public async Task When_asserting_string_starts_with_the_same_value_it_should_not_throw()
        {
            // Arrange
            string value = "ABC";

            // Act / Assert
            await That(value).StartsWith("AB");
        }

        [Fact]
        public async Task When_expected_string_is_the_same_value_it_should_not_throw()
        {
            // Arrange
            string value = "ABC";

            // Act / Assert
            await That(value).StartsWith(value);
        }

        [Fact]
        public async Task When_string_does_not_start_with_expected_phrase_it_should_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").StartsWith("ABB").Because($"it should {"start"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_does_not_start_with_expected_phrase_and_one_of_them_is_long_it_should_display_both_strings_on_separate_line()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABCDEFGHI").StartsWith("ABCDDFGHI").Because($"it should {"start"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_start_is_compared_with_null_it_should_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").StartsWith(null));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("cannot be validated against <null>").AsSuffix();
        }

        [Fact]
        public async Task When_string_start_is_compared_with_empty_string_it_should_not_throw()
        {
            // Act / Assert
            await That("ABC").StartsWith("");
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task When_string_start_is_compared_with_string_that_is_longer_it_should_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").StartsWith("ABCDEF"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public async Task Correctly_stop_further_execution_when_inside_assertion_scope()
        {
            // Act
            Func<Task> act = async () =>
            {
                await That("ABC").StartsWith("ABCDEF");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_start_is_compared_and_actual_value_is_null_then_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => Synchronously.Verify(That(someString).StartsWith("ABC"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotStartWith
    {
        [Fact]
        public async Task When_asserting_string_does_not_start_with_a_value_and_it_does_not_it_should_succeed()
        {
            // Arrange
            string value = "ABC";

            // Act / Assert
            await That(value).DoesNotStartWith("DE");
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_a_value_but_it_does_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotStartWith("AB").Because("because of some reason"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_a_value_that_is_null_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotStartWith(null));

            // Assert
            await That(action).Throws<XunitException>().WithMessage("cannot be validated against <null>").AsSuffix();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_a_value_that_is_empty_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotStartWith(""));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_start_with_a_value_and_actual_value_is_null_it_should_throw()
        {
            // Act
            string someString = null;
            Action act = () => Synchronously.Verify(That(someString).DoesNotStartWith("ABC"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
