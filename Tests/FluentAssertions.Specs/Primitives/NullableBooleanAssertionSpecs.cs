using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
public class NullableBooleanAssertionSpecs
{
    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_have_a_value_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act / Assert
        await Expect.That(nullableBoolean).IsNotNull();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_not_be_null_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act / Assert
        await Expect.That(nullableBoolean).IsNotNull();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_have_a_value_it_should_fail()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_not_be_null_it_should_fail()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_have_a_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_not_be_null_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_not_have_a_value_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act / Assert
        await Expect.That(nullableBoolean).IsNull();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_without_a_value_to_be_null_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act / Assert
        await Expect.That(nullableBoolean).IsNull();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_not_have_a_value_it_should_fail()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_be_null_it_should_fail()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_be_not_have_a_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_nullable_boolean_value_with_a_value_to_be_null_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_is_false_it_should_fail()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsFalse().Because($"we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_is_true_it_sShould_fail()
    {
        // Arrange
        bool? nullableBoolean = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsTrue().Because($"we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_to_be_equal_to_different_nullable_boolean_should_fail()
    {
        // Arrange
        bool? nullableBoolean = null;
        bool? differentNullableBoolean = false;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsEqualTo(differentNullableBoolean).Because($"we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_not_to_be_equal_to_same_value_should_fail()
    {
        // Arrange
        bool? nullableBoolean = null;
        bool? differentNullableBoolean = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotEqualTo(differentNullableBoolean).Because($"we want to test the failure {"message"}"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_to_be_equal_to_null_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = null;
        bool? otherNullableBoolean = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsEqualTo(otherNullableBoolean));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_boolean_null_value_not_to_be_equal_to_different_value_it_should_succeed()
    {
        // Arrange
        bool? nullableBoolean = true;
        bool? otherNullableBoolean = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableBoolean).IsNotEqualTo(otherNullableBoolean));

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_true_is_not_false_it_should_succeed()
    {
        // Arrange
        bool? trueBoolean = true;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(trueBoolean).IsNotFalse());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_null_is_not_false_it_should_succeed()
    {
        // Arrange
        bool? nullValue = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullValue).IsNotFalse());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_false_is_not_false_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? falseBoolean = false;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(falseBoolean).IsNotFalse().Because("we want to test the failure message"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_false_is_not_true_it_should_succeed()
    {
        // Arrange
        bool? trueBoolean = false;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(trueBoolean).IsNotTrue());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_null_is_not_true_it_should_succeed()
    {
        // Arrange
        bool? nullValue = null;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullValue).IsNotTrue());

        // Assert
        await Expect.That(action).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_true_is_not_true_it_should_fail_with_descriptive_message()
    {
        // Arrange
        bool? falseBoolean = true;

        // Act
        Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(falseBoolean).IsNotTrue().Because("we want to test the failure message"));

        // Assert
        await Expect.That(action).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        bool? nullableBoolean = true;

        // Act / Assert
        await Expect.That(nullableBoolean).IsNotNull();
    }
}
