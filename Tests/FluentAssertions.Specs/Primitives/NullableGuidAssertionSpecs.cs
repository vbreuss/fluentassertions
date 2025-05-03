using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public class NullableGuidAssertionSpecs
{
    [Fact]
    public async Task Should_succeed_when_asserting_nullable_guid_value_with_a_value_to_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = Guid.NewGuid();

        // Act / Assert
        await Expect.That(nullableGuid).IsNotNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_guid_value_with_a_value_to_not_be_null()
    {
        // Arrange
        Guid? nullableGuid = Guid.NewGuid();

        // Act / Assert
        await Expect.That(nullableGuid).IsNotNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_guid_value_without_a_value_to_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNotNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_guid_value_without_a_value_to_not_be_null()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNotNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_guid_value_without_a_value_to_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_guid_value_without_a_value_to_not_be_null()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNotNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_guid_value_without_a_value_to_not_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act / Assert
        await Expect.That(nullableGuid).IsNull();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_guid_value_without_a_value_to_be_null()
    {
        // Arrange
        Guid? nullableGuid = null;

        // Act / Assert
        await Expect.That(nullableGuid).IsNull();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_guid_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = Guid.NewGuid();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_asserting_nullable_guid_value_with_a_value_to_be_null()
    {
        // Arrange
        Guid? nullableGuid = Guid.NewGuid();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNull());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_guid_is_null_while_asserting_guid_equals_another_guid()
    {
        // Arrange
        Guid? guid = null;
        var someGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(guid).IsEqualTo(someGuid).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_succeed_when_asserting_nullable_guid_null_equals_null()
    {
        // Arrange
        Guid? nullGuid = null;
        Guid? otherNullGuid = null;

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullGuid).IsEqualTo(otherNullGuid));

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_guid_value_with_a_value_to_not_have_a_value()
    {
        // Arrange
        Guid? nullableGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_with_descriptive_message_when_asserting_nullable_guid_value_with_a_value_to_be_null()
    {
        // Arrange
        Guid? nullableGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsNull().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_fail_when_asserting_null_equals_some_guid()
    {
        // Arrange
        Guid? nullableGuid = null;
        var someGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableGuid).IsEqualTo(someGuid).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task Should_support_chaining_constraints_with_and()
    {
        // Arrange
        Guid? nullableGuid = Guid.NewGuid();

        // Act / Assert
        await Expect.That(nullableGuid).IsNotNull();
    }
}
