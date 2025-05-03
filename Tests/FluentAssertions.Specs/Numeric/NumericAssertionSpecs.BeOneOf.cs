using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            int value = 3;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(4, 5));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 3;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(4, 5).Because("because those are the valid values"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            int value = 4;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(4, 5));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_nullable_numeric_null_value_is_not_one_of_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(0, 1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Two_floats_that_are_NaN_can_be_compared()
        {
            // Arrange
            float value = float.NaN;

            // Act / Assert
            await Expect.That(value).IsOneOf(float.NaN, 4.5F);
        }

        [Fact]
        public async Task Floats_are_never_equal_to_NaN()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(1.5F, 4.5F));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Two_doubles_that_are_NaN_can_be_compared()
        {
            // Arrange
            double value = double.NaN;

            // Act / Assert
            await Expect.That(value).IsOneOf(double.NaN, 4.5F);
        }

        [Fact]
        public async Task Doubles_are_never_equal_to_NaN()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(1.5D, 4.5D));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
