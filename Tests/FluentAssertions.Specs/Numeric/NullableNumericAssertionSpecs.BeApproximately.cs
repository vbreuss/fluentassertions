using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeApproximately
    {
        [Fact]
        public async Task When_approximating_a_nullable_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14).Within(-0.1));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_approximating_two_nullable_doubles_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.14;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(-0.1));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_nullable_double_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_double_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.142;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_double_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            double? value = null;
            double? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_double_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = 13;
            double? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_double_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = null;
            double? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_double_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            double? value = 12;
            double? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_double_has_no_value_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(value).IsEqualTo(3.14).Within(0.001);
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_double_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(1.0).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_cannot_approximate_NaN()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.NaN).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_a_nullable_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(-0.1F));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_approximating_two_nullable_floats_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.14F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(-0.1F));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_nullable_float_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.1F));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_float_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927f;
            float? expected = 3.142f;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1f));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_float_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            float? value = null;
            float? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1f));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_float_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = 13;
            float? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1f));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_float_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = null;
            float? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1f));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_float_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            float? value = 12;
            float? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1f));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(value).IsEqualTo(3.14F).Within(0.001F);
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_float_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(1.0F).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_cannot_approximate_NaN()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.NaN).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_a_nullable_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14m).Within(-0.1m));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_approximating_two_nullable_decimals_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.14m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(-0.1m));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_nullable_decimal_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14m).Within(0.1m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_decimal_is_indeed_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.142m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_decimal_is_null_approximating_a_nullable_null_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_nullable_decimal_with_value_is_not_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = 13;
            decimal? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1m));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_decimal_is_null_approximating_a_non_null_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = 12;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1m));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_decimal_is_not_null_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            decimal? value = 12;
            decimal? expected = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(expected).Within(0.1m));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_decimal_has_no_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act

            Func<Task> act = async () =>
            {
                await That(value).IsEqualTo(3.14m).Within(0.001m);
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_decimal_is_not_approximating_a_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(1.0m).Within(0.1m));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeApproximately
    {
        [Fact]
        public async Task When_not_approximating_a_nullable_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, -0.1);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_not_approximating_two_nullable_doubles_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.14;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_has_no_value_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 1.0;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_double_is_not_approximating_a_nullable_double_value_it_should_throw()
        {
            // Arrange
            double? value = null;
            double? expected = 20.0;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_double_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            double? value = null;
            double? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_double_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            double? value = 3.1415927;
            double? expected = 3.1;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_cannot_approximate_NaN()
        {
            // Arrange
            double? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NaN, 0.1);

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_not_approximating_a_nullable_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, -0.1F);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_not_approximating_two_nullable_floats_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.14F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1F);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0F, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 1.0F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_float_is_not_approximating_a_nullable_float_value_it_should_throw()
        {
            // Arrange
            float? value = null;
            float? expected = 20.0f;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_float_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            float? value = null;
            float? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).Throws<XunitException>().Because("Expected*<null>*+/-*0.1F*<null>*");
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_float_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            float? value = 3.1415927F;
            float? expected = 3.1F;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_cannot_approximate_NaN()
        {
            // Arrange
            float? value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NaN, 0.1F);

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_not_approximating_a_nullable_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, -0.1m);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_not_approximating_two_nullable_decimals_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.14m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, -0.1m);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(1.0m, 0.1m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_has_no_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, 0.001m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_is_indeed_approximating_a_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, 0.1m);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_nullable_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 1.0m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_is_not_approximating_a_null_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_decimal_is_not_approximating_a_nullable_decimal_value_it_should_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = 20.0m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_null_decimal_is_not_approximating_a_null_value_it_should_not_throw()
        {
            // Arrange
            decimal? value = null;
            decimal? expected = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_not_approximately_and_nullable_decimal_is_approximating_a_nullable_value_it_should_throw()
        {
            // Arrange
            decimal? value = 3.1415927m;
            decimal? expected = 3.1m;

            // Act
            Action act = () => value.Should().NotBeApproximately(expected, 0.1m);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
