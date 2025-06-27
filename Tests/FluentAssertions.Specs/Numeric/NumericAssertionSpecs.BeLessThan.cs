using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeLessThan
    {
        [Fact]
        public async Task When_a_value_is_less_than_greater_value_it_should_not_throw()
        {
            // Arrange
            int value = 1;
            int greaterValue = 2;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(greaterValue));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_value_is_less_than_smaller_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(smallerValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_less_than_same_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(sameValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_less_than_smaller_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(smallerValue).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_less_than_another_float()
        {
            // Act
            Action act = () => Synchronously.Verify(That(float.NaN).IsLessThan(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_can_never_be_less_than_NaN()
        {
            // Act
            Action act = () => Synchronously.Verify(That(3.4F).IsLessThan(float.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_less_than_another_double()
        {
            // Act
            Action act = () => Synchronously.Verify(That(double.NaN).IsLessThan(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_less_than_NaN()
        {
            // Act
            Action act = () => Synchronously.Verify(That(3.4D).IsLessThan(double.NaN));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_numeric_null_value_is_not_less_than_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsLessThan(0));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(5, -1)]
        [InlineData(10, 5)]
        [InlineData(10, -1)]
        public async Task To_test_the_remaining_paths_for_difference_on_int(int subject, int expectation)
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
        public async Task To_test_the_remaining_paths_for_difference_on_long(long subject, long expectation)
        {
            // Arrange
            // Act
            Action act = () => Synchronously.Verify(That(subject).IsLessThan(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
