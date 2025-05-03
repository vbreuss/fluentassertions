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
            await Expect.That(nullableIntegerA).IsEqualTo(nullableIntegerB);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            int? nullableIntegerA = null;
            int? nullableIntegerB = null;

            // Act / Assert
            await Expect.That(nullableIntegerA).IsEqualTo(nullableIntegerB);
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableIntegerA).IsEqualTo(nullableIntegerB));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            int? nullableIntegerA = 1;
            int? nullableIntegerB = 2;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableIntegerA).IsEqualTo(nullableIntegerB).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Nan_is_never_equal_to_a_normal_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsEqualTo(3.4F));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_be_compared_to_NaN_when_its_a_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            await Expect.That(value).IsEqualTo(float.NaN);
        }

        [Fact]
        public async Task Nan_is_never_equal_to_a_normal_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsEqualTo(3.4D));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_be_compared_to_NaN_when_its_a_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            await Expect.That(value).IsEqualTo(double.NaN);
        }
    }
}
