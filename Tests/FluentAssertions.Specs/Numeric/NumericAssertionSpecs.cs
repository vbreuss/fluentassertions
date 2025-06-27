using System;
using Xunit;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    [Fact]
    public async Task When_chaining_constraints_with_and_should_not_throw()
    {
        // Arrange
        int value = 2;

        // Act
        Action action = () => Synchronously.Verify(That(value).IsPositive());

        // Assert
        await That(action).DoesNotThrow();
    }

    [Fact]
    public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
    {
        // Arrange
        int value = 1;

        // Act
        Action action = () => value.Should().Equals(1);

        // Assert
        await That(action).Throws<NotSupportedException>();
    }
}
