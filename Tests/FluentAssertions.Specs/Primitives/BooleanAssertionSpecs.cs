using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
public class BooleanAssertionSpecs
{
    public class BeTrue
    {
        [Fact]
        public async Task Should_succeed_when_asserting_boolean_value_true_is_true()
        {
            // Arrange
            bool boolean = true;

            // Act / Assert
            await That(boolean).IsTrue();
        }

        [Fact]
        public async Task Should_fail_when_asserting_boolean_value_false_is_true()
        {
            // Arrange
            bool boolean = false;

            // Act
            Action action = () => Synchronously.Verify(That(boolean).IsTrue());

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_boolean_value_false_is_true()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(false).IsTrue().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class BeFalse
    {
        [Fact]
        public async Task Should_succeed_when_asserting_boolean_value_false_is_false()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(false).IsFalse());

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_boolean_value_true_is_false()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(true).IsFalse());

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_boolean_value_true_is_false()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(true).IsFalse().Because($"we want to test the failure {"message"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_boolean_value_to_be_equal_to_the_same_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(false).IsEqualTo(false));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_boolean_value_to_be_equal_to_a_different_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(false).IsEqualTo(true));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_boolean_value_to_be_equal_to_a_different_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(false).IsEqualTo(true).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task Should_succeed_when_asserting_boolean_value_not_to_be_equal_to_the_same_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(true).IsNotEqualTo(false));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_boolean_value_not_to_be_equal_to_a_different_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(true).IsNotEqualTo(true));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_boolean_value_not_to_be_equal_to_a_different_value()
        {
            // Act
            Action action = () =>
Synchronously.Verify(That(true).IsNotEqualTo(true).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class Imply
    {
        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, true)]
        public async Task Antecedent_implies_consequent(bool? antecedent, bool consequent)
        {
            // Act / Assert
            await That(antecedent).Implies(consequent);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData(null, false)]
        [InlineData(true, false)]
        public async Task Antecedent_does_not_imply_consequent(bool? antecedent, bool consequent)
        {
            // Act
            Action act = () => Synchronously.Verify(That(antecedent).Implies(consequent).Because($"because we want to test the {"failure"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
