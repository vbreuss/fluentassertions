#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_timeonly_value_is_equal_to_the_same_value()
        {
            // Arrange
            TimeOnly timeOnly = new(15, 06, 04, 146);
            TimeOnly sameTimeOnly = new(15, 06, 04, 146);

            // Act/Assert
            await Expect.That(timeOnly).IsEqualTo(sameTimeOnly);
        }

        [Fact]
        public async Task When_timeonly_value_is_equal_to_the_same_nullable_value_be_should_succeed()
        {
            // Arrange
            TimeOnly timeOnly = new(15, 06, 04, 146);
            TimeOnly? sameTimeOnly = new(15, 06, 04, 146);

            // Act/Assert
            await Expect.That(timeOnly).IsEqualTo(sameTimeOnly);
        }

        [Fact]
        public async Task When_both_values_are_at_their_minimum_then_it_should_succeed()
        {
            // Arrange
            TimeOnly timeOnly = TimeOnly.MinValue;
            TimeOnly sameTimeOnly = TimeOnly.MinValue;

            // Act/Assert
            await Expect.That(timeOnly).IsEqualTo(sameTimeOnly);
        }

        [Fact]
        public async Task When_both_values_are_at_their_maximum_then_it_should_succeed()
        {
            // Arrange
            TimeOnly timeOnly = TimeOnly.MaxValue;
            TimeOnly sameTimeOnly = TimeOnly.MaxValue;

            // Act/Assert
            await Expect.That(timeOnly).IsEqualTo(sameTimeOnly);
        }

        [Fact]
        public async Task Should_fail_when_asserting_timeonly_value_is_equal_to_the_different_value()
        {
            // Arrange
            var timeOnly = new TimeOnly(15, 03, 10);
            var otherTimeOnly = new TimeOnly(15, 03, 11);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(timeOnly).IsEqualTo(otherTimeOnly).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_when_asserting_timeonly_value_is_equal_to_the_different_value_by_milliseconds()
        {
            // Arrange
            var timeOnly = new TimeOnly(15, 03, 10, 556);
            var otherTimeOnly = new TimeOnly(15, 03, 10, 175);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(timeOnly).IsEqualTo(otherTimeOnly).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_equals_the_same_value()
        {
            // Arrange
            TimeOnly? nullableTimeOnlyA = new TimeOnly(15, 06, 04, 123);
            TimeOnly? nullableTimeOnlyB = new TimeOnly(15, 06, 04, 123);

            // Act/Assert
            await Expect.That(nullableTimeOnlyA).IsEqualTo(nullableTimeOnlyB);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            TimeOnly? nullableTimeOnlyA = null;
            TimeOnly? nullableTimeOnlyB = null;

            // Act/Assert
            await Expect.That(nullableTimeOnlyA).IsEqualTo(nullableTimeOnlyB);
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            TimeOnly? nullableTimeOnlyA = new TimeOnly(15, 06, 04);
            TimeOnly? nullableTimeOnlyB = new TimeOnly(15, 06, 06);

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeOnlyA).IsEqualTo(nullableTimeOnlyB));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_timeonly_null_value_is_equal_to_another_value()
        {
            // Arrange
            TimeOnly? nullableTimeOnly = null;

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableTimeOnly).IsEqualTo(new TimeOnly(15, 06, 04)).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_timeonly_value_is_not_equal_to_a_different_value()
        {
            // Arrange
            TimeOnly timeOnly = new(15, 06, 04);
            TimeOnly otherTimeOnly = new(15, 06, 05);

            // Act/Assert
            await Expect.That(timeOnly).IsNotEqualTo(otherTimeOnly);
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task Different_timeonly_values_are_valid()
        {
            // Arrange
            TimeOnly time = new(19, 06, 04);
            TimeOnly otherTime = new(20, 06, 05);

            // Act & Assert
            await Expect.That(time).IsNotEqualTo(otherTime);
        }

        [Fact]
        public async Task Different_timeonly_values_with_different_nullability_are_valid()
        {
            // Arrange
            TimeOnly time = new(19, 06, 04);
            TimeOnly? otherTime = new(19, 07, 05);

            // Act & Assert
            await Expect.That(time).IsNotEqualTo(otherTime);
        }

        [Fact]
        public async Task Same_timeonly_values_are_invalid()
        {
            // Arrange
            TimeOnly time = new(19, 06, 04);
            TimeOnly sameTime = new(19, 06, 04);

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(time).IsNotEqualTo(sameTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Same_timeonly_values_with_different_nullability_are_invalid()
        {
            // Arrange
            TimeOnly time = new(19, 06, 04);
            TimeOnly? sameTime = new(19, 06, 04);

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(time).IsNotEqualTo(sameTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}

#endif
