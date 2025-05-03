using System;
using FluentAssertions.Common;
using Xunit;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class ChainingConstraint
    {
        [Fact]
        public async Task Should_support_chaining_constraints_with_and()
        {
            // Arrange
            DateTimeOffset yesterday = new DateTime(2016, 06, 03).ToDateTimeOffset();
            DateTimeOffset? nullableDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsNotNull());

            // Assert
            await Expect.That(action).DoesNotThrow();
        }
    }

    public class Miscellaneous
    {
        [Fact]
        public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            DateTimeOffset someDateTimeOffset = new(2022, 9, 25, 13, 48, 42, 0, TimeSpan.Zero);

            // Act
            var action = () => someDateTimeOffset.Should().Equals(null);

            // Assert
            await Expect.That(action).Throws<NotSupportedException>();
        }
    }
}
