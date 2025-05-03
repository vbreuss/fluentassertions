using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BePositive
    {
        [Fact]
        public async Task NaN_is_never_a_positive_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsPositive());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_a_positive_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsPositive());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
