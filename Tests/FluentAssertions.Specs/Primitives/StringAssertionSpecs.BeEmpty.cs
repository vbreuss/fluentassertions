using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeEmpty specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeEmpty
    {
        [Fact]
        public async Task Should_succeed_when_asserting_empty_string_to_be_empty()
        {
            // Arrange
            string actual = "";

            // Act / Assert
            await That(actual).IsEmpty();
        }

        [Fact]
        public async Task Should_fail_when_asserting_non_empty_string_to_be_empty()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEmpty());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_non_empty_string_to_be_empty()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsEmpty().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_checking_for_an_empty_string_and_it_is_null_it_should_throw()
        {
            // Arrange
            string nullString = null;

            // Act
            Action act = () => Synchronously.Verify(That(nullString).IsEmpty().Because($"because strings should never be {"null"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeEmpty
    {
        [Fact]
        public async Task Should_succeed_when_asserting_non_empty_string_to_be_filled()
        {
            // Arrange
            string actual = "ABC";

            // Act / Assert
            await That(actual).IsNotEmpty();
        }

        [Fact]
        public async Task When_asserting_null_string_to_not_be_empty_it_should_succeed()
        {
            // Arrange
            string actual = null;

            // Act / Assert
            await That(actual).IsNotEmpty();
        }

        [Fact]
        public async Task Should_fail_when_asserting_empty_string_to_be_filled()
        {
            // Arrange
            string actual = "";

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsNotEmpty());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_empty_string_to_be_filled()
        {
            // Arrange
            string actual = "";

            // Act
            Action act = () => Synchronously.Verify(That(actual).IsNotEmpty().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
