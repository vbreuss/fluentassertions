using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_null_object_to_be_null()
        {
            // Arrange
            object someObject = null;

            // Act / Assert
            await Expect.That(someObject).IsNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_non_null_object_to_be_null()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_non_null_object_is_expected_to_be_null_it_should_fail()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class BeNotNull
    {
        [Fact]
        public async Task Should_succeed_when_asserting_non_null_object_not_to_be_null()
        {
            // Arrange
            var someObject = new object();

            // Act / Assert
            await Expect.That(someObject).IsNotNull();
        }

        [Fact]
        public async Task Should_fail_when_asserting_null_object_not_to_be_null()
        {
            // Arrange
            object someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNotNull());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_null_object_not_to_be_null()
        {
            // Arrange
            object someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNotNull().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
