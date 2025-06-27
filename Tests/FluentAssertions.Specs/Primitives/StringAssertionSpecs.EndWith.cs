using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;
using static System.Collections.Specialized.BitVector32;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]EndWith specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class EndWith
    {
        [Fact]
        public async Task When_asserting_string_ends_with_a_suffix_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedSuffix = "BC";

            // Act / Assert
            await That(actual).EndsWith(expectedSuffix);
        }

        [Fact]
        public async Task When_asserting_string_ends_with_the_same_value_it_should_not_throw()
        {
            // Arrange
            string actual = "ABC";
            string expectedSuffix = "ABC";

            // Act / Assert
            await That(actual).EndsWith(expectedSuffix);
        }

        [Fact]
        public async Task When_string_does_not_end_with_expected_phrase_it_should_throw()
        {
            // Act
            Func<Task> act = async () =>
            {
                await That("ABC").EndsWith("AB").Because("it should");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_ending_is_compared_with_null_it_should_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").EndsWith(null));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("cannot be validated against <null>").AsSuffix();
        }

        [Fact]
        public async Task When_string_ending_is_compared_with_empty_string_it_should_not_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").EndsWith(""));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_string_ending_is_compared_with_string_that_is_longer_it_should_throw()
        {
            // Act
            Action act = () => Synchronously.Verify(That("ABC").EndsWith("00ABC"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Correctly_stop_further_execution_when_inside_assertion_scope()
        {
            // Act
            Func<Task> act = async () =>
            {
                await That("ABC").EndsWith("00ABC");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_string_ending_is_compared_and_actual_value_is_null_then_it_should_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(someString).EndsWith("ABC");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotEndWith
    {
        [Fact]
        public async Task When_asserting_string_does_not_end_with_a_value_and_it_does_not_it_should_succeed()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotEndWith("AB"));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_a_value_but_it_does_it_should_fail_with_a_descriptive_message()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotEndWith("BC").Because($"because of some {"reason"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_a_value_that_is_null_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotEndWith(null));

            // Assert
            await That(action).Throws<XunitException>().WithMessage("cannot be validated against <null>").AsSuffix();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_a_value_that_is_empty_it_should_throw()
        {
            // Arrange
            string value = "ABC";

            // Act
            Action action = () =>
Synchronously.Verify(That(value).DoesNotEndWith(""));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_string_does_not_end_with_a_value_and_actual_value_is_null_it_should_throw()
        {
            // Arrange
            string someString = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(someString).DoesNotEndWith("ABC").Because($"some {"reason"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
