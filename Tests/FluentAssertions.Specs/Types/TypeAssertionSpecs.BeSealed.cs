using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]BeSealed specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class BeSealed
    {
        [Fact]
        public void When_type_is_sealed_it_succeeds()
        {
            // Arrange / Act / Assert
            typeof(Sealed).Should().BeSealed();
        }

        [Theory]
        [InlineData(typeof(ClassWithoutMembers), "Expected type *.ClassWithoutMembers to be sealed.")]
        [InlineData(typeof(Abstract), "Expected type *.Abstract to be sealed.")]
        [InlineData(typeof(Static), "Expected type *.Static to be sealed.")]
        public async Task When_type_is_not_sealed_it_fails(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().BeSealed();

            // Assert
            await That(act).Throws<XunitException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_type_is_not_sealed_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var type = typeof(ClassWithoutMembers);

            // Act
            Action act = () => type.Should().BeSealed("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(typeof(IDummyInterface), "*.IDummyInterface must be a class.")]
        [InlineData(typeof(Struct), "*.Struct must be a class.")]
        [InlineData(typeof(ExampleDelegate), "*.ExampleDelegate must be a class.")]
        public async Task When_type_is_not_valid_for_BeSealed_it_throws_exception(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().BeSealed();

            // Assert
            await That(act).Throws<InvalidOperationException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_be_sealed_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().BeSealed("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeSealed
    {
        [Theory]
        [InlineData(typeof(ClassWithoutMembers))]
        [InlineData(typeof(Abstract))]
        [InlineData(typeof(Static))]
        public void When_type_is_not_sealed_it_succeeds(Type type)
        {
            // Arrange / Act / Assert
            type.Should().NotBeSealed();
        }

        [Fact]
        public async Task When_type_is_sealed_it_fails()
        {
            // Arrange
            var type = typeof(Sealed);

            // Act
            Action act = () => type.Should().NotBeSealed();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_sealed_it_fails_with_a_meaningful_message()
        {
            // Arrange
            var type = typeof(Sealed);

            // Act
            Action act = () => type.Should().NotBeSealed("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Theory]
        [InlineData(typeof(IDummyInterface), "*.IDummyInterface must be a class.")]
        [InlineData(typeof(Struct), "*.Struct must be a class.")]
        [InlineData(typeof(ExampleDelegate), "*.ExampleDelegate must be a class.")]
        public async Task When_type_is_not_valid_for_NotBeSealed_it_throws_exception(Type type, string exceptionMessage)
        {
            // Act
            Action act = () => type.Should().NotBeSealed();

            // Assert
            await That(act).Throws<InvalidOperationException>().WithMessage(exceptionMessage).AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_be_sealed_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotBeSealed("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
