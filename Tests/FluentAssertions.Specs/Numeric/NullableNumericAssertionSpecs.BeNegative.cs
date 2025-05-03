using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class BeNegative
    {
        [Fact]
        public async Task NaN_is_never_a_negative_float()
        {
            // Arrange
            float? value = float.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsNegative());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task NaN_is_never_a_negative_double()
        {
            // Arrange
            double? value = double.NaN;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsNegative());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
