using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NumericAssertionSpecs
{
    public class BeApproximately
    {
        [Fact]
        public async Task When_approximating_a_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(-0.1F));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_float_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.001F).Because("rockets will crash otherwise"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_float_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.1F));

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public async Task When_float_is_approximating_a_value_on_boundaries_it_should_not_throw(float value)
        {
            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10F).Within(1F));

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public async Task When_float_is_not_approximating_a_value_on_boundaries_it_should_throw(float value)
        {
            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10F).Within(0.9F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_a_float_towards_nan_it_should_not_throw()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_positive_infinity_float_towards_positive_infinity_it_should_not_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.PositiveInfinity).Within(0.1F));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_negative_infinity_float_towards_negative_infinity_it_should_not_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.NegativeInfinity).Within(0.1F));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_float_is_not_approximating_positive_infinity_it_should_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.MaxValue).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_float_is_not_approximating_negative_infinity_it_should_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.MinValue).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_never_be_close_to_any_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.MinValue).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_can_never_be_close_to_NaN()
        {
            // Arrange
            float value = float.MinValue;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(float.NaN).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_float_has_no_value_it_should_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.001F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_a_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14).Within(-0.1));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_double_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14).Within(0.001).Because("rockets will crash otherwise"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_double_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_a_double_towards_nan_it_should_not_throw()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14F).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_positive_infinity_double_towards_positive_infinity_it_should_not_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.PositiveInfinity).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_negative_infinity_double_towards_negative_infinity_it_should_not_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.NegativeInfinity).Within(0.1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_double_is_not_approximating_positive_infinity_it_should_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.MaxValue).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_double_is_not_approximating_negative_infinity_it_should_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.MinValue).Within(0.1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public async Task When_double_is_approximating_a_value_on_boundaries_it_should_not_throw(double value)
        {
            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10D).Within(1D));

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public async Task When_double_is_not_approximating_a_value_on_boundaries_it_should_throw(double value)
        {
            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10D).Within(0.9D));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_never_be_close_to_any_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.MinValue).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_close_to_NaN()
        {
            // Arrange
            double value = double.MinValue;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(double.NaN).Within(0.1F));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_approximating_a_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal value = 3.1415927M;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.14m).Within(-0.1m));

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_range_it_should_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.5m).Within(0.001m).Because("rockets will crash otherwise"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_decimal_is_indeed_approximating_a_value_it_should_not_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(3.5m).Within(0.01m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_approximating_a_value_on_lower_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10m).Within(1m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_approximating_a_value_on_upper_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10m).Within(1m));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_value_on_lower_boundary_it_should_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10m).Within(0.9m));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_value_on_upper_boundary_it_should_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => Synchronously.Verify(That(value).IsEqualTo(10m).Within(0.9m));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeApproximately
    {
        [Fact]
        public async Task When_not_approximating_a_float_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, -0.1F);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_float_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F, "rockets will crash otherwise");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_float_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = 3.1415927F;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_a_float_towards_nan_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_not_approximating_a_float_towards_positive_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MaxValue, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_not_approximating_a_float_towards_negative_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MinValue, 0.1F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_positive_infinity_float_towards_positive_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.PositiveInfinity, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_not_approximating_negative_infinity_float_towards_negative_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            float value = float.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NegativeInfinity, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public async Task When_float_is_not_approximating_a_value_on_boundaries_it_should_not_throw(float value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10F, 0.9F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9F)]
        [InlineData(11F)]
        [Theory]
        public async Task When_float_is_approximating_a_value_on_boundaries_it_should_throw(float value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10F, 1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_float_has_no_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            float? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14F, 0.001F);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task NaN_can_never_be_close_to_any_float()
        {
            // Arrange
            float value = float.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.MinValue, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_float_can_never_be_close_to_NaN()
        {
            // Arrange
            float value = float.MinValue;

            // Act
            Action act = () => value.Should().NotBeApproximately(float.NaN, 0.1F);

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_not_approximating_a_double_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, -0.1);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_double_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1, "rockets will crash otherwise");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_double_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = 3.1415927;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_a_double_towards_nan_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.1);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_not_approximating_a_double_towards_positive_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MaxValue, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_not_approximating_a_double_towards_negative_infinity_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MinValue, 0.1);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_approximating_positive_infinity_double_towards_positive_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.PositiveInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.PositiveInfinity, 0.1);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_not_approximating_negative_infinity_double_towards_negative_infinity_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double value = double.NegativeInfinity;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NegativeInfinity, 0.1);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_nullable_double_has_no_value_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            double? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14, 0.001);

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public async Task When_double_is_not_approximating_a_value_on_boundaries_it_should_not_throw(double value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10D, 0.9D);

            // Assert
            await That(act).DoesNotThrow();
        }

        [InlineData(9D)]
        [InlineData(11D)]
        [Theory]
        public async Task When_double_is_approximating_a_value_on_boundaries_it_should_throw(double value)
        {
            // Act
            Action act = () => value.Should().NotBeApproximately(10D, 1D);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_can_never_be_close_to_any_double()
        {
            // Arrange
            double value = double.NaN;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.MinValue, 0.1F);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_double_can_never_be_close_to_NaN()
        {
            // Arrange
            double value = double.MinValue;

            // Act
            Action act = () => value.Should().NotBeApproximately(double.NaN, 0.1F);

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_not_approximating_a_decimal_with_a_negative_precision_it_should_throw()
        {
            // Arrange
            decimal value = 3.1415927m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.14m, -0.1m);

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_decimal_is_approximating_a_range_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.1m, "rockets will crash otherwise");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_value_and_should_not_approximate_it_should_not_throw()
        {
            // Arrange
            decimal value = 3.5011m;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.001m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_nullable_decimal_has_no_value_and_should_not_approximate_it_should_throw()
        {
            // Arrange
            decimal? value = null;

            // Act
            Action act = () => value.Should().NotBeApproximately(3.5m, 0.001m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_value_on_lower_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 0.9m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_not_approximating_a_value_on_upper_boundary_it_should_not_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 0.9m);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_decimal_is_approximating_a_value_on_lower_boundary_it_should_throw()
        {
            // Act
            decimal value = 9m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 1m);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_decimal_is_approximating_a_value_on_upper_boundary_it_should_throw()
        {
            // Act
            decimal value = 11m;

            // Act
            Action act = () => value.Should().NotBeApproximately(10m, 1m);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
