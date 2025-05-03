using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeGreaterThan
    {
        [Fact]
        public async Task When_a_value_is_greater_than_smaller_value_it_should_not_throw()
        {
            // Arrange
            int value = 2;
            int smallerValue = 1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(smallerValue));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_greater_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(greaterValue));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_same_value_it_should_throw()
        {
            // Arrange
            int value = 2;
            int sameValue = 2;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(sameValue));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_greater_than_greater_value_it_should_throw_with_descriptive_message()
        {
            // Arrange
            int value = 2;
            int greaterValue = 3;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(greaterValue).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_another_float()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(float.NaN).IsGreaterThan(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_cannot_be_greater_than_NaN()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(3.4F).IsGreaterThan(float.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_another_double()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(double.NaN).IsGreaterThan(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_greater_than_NaN()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(3.4D).IsGreaterThan(double.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_numeric_null_value_is_not_greater_than_it_should_throw()
        {
            // Arrange
            int? value = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_byte()
        {
            // Arrange
            var value = (byte)1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_non_null_path_for_difference_on_byte()
        {
            // Arrange
            var value = (byte)1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(2));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(1, 10)]
        [InlineData(0, 5)]
        [InlineData(0, 0)]
        [InlineData(-1, 5)]
        [InlineData(-1, -1)]
        [InlineData(10, 10)]
        public async Task To_test_the_null_path_for_difference_on_int(int subject, int expectation)
        {
            // Arrange
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsGreaterThan(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(5L, 5L)]
        [InlineData(1L, 10L)]
        [InlineData(0L, 5L)]
        [InlineData(0L, 0L)]
        [InlineData(-1L, 5L)]
        [InlineData(-1L, -1L)]
        [InlineData(10L, 10L)]
        public async Task To_test_the_null_path_for_difference_on_long(long subject, long expectation)
        {
            // Arrange
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsGreaterThan(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(10, 11)]
        public async Task To_test_the_null_path_for_difference_on_ushort(ushort subject, ushort expectation)
        {
            // Arrange
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsGreaterThan(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
