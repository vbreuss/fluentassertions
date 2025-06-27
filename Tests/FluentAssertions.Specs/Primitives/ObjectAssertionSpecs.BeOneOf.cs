using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf(new ClassWithCustomEqualMethod(4), new ClassWithCustomEqualMethod(5)));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(3);

            // Act
            Action act = () =>
Synchronously.Verify(That(value).IsOneOf([new ClassWithCustomEqualMethod(4), new ClassWithCustomEqualMethod(5)], "because those are the valid values"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(4);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf(new ClassWithCustomEqualMethod(4), new ClassWithCustomEqualMethod(5)));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task An_untyped_value_is_one_of_the_specified_values()
        {
            // Arrange
            object value = new SomeClass(5);

            // Act / Assert
            await That(value).IsOneOf([new SomeClass(4), new SomeClass(5)]).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task A_typed_value_is_one_of_the_specified_values()
        {
            // Arrange
            var value = new SomeClass(5);

            // Act / Assert
            await That(value).IsOneOf([new SomeClass(4), new SomeClass(5)]).Using(new SomeClassEqualityComparer());
        }

        [Fact]
        public async Task An_untyped_value_is_not_one_of_the_specified_values()
        {
            // Arrange
            object value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf(new SomeClass(4), new SomeClass(5)).Using(new SomeClassEqualityComparer()).Because("I said so"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task An_untyped_value_is_not_one_of_no_values()
        {
            // Arrange
            object value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf([]).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_one_of_the_specified_values()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf([new SomeClass(4), new SomeClass(5)]).Using(new SomeClassEqualityComparer()).Because("I said so"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_one_of_no_values()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf([]).Using(new SomeClassEqualityComparer()));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_typed_value_is_not_the_same_type_as_the_specified_values()
        {
            // Arrange
            var value = new ClassWithCustomEqualMethod(3);

            // Act
            Action act = () => Synchronously.Verify(That(value).IsOneOf([new SomeClass(4), new SomeClass(5)]).Using(new SomeClassEqualityComparer()).Because("I said so"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Chaining_after_one_assertion()
        {
            // Arrange
            var value = new SomeClass(3);

            // Act / Assert
            await That(value).IsOneOf(value);
        }

        [Fact]
        public async Task Can_chain_multiple_assertions()
        {
            // Arrange
            var value = new object();

            // Act / Assert
            await That(value).IsOneOf([value]).Using(new DumbObjectEqualityComparer());
        }
    }
}
