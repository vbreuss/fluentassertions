using System;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public class NullableSimpleTimeSpanAssertionSpecs
{
    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_with_a_value_to_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act / Assert
        await That(nullableTimeSpan).IsNotNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act / Assert
        await That(nullableTimeSpan).IsNotNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNotNull());

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_without_a_value_to_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act / Assert
        await That(nullableTimeSpan).IsNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_without_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act / Assert
        await That(nullableTimeSpan).IsNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNull());

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_with_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNull());

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = 1.Seconds();

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_with_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = 1.Seconds();

        // Act
        Action act = () => Synchronously.Verify(That(nullableTimeSpan).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_a_different_nullable_TimeSpan_it_should_should_throw_appropriately()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = 1.Seconds();
        TimeSpan? nullableTimeSpanB = 2.Seconds();

        // Act
        Action action = () => Synchronously.Verify(That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_another_a_nullable_TimeSpan_but_it_is_null_it_should_fail_with_a_descriptive_message()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = null;
        TimeSpan? nullableTimeSpanB = 1.Seconds();

        // Act
        Action action =
            () =>
            Synchronously.Verify(That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB).Because($"because we want to test the failure {"message"}"));

        // Assert
        await That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_another_a_nullable_TimeSpan_and_both_are_null_it_should_succeed()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = null;
        TimeSpan? nullableTimeSpanB = null;

        // Act
        Action action = () => Synchronously.Verify(That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_the_same_nullable_TimeSpan_it_should_succeed()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = default(TimeSpan);
        TimeSpan? nullableTimeSpanB = default(TimeSpan);

        // Act
        Action action = () => Synchronously.Verify(That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await That(action).DoesNotThrow();
    }

    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act / Assert
        await That(nullableTimeSpan).IsNotNull();
    }
}
