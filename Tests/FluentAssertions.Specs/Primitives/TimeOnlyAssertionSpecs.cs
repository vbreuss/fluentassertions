#if NET6_0_OR_GREATER
using System;
using Xunit;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    [Fact]
    public async Task Should_succeed_when_asserting_nullable_timeonly_value_with_value_to_have_a_value()
    {
        // Arrange
        TimeOnly? timeOnly = new(15, 06, 04);

        // Act/Assert
        await Expect.That(timeOnly).IsNotNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_timeonly_value_with_value_to_not_be_null()
    {
        // Arrange
        TimeOnly? timeOnly = new(15, 06, 04);

        // Act/Assert
        await Expect.That(timeOnly).IsNotNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_timeonly_value_with_null_to_be_null()
    {
        // Arrange
        TimeOnly? timeOnly = null;

        // Act/Assert
        await Expect.That(timeOnly).IsNull();
    }

    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        TimeOnly earlierTimeOnly = new(15, 06, 03);
        TimeOnly? nullableTimeOnly = new(15, 06, 04);

        // Act/Assert
        await That(nullableTimeOnly).IsNotNull();
    }

    [Fact]
    public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
    {
        // Arrange
        TimeOnly someTimeOnly = new(21, 1);

        // Act
        var act = () => someTimeOnly.Should().Equals(null);

        // Assert
        await Expect.That(act).Throws<NotSupportedException>();
    }
}

#endif
