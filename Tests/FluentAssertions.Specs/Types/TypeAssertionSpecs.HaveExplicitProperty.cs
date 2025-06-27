using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]HaveExplicitProperty specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class HaveExplicitProperty
    {
        [Fact]
        public async Task When_asserting_a_type_explicitly_implements_a_property_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty(interfaceType, "ExplicitStringProperty");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_explicitly_implements_a_property_which_it_implements_implicitly_and_explicitly_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty(interfaceType, "ExplicitImplicitStringProperty");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_explicitly_implements_a_property_which_it_implements_implicitly_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty(interfaceType, "ImplicitStringProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected *.ClassExplicitlyImplementingInterface to explicitly implement " +
                    "*.IExplicitInterface.ImplicitStringProperty, but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_explicitly_implements_a_property_which_it_does_not_implement_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty(interfaceType, "NonExistentProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected *.ClassExplicitlyImplementingInterface to explicitly implement " +
                    "*.IExplicitInterface.NonExistentProperty, but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_explicitly_implements_a_property_from_an_unimplemented_interface_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IDummyInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty(interfaceType, "NonExistentProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type *.ClassExplicitlyImplementingInterface to implement interface *.IDummyInterface" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_have_explicit_property_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty(
                    typeof(IExplicitInterface), "ExplicitStringProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to explicitly implement *.IExplicitInterface.ExplicitStringProperty *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_property_inherited_by_null_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty(null, "ExplicitStringProperty");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty(typeof(IExplicitInterface), null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicit_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty(typeof(IExplicitInterface), string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task Does_not_continue_assertion_on_explicit_interface_implementation_if_not_implemented_at_all()
        {
            var act = () =>
            {
                using var _ = new AssertionScope();
                typeof(int).Should().HaveExplicitProperty(typeof(IExplicitInterface), "Foo");
            };

            await That(act).Throws<XunitException>();
        }
    }

    public class HaveExplicitPropertyOfT
    {
        [Fact]
        public async Task When_asserting_a_type_explicitlyOfT_implements_a_property_which_it_does_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should()
                    .HaveExplicitProperty<IExplicitInterface>("ExplicitStringProperty");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicitlyOfT_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty<IExplicitInterface>(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_has_an_explicitlyOfT_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty<IExplicitInterface>(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_subject_is_null_have_explicit_propertyOfT_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().HaveExplicitProperty<IExplicitInterface>(
                    "ExplicitStringProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to explicitly implement *.IExplicitInterface.ExplicitStringProperty *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }
    }

    public class NotHaveExplicitProperty
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_explicitly_implement_a_property_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty(interfaceType, "ExplicitStringProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected *.ClassExplicitlyImplementingInterface to not explicitly implement " +
                    "*.IExplicitInterface.ExplicitStringProperty, but it does.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_explicitly_implement_a_property_which_it_implements_implicitly_and_explicitly_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty(interfaceType, "ExplicitImplicitStringProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected *.ClassExplicitlyImplementingInterface to not explicitly implement " +
                    "*.IExplicitInterface.ExplicitImplicitStringProperty, but it does.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_explicitly_implement_a_property_which_it_implements_implicitly_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty(interfaceType, "ImplicitStringProperty");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_explicitly_implement_a_property_which_it_does_not_implement_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IExplicitInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty(interfaceType, "NonExistentProperty");

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_explicitly_implement_a_property_from_an_unimplemented_interface_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            var interfaceType = typeof(IDummyInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty(interfaceType, "NonExistentProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type *.ClassExplicitlyImplementingInterface to implement interface *.IDummyInterface" +
                    ", but it does not.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_explicit_property_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty(
                    typeof(IExplicitInterface), "ExplicitStringProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to not explicitly implement *IExplicitInterface.ExplicitStringProperty *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_property_inherited_from_null_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty(null, "ExplicitStringProperty");

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty(typeof(IExplicitInterface), null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicit_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty(typeof(IExplicitInterface), string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect.Reflection/issues/28")]
        public async Task Does_not_continue_assertion_on_explicit_interface_implementation_if_implemented()
        {
            var act = () =>
            {
                using var _ = new AssertionScope();
                typeof(ClassExplicitlyImplementingInterface)
                    .Should().NotHaveExplicitProperty(typeof(IExplicitInterface), "ExplicitStringProperty");
            };

            await That(act).Throws<XunitException>().WithMessage("Expected *ClassExplicitlyImplementingInterface* to*implement " +
                    "*IExplicitInterface.ExplicitStringProperty, but it does.").AsWildcard();
        }
    }

    public class NotHaveExplicitPropertyOfT
    {
        [Fact]
        public async Task When_asserting_a_type_does_not_explicitlyOfT_implement_a_property_which_it_does_it_fails()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should()
                    .NotHaveExplicitProperty<IExplicitInterface>("ExplicitStringProperty");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected *.ClassExplicitlyImplementingInterface to not explicitly implement " +
                    "*.IExplicitInterface.ExplicitStringProperty, but it does.").AsWildcard();
        }

        [Fact]
        public async Task When_subject_is_null_not_have_explicit_propertyOfT_should_fail()
        {
            // Arrange
            Type type = null;

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty<IExplicitInterface>(
                    "ExplicitStringProperty", "we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to not explicitly implement *.IExplicitInterface.ExplicitStringProperty *failure message*" +
                    ", but type is <null>.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicitlyOfT_property_with_a_null_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty<IExplicitInterface>(null);

            // Assert
            await That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_a_type_does_not_have_an_explicitlyOfT_property_with_an_empty_name_it_should_throw()
        {
            // Arrange
            var type = typeof(ClassExplicitlyImplementingInterface);

            // Act
            Action act = () =>
                type.Should().NotHaveExplicitProperty<IExplicitInterface>(string.Empty);

            // Assert
            await That(act).ThrowsExactly<ArgumentException>();
        }
    }
}
