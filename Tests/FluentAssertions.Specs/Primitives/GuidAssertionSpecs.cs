using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public class GuidAssertionSpecs
{
    public class BeEmpty
    {
        [Fact]
        public async Task Should_succeed_when_asserting_empty_guid_is_empty()
        {
            // Arrange
            Guid guid = Guid.Empty;

            // Act / Assert
            await That(guid).IsEmpty();
        }

        [Fact]
        public async Task Should_fail_when_asserting_non_empty_guid_is_empty()
        {
            // Arrange
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsEmpty().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeEmpty
    {
        [Fact]
        public async Task Should_succeed_when_asserting_non_empty_guid_is_not_empty()
        {
            // Arrange
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsNotEmpty());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_empty_guid_is_not_empty()
        {
            // Act
            Action act = () => Synchronously.Verify(That(Guid.Empty).IsNotEmpty().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_guid_equals_the_same_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var sameGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsEqualTo(sameGuid));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_guid_equals_the_same_guid_in_string_format()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsEqualTo(Guid.Parse("11111111-aaaa-bbbb-cccc-999999999999")));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_guid_equals_a_different_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var differentGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsEqualTo(differentGuid).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "TODO VAB")]
        public async Task Should_throw_when_asserting_guid_equals_a_string_that_is_not_a_valid_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsEqualTo(Guid.Parse(string.Empty)).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task Should_succeed_when_asserting_guid_does_not_equal_a_different_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var differentGuid = new Guid("55555555-ffff-eeee-dddd-444444444444");

            // Act
            Action act = () =>
Synchronously.Verify(That(guid).IsNotEqualTo(differentGuid));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_guid_does_not_equal_the_same_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");
            var sameGuid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsNotEqualTo(sameGuid).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "TODO VAB")]
        public async Task Should_throw_when_asserting_guid_does_not_equal_a_string_that_is_not_a_valid_guid()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () => Synchronously.Verify(That(guid).IsNotEqualTo(Guid.Parse(string.Empty)).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_guid_does_not_equal_a_different_guid_in_string_format()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () =>
Synchronously.Verify(That(guid).IsNotEqualTo(Guid.Parse("55555555-ffff-eeee-dddd-444444444444")));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_guid_does_not_equal_the_same_guid_in_string_format()
        {
            // Arrange
            var guid = new Guid("11111111-aaaa-bbbb-cccc-999999999999");

            // Act
            Action act = () =>
Synchronously.Verify(That(guid).IsNotEqualTo(Guid.Parse("11111111-aaaa-bbbb-cccc-999999999999")).Because($"we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class ChainingConstraint
    {
        [Fact]
        public async Task Should_support_chaining_constraints_with_and()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act / Assert
            await That(guid).IsNotEmpty();
        }
    }

    public class Miscellaneous
    {
        [Fact]
        public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            Guid subject = Guid.Empty;

            // Act
            Action action = () => subject.Should().Equals(subject);

            // Assert
            await That(action).Throws<NotSupportedException>();
        }
    }
}
