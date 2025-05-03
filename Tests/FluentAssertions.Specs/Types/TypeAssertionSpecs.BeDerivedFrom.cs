using System;
using FluentAssertions.Specs.Primitives;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]BeDerivedFrom specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class BeDerivedFrom
    {
        [Fact]
        public async Task When_asserting_a_type_is_derived_from_its_base_class_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(DummyBaseClass));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_is_derived_from_an_unrelated_class_it_fails()
        {
            // Arrange
            var type = typeof(DummyBaseClass);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(ClassWithMembers), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_is_derived_from_an_interface_it_fails()
        {
            // Arrange
            var type = typeof(ClassThatImplementsInterface);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(IDummyInterface), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassThatImplementsInterface to be derived from *.IDummyInterface *failure message*" +
                    ", but *.IDummyInterface is an interface.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_is_derived_from_an_open_generic_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyBaseType<ClassWithGenericBaseType>);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(DummyBaseType<>));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_is_derived_from_an_open_generic_base_class_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithGenericBaseType);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(DummyBaseType<>));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_is_derived_from_an_unrelated_open_generic_class_it_fails()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom(typeof(DummyBaseType<>), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_a_type_to_be_derived_from_null_it_should_throw()
        {
            // Arrange
            var type = typeof(DummyBaseType<>);

            // Act
            Action act =
                () => type.Should().BeDerivedFrom(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class BeDerivedFromOfT
    {
        [Fact]
        public async Task When_asserting_a_type_is_DerivedFromOfT_its_base_class_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
                type.Should().BeDerivedFrom<DummyBaseClass>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }

    public class NotBeDerivedFrom
    {
        [Fact]
        public async Task When_asserting_a_type_is_not_derived_from_an_unrelated_class_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyBaseClass);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(ClassWithMembers));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_is_not_derived_from_its_base_class_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(DummyBaseClass), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.DummyImplementingClass not to be derived from *.DummyBaseClass *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_is_not_derived_from_an_interface_it_fails()
        {
            // Arrange
            var type = typeof(ClassThatImplementsInterface);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(IDummyInterface), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassThatImplementsInterface not to be derived from *.IDummyInterface *failure message*" +
                    ", but *.IDummyInterface is an interface.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_is_not_derived_from_an_unrelated_open_generic_it_succeeds()
        {
            // Arrange
            var type = typeof(ClassWithMembers);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(DummyBaseType<>));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_an_open_generic_type_is_not_derived_from_itself_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyBaseType<>);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(DummyBaseType<>));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_a_type_is_not_derived_from_its_open_generic_it_fails()
        {
            // Arrange
            var type = typeof(DummyBaseType<ClassWithGenericBaseType>);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom(typeof(DummyBaseType<>), "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.DummyBaseType`1[*.ClassWithGenericBaseType] not to be derived from *.DummyBaseType`1[T] " +
                    "*failure message*, but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_not_to_be_derived_from_null_it_should_throw()
        {
            // Arrange
            var type = typeof(DummyBaseType<>);

            // Act
            Action act =
                () => type.Should().NotBeDerivedFrom(null);

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotBeDerivedFromOfT
    {
        [Fact]
        public async Task When_asserting_a_type_is_not_DerivedFromOfT_an_unrelated_class_it_succeeds()
        {
            // Arrange
            var type = typeof(DummyBaseClass);

            // Act
            Action act = () =>
                type.Should().NotBeDerivedFrom<ClassWithMembers>();

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
