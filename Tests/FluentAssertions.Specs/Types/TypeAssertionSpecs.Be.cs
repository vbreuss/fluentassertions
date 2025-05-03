using System;
using AssemblyA;
using AssemblyB;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Types;

/// <content>
/// The [Not]Be specs.
/// </content>
public partial class TypeAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task When_type_is_equal_to_the_same_type_it_succeeds()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);
            Type sameType = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsEqualTo(sameType));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_equal_to_another_type_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);
            Type differentType = typeof(ClassWithoutAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsEqualTo(differentType).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_equality_of_two_null_types_it_succeeds()
        {
            // Arrange
            Type nullType = null;
            Type someType = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullType).IsEqualTo(someType));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_equality_of_a_type_but_the_type_is_null_it_fails()
        {
            // Arrange
            Type nullType = null;
            Type someType = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullType).IsEqualTo(someType).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_equality_of_a_type_with_null_it_fails()
        {
            // Arrange
            Type someType = typeof(ClassWithAttribute);
            Type nullType = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(someType).IsEqualTo(nullType).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_equal_to_same_type_from_different_assembly_it_fails_with_assembly_qualified_name()
        {
            // Arrange
#pragma warning disable 436 // disable the warning on conflicting types, as this is the intention for the spec

            Type typeFromThisAssembly = typeof(ClassC);

            Type typeFromOtherAssembly =
                new ClassA().ReturnClassC().GetType();

#pragma warning restore 436

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(typeFromThisAssembly).IsEqualTo(typeFromOtherAssembly).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_equal_to_the_same_type_using_generics_it_succeeds()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).Is<ClassWithAttribute>());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_equal_to_another_type_using_generics_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsEqualTo("we want to test the failure {0}").Because("message"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task When_type_is_not_equal_to_the_another_type_it_succeeds()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);
            Type otherType = typeof(ClassWithoutAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNotEqualTo(otherType));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_not_equal_to_the_same_type_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);
            Type sameType = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNotEqualTo(sameType).Because($"we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_not_equal_to_the_same_null_type_it_fails()
        {
            // Arrange
            Type type = null;
            Type sameType = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNotEqualTo(sameType));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_type_is_not_equal_to_another_type_using_generics_it_succeeds()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNot<ClassWithoutAttribute>());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_type_is_not_equal_to_the_same_type_using_generics_it_fails()
        {
            // Arrange
            Type type = typeof(ClassWithAttribute);

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(type).IsNotEqualTo("we want to test the failure {0}").Because("message"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
