using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_without_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act / Assert
            await That(nullableInteger).IsNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_with_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => Synchronously.Verify(That(nullableInteger).IsNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_with_a_value_to_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => Synchronously.Verify(That(nullableInteger).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_with_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act / Assert
            await That(nullableInteger).IsNotNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_without_a_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => Synchronously.Verify(That(nullableInteger).IsNotNull());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_without_a_value_to_not_be_null()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => Synchronously.Verify(That(nullableInteger).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
