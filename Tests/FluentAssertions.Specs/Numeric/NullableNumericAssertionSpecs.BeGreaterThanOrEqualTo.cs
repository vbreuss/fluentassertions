using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public async Task A_float_can_never_be_greater_than_or_equal_to_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(float.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_or_equal_to_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_greater_than_or_equal_to_NaN()
        {
            // Arrange
            double? value = 3.4;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(double.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_or_equal_to_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(0));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
