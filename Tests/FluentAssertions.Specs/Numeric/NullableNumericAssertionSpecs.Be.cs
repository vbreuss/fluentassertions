using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_equals_an_equal_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 1;

            // Act / Assert
            await That(nullableIntegerA).IsEqualTo(nullableIntegerB);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            int? nullableIntegerA = null;
            int? nullableIntegerB = null;

            // Act / Assert
            await That(nullableIntegerA).IsEqualTo(nullableIntegerB);
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () => Synchronously.Verify(That(nullableIntegerA).IsEqualTo(nullableIntegerB));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () =>
Synchronously.Verify(That(nullableIntegerA).IsEqualTo(nullableIntegerB).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Nan_is_never_equal_to_a_normal_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.4F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_be_compared_to_NaN_when_its_a_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            await That(value).IsEqualTo(float.NaN);
        }

        [Fact]
        public async Task Nan_is_never_equal_to_a_normal_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.4D));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_be_compared_to_NaN_when_its_a_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            await That(value).IsEqualTo(double.NaN);
        }
    }
}
