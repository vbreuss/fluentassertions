using Xunit;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        int? nullableInteger = 1;

        // Act / Assert
        await That(nullableInteger).IsNotNull();
    }
}
