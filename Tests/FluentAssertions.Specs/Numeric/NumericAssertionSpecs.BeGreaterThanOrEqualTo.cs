using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public async Task When_a_value_is_greater_than_or_equal_to_smaller_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThanOrEqualTo(smallerValue));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_or_equal_to_same_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThanOrEqualTo(sameValue));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_or_equal_to_greater_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThanOrEqualTo(greaterValue));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_or_equal_to_greater_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThanOrEqualTo(greaterValue).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_numeric_null_value_is_not_greater_than_or_equal_to_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThanOrEqualTo(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_or_equal_to_another_float()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(float.NaN).IsGreaterThanOrEqualTo(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_cannot_be_greater_than_or_equal_to_NaN()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(3.4F).IsGreaterThanOrEqualTo(float.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_or_equal_to_another_double()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(double.NaN).IsGreaterThanOrEqualTo(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_greater_or_equal_to_NaN()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(3.4D).IsGreaterThanOrEqualTo(double.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Chaining_after_one_assertion()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act / Assert
            await Expect.That(value).IsGreaterThanOrEqualTo(smallerValue);
        }
    }
}
