using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public class NumericDifferenceAssertionsSpecs
{
    public class Be
    {
        [Theory]
        [InlineData(8, 5)]
        [InlineData(1, 9)]
        public async Task The_difference_between_small_ints_is_not_included_in_the_message(int value, int expected)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(50, 20, 30)]
        [InlineData(20, 50, -30)]
        [InlineData(123, -123, 246)]
        [InlineData(-123, 123, -246)]
        public async Task The_difference_between_ints_is_included_in_the_message(int value, int expected, int expectedDifference)
        {
            Func<Task> act = async ()
                => await That(value).IsEqualTo(expected);

            await That(act).Throws<XunitException>().WithMessage($"*{expectedDifference}*").AsWildcard();
        }

        [Theory]
        [InlineData(8, 5)]
        [InlineData(1, 9)]
        public async Task The_difference_between_small_nullable_ints_is_not_included_in_the_message(int? value, int expected)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_int_and_null_is_not_included_in_the_message()
        {
            // Arrange
            int? value = null;
            const int expected = 12;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_null_and_int_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 12;
            int? nullableValue = null;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(nullableValue).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(50, 20, 30)]
        [InlineData(20, 50, -30)]
        [InlineData(123, -123, 246)]
        [InlineData(-123, 123, -246)]
        public async Task The_difference_between_nullable_ints_is_included_in_the_message(int? value, int expected,
            int expectedDifference)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage($"*{expectedDifference}*").AsWildcard();
        }

        [Fact]
        public async Task The_difference_between_nullable_uints_is_included_in_the_message()
        {
            // Arrange
            uint? value = 29;
            const uint expected = 19;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(8, 5)]
        [InlineData(1, 9)]
        public async Task The_difference_between_small_longs_is_not_included_in_the_message(long value, long expected)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(50, 20, 30)]
        [InlineData(20, 50, -30)]
        public async Task The_difference_between_longs_is_included_in_the_message(long value, long expected, long expectedDifference)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage($"*{expectedDifference}*").AsWildcard();
        }

        [Theory]
        [InlineData(8L, 5)]
        [InlineData(1L, 9)]
        public async Task The_difference_between_small_nullable_longs_is_not_included_in_the_message(long? value, long expected)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(50L, 20, 30)]
        [InlineData(20L, 50, -30)]
        public async Task The_difference_between_nullable_longs_is_included_in_the_message(long? value, long expected,
            long expectedDifference)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage($"*{expectedDifference}*").AsWildcard();
        }

        [Theory]
        [InlineData(8, 5)]
        [InlineData(1, 9)]
        public async Task The_difference_between_small_shorts_is_not_included_in_the_message(short value, short expected)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(50, 20, 30)]
        [InlineData(20, 50, -30)]
        public async Task The_difference_between_shorts_is_included_in_the_message(short value, short expected,
            short expectedDifference)
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage($"*{expectedDifference}*").AsWildcard();
        }

        [Fact]
        public async Task The_difference_between_small_nullable_shorts_is_not_included_in_the_message()
        {
            // Arrange
            short? value = 2;
            const short expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_shorts_is_included_in_the_message()
        {
            // Arrange
            short? value = 15;
            const short expected = 2;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_small_ulongs_is_not_included_in_the_message()
        {
            // Arrange
            const ulong value = 9;
            const ulong expected = 4;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ulongs_is_included_in_the_message()
        {
            // Arrange
            const ulong value = 50;
            const ulong expected = 20;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_small_nullable_ulongs_is_not_included_in_the_message()
        {
            // Arrange
            ulong? value = 7;
            const ulong expected = 4;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_ulongs_is_included_in_the_message()
        {
            // Arrange
            ulong? value = 50;
            const ulong expected = 20;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ushorts_is_included_in_the_message()
        {
            // Arrange
            ushort? value = 11;
            const ushort expected = 2;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_doubles_is_included_in_the_message()
        {
            // Arrange
            const double value = 1.5;
            const double expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_doubles_is_included_in_the_message()
        {
            // Arrange
            double? value = 1.5;
            const double expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_floats_is_included_in_the_message()
        {
            // Arrange
            const float value = 1.5F;
            const float expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_floats_is_included_in_the_message()
        {
            // Arrange
            float? value = 1.5F;
            const float expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_decimals_is_included_in_the_message()
        {
            // Arrange
            const decimal value = 1.5m;
            const decimal expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_decimals_is_included_in_the_message()
        {
            // Arrange
            decimal? value = 1.5m;
            const decimal expected = 1;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_sbytes_is_included_in_the_message()
        {
            // Arrange
            const sbyte value = 1;
            const sbyte expected = 3;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_nullable_sbytes_is_included_in_the_message()
        {
            // Arrange
            sbyte? value = 1;
            const sbyte expected = 3;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeLessThan
    {
        [Fact]
        public async Task The_difference_between_equal_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 15;
            const int expected = 15;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsLessThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_small_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 4;
            const int expected = 2;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsLessThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ints_is_included_in_the_message()
        {
            // Arrange
            const int value = 52;
            const int expected = 22;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsLessThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeLessThanOrEqualTo
    {
        [Fact]
        public async Task The_difference_between_small_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 4;
            const int expected = 2;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsLessThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ints_is_included_in_the_message()
        {
            // Arrange
            const int value = 52;
            const int expected = 22;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsLessThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeGreaterThan
    {
        [Fact]
        public async Task The_difference_between_equal_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 15;
            const int expected = 15;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_small_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 2;
            const int expected = 4;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ints_is_included_in_the_message()
        {
            // Arrange
            const int value = 22;
            const int expected = 52;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_nullable_uints_is_not_included_in_the_message()
        {
            // Arrange
            uint? value = 15;
            const uint expected = 15;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_doubles_is_not_included_in_the_message()
        {
            // Arrange
            const double value = 1.3;
            const double expected = 1.3;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_floats_is_not_included_in_the_message()
        {
            // Arrange
            const float value = 2.3F;
            const float expected = 2.3F;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_ushorts_is_not_included_in_the_message()
        {
            // Arrange
            ushort? value = 11;
            const ushort expected = 11;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_sbytes_is_not_included_in_the_message()
        {
            // Arrange
            const sbyte value = 3;
            const sbyte expected = 3;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_equal_nullable_ulongs_is_not_included_in_the_message()
        {
            // Arrange
            ulong? value = 15;
            const ulong expected = 15;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class BeGreaterThanOrEqualTo
    {
        [Fact]
        public async Task The_difference_between_small_ints_is_not_included_in_the_message()
        {
            // Arrange
            const int value = 2;
            const int expected = 4;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_ints_is_included_in_the_message()
        {
            // Arrange
            const int value = 22;
            const int expected = 52;

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsGreaterThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class Overflow
    {
        [Fact]
        public async Task The_difference_between_overflowed_ints_is_included_in_the_message()
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(int.MinValue).IsEqualTo(int.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_nullable_ints_is_included_in_the_message()
        {
            // Arrange
            int? minValue = int.MinValue;

            // Act
            Action act = () =>
Synchronously.Verify(That(minValue).IsEqualTo(int.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_uints_is_included_in_the_message()
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(uint.MinValue).IsEqualTo(uint.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_nullable_uints_is_included_in_the_message()
        {
            // Arrange
            uint? minValue = uint.MinValue;

            // Act
            Action act = () =>
Synchronously.Verify(That(minValue).IsEqualTo(uint.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_longs_is_included_in_the_message()
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(long.MinValue).IsEqualTo(long.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_nullable_longs_is_included_in_the_message()
        {
            // Arrange
            long? minValue = long.MinValue;

            // Act
            Action act = () =>
Synchronously.Verify(That(minValue).IsEqualTo(long.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_ulongs_is_included_in_the_message()
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(ulong.MinValue).IsEqualTo(ulong.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_nullable_ulongs_is_included_in_the_message()
        {
            // Arrange
            ulong? minValue = ulong.MinValue;

            // Act
            Action act = () =>
Synchronously.Verify(That(minValue).IsEqualTo(ulong.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_decimals_is_not_included_in_the_message()
        {
            // Act
            Action act = () =>
Synchronously.Verify(That(decimal.MinValue).IsEqualTo(decimal.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_difference_between_overflowed_nullable_decimals_is_not_included_in_the_message()
        {
            // Arrange
            decimal? minValue = decimal.MinValue;

            // Act
            Action act = () =>
Synchronously.Verify(That(minValue).IsEqualTo(decimal.MaxValue));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
