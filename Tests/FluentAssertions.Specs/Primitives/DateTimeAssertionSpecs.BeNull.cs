using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_datetime_value_without_a_value_to_be_null()
        {
            // Arrange
            DateTime? nullableDateTime = null;

            // Act
            Action action = () =>
Synchronously.Verify(That(nullableDateTime).IsNull());

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_datetime_value_with_a_value_to_be_null()
        {
            // Arrange
            DateTime? nullableDateTime = new DateTime(2016, 06, 04);

            // Act
            Action action = () =>
Synchronously.Verify(That(nullableDateTime).IsNull());

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_datetime_value_with_a_value_to_not_be_null()
        {
            // Arrange
            DateTime? nullableDateTime = new DateTime(2016, 06, 04);

            // Act
            Action action = () => Synchronously.Verify(That(nullableDateTime).IsNotNull());

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_datetime_value_without_a_value_to_not_be_null()
        {
            // Arrange
            DateTime? nullableDateTime = null;

            // Act
            Action action = () => Synchronously.Verify(That(nullableDateTime).IsNotNull());

            // Assert
            await That(action).Throws<XunitException>();
        }
    }
}
