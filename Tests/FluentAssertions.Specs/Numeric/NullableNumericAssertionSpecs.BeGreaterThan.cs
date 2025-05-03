using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeGreaterThan
    {
        [Fact]
        public async Task A_float_can_never_be_greater_than_NaN()
        {
            // Arrange
            float? value = 3.4F;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(float.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_another_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(0));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_greater_than_NaN()
        {
            // Arrange
            double? value = 3.4F;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(double.NaN));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_greater_than_another_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(0));

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
        public async Task To_test_the_null_path_for_difference_on_nullable_int(int? subject, int expectation)
        {
            // Arrange
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsGreaterThan(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_nullable_byte()
        {
            // Arrange
            var value = (byte?)1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_non_null_path_for_difference_on_nullable_byte()
        {
            // Arrange
            var value = (byte?)1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(2));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_nullable_decimal()
        {
            // Arrange
            var value = (decimal?)11.0;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(11M));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_short()
        {
            // Arrange
            var value = (short?)11;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(11));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_nullable_short()
        {
            // Arrange
            var value = (short?)11;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(11));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task To_test_the_null_path_for_difference_on_nullable_ushort()
        {
            // Arrange
            var value = (ushort?)11;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsGreaterThan(11));

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
        public async Task To_test_the_null_path_for_difference_on_nullable_long(long? subject, long expectation)
        {
            // Arrange
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsGreaterThan(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
