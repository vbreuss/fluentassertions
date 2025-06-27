using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveProperty specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveProperty
    {
        [Fact]
        public async Task When_asserting_a_type_has_a_property_which_it_does_then_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveProperty(typeof(string), "PrivateWriteProtectedReadProperty")
                    .Which.Should()
                    .BeWritable(CSharpAccessModifier.Private)
                    .And.BeReadable(CSharpAccessModifier.Protected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task The_name_of_the_property_is_passed_to_the_chained_assertion()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () => type
                .Should().HaveProperty(typeof(string), "PrivateWriteProtectedReadProperty")
                .Which.Should().NotBeWritable();

            // Assert
            await That(act).Throws<XunitException>().Because("Expected property PrivateWriteProtectedReadProperty not to have a setter.");
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_property_which_it_does_not_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithNoMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty(typeof(string), "PublicProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_property_which_it_has_with_a_different_type_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveProperty(typeof(int), "PrivateWriteProtectedReadProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected property PrivateWriteProtectedReadProperty " +
                    "to be of type System.Int32 because we want to test the failure message, but it is not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_property_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveProperty(typeof(string), "PublicProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_property_of_null_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty(null, "PublicProperty");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty(typeof(string), null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty(typeof(string), string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class HavePropertyOfT
    {
        [Fact]
        public async Task When_asserting_a_type_has_a_propertyOfT_which_it_does_then_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveProperty<string>("PrivateWriteProtectedReadProperty")
                    .Which.Should()
                    .BeWritable(CSharpAccessModifier.Private)
                    .And.BeReadable(CSharpAccessModifier.Protected);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_propertyOfT_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty<string>(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_propertyOfT_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().HaveProperty<string>(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }

    public class NotHaveProperty
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_property_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithoutMembers);

            // Act
            Action act = () => type.Should().NotHaveProperty("Property");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_property_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveProperty("PrivateWriteProtectedReadProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_property_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveProperty("PublicProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveProperty(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotHaveProperty(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }
}
