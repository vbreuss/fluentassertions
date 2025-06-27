#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateOnlyAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_dateonly_value_is_equal_to_the_same_value()
        {
            // Arrange
            DateOnly dateOnly = new(2016, 06, 04);
            DateOnly sameDateOnly = new(2016, 06, 04);

            // Act/Assert
            await That(dateOnly).IsEqualTo(sameDateOnly);
        }

        [Fact]
        public async Task When_dateonly_value_is_equal_to_the_same_nullable_value_be_should_succeed()
        {
            // Arrange
            DateOnly dateOnly = new(2016, 06, 04);
            DateOnly? sameDateOnly = new(2016, 06, 04);

            // Act/Assert
            await That(dateOnly).IsEqualTo(sameDateOnly);
        }

        [Fact]
        public async Task When_both_values_are_at_their_minimum_then_it_should_succeed()
        {
            // Arrange
            DateOnly dateOnly = DateOnly.MinValue;
            DateOnly sameDateOnly = DateOnly.MinValue;

            // Act/Assert
            await That(dateOnly).IsEqualTo(sameDateOnly);
        }

        [Fact]
        public async Task When_both_values_are_at_their_maximum_then_it_should_succeed()
        {
            // Arrange
            DateOnly dateOnly = DateOnly.MaxValue;
            DateOnly sameDateOnly = DateOnly.MaxValue;

            // Act/Assert
            await That(dateOnly).IsEqualTo(sameDateOnly);
        }

        [Fact]
        public async Task Should_fail_when_asserting_dateonly_value_is_equal_to_the_different_value()
        {
            // Arrange
            var dateOnly = new DateOnly(2012, 03, 10);
            var otherDateOnly = new DateOnly(2012, 03, 11);

            // Act
            Action act = () => Synchronously.Verify(That(dateOnly).IsEqualTo(otherDateOnly).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_equals_the_same_value()
        {
            // Arrange
            DateOnly? nullableDateOnlyA = new DateOnly(2016, 06, 04);
            DateOnly? nullableDateOnlyB = new DateOnly(2016, 06, 04);

            // Act/Assert
            await That(nullableDateOnlyA).IsEqualTo(nullableDateOnlyB);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            DateOnly? nullableDateOnlyA = null;
            DateOnly? nullableDateOnlyB = null;

            // Act/Assert
            await That(nullableDateOnlyA).IsEqualTo(nullableDateOnlyB);
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            DateOnly? nullableDateOnlyA = new DateOnly(2016, 06, 04);
            DateOnly? nullableDateOnlyB = new DateOnly(2016, 06, 06);

            // Act
            Action action = () =>
Synchronously.Verify(That(nullableDateOnlyA).IsEqualTo(nullableDateOnlyB));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_dateonly_null_value_is_equal_to_another_value()
        {
            // Arrange
            DateOnly? nullableDateOnly = null;

            // Act
            Action action = () =>
Synchronously.Verify(That(nullableDateOnly).IsEqualTo(new DateOnly(2016, 06, 04)).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_dateonly_value_is_not_equal_to_a_different_value()
        {
            // Arrange
            DateOnly dateOnly = new(2016, 06, 04);
            DateOnly otherDateOnly = new(2016, 06, 05);

            // Act/Assert
            await That(dateOnly).IsNotEqualTo(otherDateOnly);
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task Different_dateonly_values_are_valid()
        {
            // Arrange
            DateOnly date = new(2020, 06, 04);
            DateOnly otherDate = new(2020, 06, 05);

            // Act & Assert
            await That(date).IsNotEqualTo(otherDate);
        }

        [Fact]
        public async Task Different_dateonly_values_with_different_nullability_are_valid()
        {
            // Arrange
            DateOnly date = new(2020, 06, 04);
            DateOnly? otherDate = new(2020, 07, 05);

            // Act & Assert
            await That(date).IsNotEqualTo(otherDate);
        }

        [Fact]
        public async Task Same_dateonly_values_are_invalid()
        {
            // Arrange
            DateOnly date = new(2020, 06, 04);
            DateOnly sameDate = new(2020, 06, 04);

            // Act
            Action act =
                () => Synchronously.Verify(That(date).IsNotEqualTo(sameDate).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Same_dateonly_values_with_different_nullability_are_invalid()
        {
            // Arrange
            DateOnly date = new(2020, 06, 04);
            DateOnly? sameDate = new(2020, 06, 04);

            // Act
            Action act =
                () => Synchronously.Verify(That(date).IsNotEqualTo(sameDate).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}

#endif
