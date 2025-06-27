using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeLessThan
    {
        [Fact]
        public async Task A_float_can_never_be_less_than_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(float.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_less_than_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_less_than_NaN()
        {
            // Arrange
            double? value = 3.4F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(double.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_less_than_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(5, -1)]
        [InlineData(10, 5)]
        [InlineData(10, -1)]
        public async Task To_test_the_remaining_paths_for_difference_on_nullable_int(int? subject, int expectation)
        {
            // Arrange
            // Act
            Action act = () => Synchronously.Verify(That(subject).IsLessThan(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(5L, -1L)]
        [InlineData(10L, 5L)]
        [InlineData(10L, -1L)]
        public async Task To_test_the_remaining_paths_for_difference_on_nullable_long(long? subject, long expectation)
        {
            // Arrange
            // Act
            Action act = () => Synchronously.Verify(That(subject).IsLessThan(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
