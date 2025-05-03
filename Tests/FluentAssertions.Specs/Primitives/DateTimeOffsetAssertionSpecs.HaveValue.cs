using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveValue
    {
        [Fact]
        public async Task When_nullable_datetimeoffset_value_with_a_value_to_have_a_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsNotNull());

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_datetimeoffset_value_without_a_value_to_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsNotNull());

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }
    }

    public class NotHaveValue
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_datetimeoffset_value_without_a_value_to_not_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsNull());

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_datetimeoffset_value_with_a_value_to_not_have_a_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsNull());

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }
    }
}
