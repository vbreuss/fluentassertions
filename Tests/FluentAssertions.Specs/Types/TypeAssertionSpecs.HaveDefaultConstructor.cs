using System;
using FluentAssertions.Common;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveDefaultConstructor specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveDefaultConstructor
    {
        [Fact]
        public async Task When_asserting_a_type_has_a_default_constructor_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveDefaultConstructor()
                    .Which.Should()
                    .HaveAccessModifier(CSharpAccessModifier.ProtectedInternal);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_default_constructor_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithNoMembers);

            // Act
            Action act = () =>
                type.Should()
                    .HaveDefaultConstructor()
                    .Which.Should()
                    .HaveAccessModifier(CSharpAccessModifier.Public);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_default_constructor_which_it_does_not_and_a_cctor_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithCctor);

            // Act
            type.Should()
                .HaveDefaultConstructor()
                .Which.Should()
                .HaveAccessModifier(CSharpAccessModifier.Public);

            Action act = () =>
                type.Should()
                    .HaveDefaultConstructor()
                    .Which.Should()
                    .HaveAccessModifier(CSharpAccessModifier.Public);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_a_default_constructor_which_it_does_not_and_a_cctor_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithCctorAndNonDefaultConstructor);

            // Act
            Action act = () =>
                type.Should().HaveDefaultConstructor("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected constructor *ClassWithCctorAndNonDefaultConstructor() to exist *failure message*" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_default_constructor_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveDefaultConstructor("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveDefaultConstructor
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_default_constructor_which_it_does_not_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithCctorAndNonDefaultConstructor);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveDefaultConstructor();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_default_constructor_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveDefaultConstructor("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_default_constructor_which_it_does_and_a_cctor_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithCctor);

            // Act
            Action act = () =>
                type.Should().NotHaveDefaultConstructor("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_a_default_constructor_which_it_does_not_and_a_cctor_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithCctorAndNonDefaultConstructor);

            // Act
            Action act = () =>
                type.Should().NotHaveDefaultConstructor();

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_default_constructor_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveDefaultConstructor("we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    internal class ClassWithNoMembers;

    internal class ClassWithCctor;

    internal class ClassWithCctorAndNonDefaultConstructor
    {
        public ClassWithCctorAndNonDefaultConstructor(int _) { }
    }
}
