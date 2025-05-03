using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Numeric;

public partial class NullableNumericAssertionSpecs
{
    public class HaveValue
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_with_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act / Assert
            await Expect.That(nullableInteger).IsNotNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableInteger).IsNotNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_nullable_numeric_value_without_a_value_to_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableInteger).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveValue
    {
        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_without_a_value_to_not_have_a_value()
        {
            // Arrange
            int? nullableInteger = null;

            // Act / Assert
            await Expect.That(nullableInteger).IsNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_with_a_value_to_not_have_a_value()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableInteger).IsNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_nullable_value_with_unexpected_value_is_found_it_should_throw_with_message()
        {
            // Arrange
            int? nullableInteger = 1;

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableInteger).IsNull().Because($"it was {"not"} expected"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }
    }
}
