using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeNegative
    {
        [Fact]
        public async Task When_a_negative_value_is_negative_it_should_not_throw()
        {
            // Arrange
            int value = -1;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_positive_value_is_negative_it_should_throw()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_zero_value_is_negative_it_should_throw()
        {
            // Arrange
            int value = 0;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_positive_value_is_negative_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 1;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_numeric_null_value_is_not_negative_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_a_negative_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_a_negative_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsNegative());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
