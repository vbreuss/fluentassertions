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
        await Expect.That(nullableTimeSpan).IsNotNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act / Assert
        await Expect.That(nullableTimeSpan).IsNotNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNotNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_without_a_value_to_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_without_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act / Assert
        await Expect.That(nullableTimeSpan).IsNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_TimeSpan_value_without_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = null;

        // Act / Assert
        await Expect.That(nullableTimeSpan).IsNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_TimeSpan_value_with_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_TimeSpan_value_with_a_value_to_be_null()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpan).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_a_different_nullable_TimeSpan_it_should_should_throw_appropriately()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = 1.Seconds();
        TimeSpan? nullableTimeSpanB = 2.Seconds();

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await Expect.That(action).Throws<XunitException>();
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
            aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_another_a_nullable_TimeSpan_and_both_are_null_it_should_succeed()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = null;
        TimeSpan? nullableTimeSpanB = null;

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_a_nullable_TimeSpan_is_equal_to_the_same_nullable_TimeSpan_it_should_succeed()
    {
        // Arrange
        TimeSpan? nullableTimeSpanA = default(TimeSpan);
        TimeSpan? nullableTimeSpanB = default(TimeSpan);

        // Act
        Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeSpanA).IsEqualTo(nullableTimeSpanB));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        TimeSpan? nullableTimeSpan = default(TimeSpan);

        // Act / Assert
        await Expect.That(nullableTimeSpan).IsNotNull();
    }
}
