using System;
using FluentAssertions.Specs.Primitives;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]BeAssignableTo specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class BeAssignableTo
    {
        [Fact]
        public async Task When_its_own_type_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is<DummyImplementingClass>();
        }

        [Fact]
        public async Task When_its_base_type_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is<DummyBaseClass>();
        }

        [Fact]
        public async Task When_implemented_interface_type_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is<IDisposable>();
        }

        [Fact]
        public async Task When_an_unrelated_type_it_fails()
        {
            // Arrange
            Type someType = typeof(DummyImplementingClass);
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someType).Is<DateTime>().Because($"we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected someType *.DummyImplementingClass to be assignable to *.DateTime *failure message*" +
                    ", but it is not.").AsWildcard();
        }

        [Fact]
        public async Task When_its_own_type_instance_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is(typeof(DummyImplementingClass));
        }

        [Fact]
        public async Task When_its_base_type_instance_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is(typeof(DummyBaseClass));
        }

        [Fact]
        public async Task When_an_implemented_interface_type_instance_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).Is(typeof(IDisposable));
        }

        [Fact]
        public async Task When_an_unrelated_type_instance_it_fails()
        {
            // Arrange
            Type someType = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someType).Is(typeof(DateTime)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_constructed_of_open_generic_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(IDummyInterface<IDummyInterface>)).Is(typeof(IDummyInterface<>));
        }

        [Fact]
        public async Task When_implementation_of_open_generic_interface_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(ClassWithGenericBaseType)).Is(typeof(IDummyInterface<>));
        }

        [Fact]
        public async Task When_derived_of_open_generic_class_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(ClassWithGenericBaseType)).Is(typeof(DummyBaseType<>));
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_interface_it_fails()
        {
            // Arrange
            Type someType = typeof(IDummyInterface);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someType).Is(typeof(IDummyInterface<>)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected someType *.IDummyInterface to be assignable to *.IDummyInterface`1[T] *failure message*" +
                    ", but it is not.").AsWildcard();
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_type_it_fails()
        {
            // Arrange
            Type someType = typeof(ClassWithAttribute);

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someType).Is(typeof(DummyBaseType<>)).Because($"we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_open_generic_class_is_assignable_to_itself_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyBaseType<>)).Is(typeof(DummyBaseType<>));
        }

        [Fact]
        public async Task When_asserting_a_type_to_be_assignable_to_null_it_should_throw()
        {
            // Arrange
            var type = typeof(DummyBaseType<>);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).Is(null));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }

    public class NotBeAssignableTo
    {
        [Fact]
        public async Task When_its_own_type_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot<DummyImplementingClass>().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_its_base_type_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot<DummyBaseClass>().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.DummyImplementingClass to not be assignable to *.DummyBaseClass *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_implemented_interface_type_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot<IDisposable>().Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_unrelated_type_and_asserting_not_assignable_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).IsNot<DateTime>();
        }

        [Fact]
        public async Task When_its_own_type_instance_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(typeof(DummyImplementingClass)).Because($"we want to test the failure {"message"}"));

            // Act / Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.DummyImplementingClass to not be assignable to *.DummyImplementingClass *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_its_base_type_instance_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(typeof(DummyBaseClass)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.DummyImplementingClass to not be assignable to *.DummyBaseClass *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_an_implemented_interface_type_instance_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            var type = typeof(DummyImplementingClass);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(typeof(IDisposable)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_unrelated_type_instance_and_asserting_not_assignable_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(DummyImplementingClass)).IsNot(typeof(DateTime));
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_interface_and_asserting_not_assignable_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(ClassWithAttribute)).IsNot(typeof(IDummyInterface<>));
        }

        [Fact]
        public async Task When_unrelated_to_open_generic_class_and_asserting_not_assignable_it_succeeds()
        {
            // Arrange / Act / Assert
            await Expect.That(typeof(ClassWithAttribute)).IsNot(typeof(DummyBaseType<>));
        }

        [Fact]
        public async Task When_implementation_of_open_generic_interface_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithGenericBaseType);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(typeof(IDummyInterface<>)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithGenericBaseType to not be assignable to *.IDummyInterface`1[T] *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_derived_from_open_generic_class_and_asserting_not_assignable_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithGenericBaseType);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(typeof(IDummyInterface<>)).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected type *.ClassWithGenericBaseType to not be assignable to *.IDummyInterface`1[T] *failure message*" +
                    ", but it is.").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_a_type_not_to_be_assignable_to_null_it_should_throw()
        {
            // Arrange
            var type = typeof(DummyBaseType<>);

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot(null));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }
    }
}
