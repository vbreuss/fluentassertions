using System;
using AssemblyA;
using AssemblyB;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class BeOfType
    {
        [Fact]
        public async Task When_object_type_is_matched_against_null_type_exactly_it_should_throw()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsExactly(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_object_type_is_exactly_equal_to_the_specified_type_it_should_not_fail()
        {
            // Arrange
            var someObject = new Exception();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsExactly<Exception>());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
        /* TODO VAB
        [Fact]
        public async Task When_object_type_is_value_type_and_matches_received_type_should_not_fail_and_assert_correctly()
        {
            // Arrange
            int valueTypeObject = 42;

            // Act
            Func<Task> act = async () =>
            {
                await aweXpect.Synchronous.Synchronously.Verify(Expect.That(valueTypeObject).IsExactly(typeof(int)));
            };

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_object_is_matched_against_a_null_type_it_should_throw()
        {
            // Arrange
            int valueTypeObject = 42;

            // Act
            Func<Task> act = async () =>
            {
                await aweXpect.Synchronous.Synchronously.Verify(Expect.That(valueTypeObject).IsExactly(null));
            };

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_null_object_is_matched_against_a_type_it_should_throw()
        {
            // Arrange
            int? valueTypeObject = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsExactly(typeof(int)).Because($"because we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_object_type_is_value_type_and_doesnt_match_received_type_should_fail()
        {
            // Arrange
            int valueTypeObject = 42;
            var doubleType = typeof(double);

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsExactly(doubleType);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
        */

        [Fact]
        public async Task When_object_type_is_different_than_expected_type_it_should_fail_with_descriptive_message()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsExactly<int>().Because($"because they are {"of different"} {"type"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_type_of_a_null_object_it_should_throw()
        {
            // Arrange
            object someObject = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsExactly<int>());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_object_type_is_same_as_expected_type_but_in_different_assembly_it_should_fail_with_assembly_qualified_name()
        {
            // Arrange
            var typeFromOtherAssembly =
                new ClassA().ReturnClassC();

            // Act
#pragma warning disable 436 // disable the warning on conflicting types, as this is the intention for the spec

            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(typeFromOtherAssembly).IsExactly<ClassC>());

#pragma warning restore 436

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_object_type_is_a_subclass_of_the_expected_type_it_should_fail()
        {
            // Arrange
            var someObject = new DummyImplementingClass();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsExactly<DummyBaseClass>());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeOfType
    {
        [Fact]
        public async Task When_object_type_is_matched_negatively_against_null_type_exactly_it_should_throw()
        {
            // Arrange
            var someObject = new object();

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(someObject).IsNotExactly(null));

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        /* TODO VAB
        [Fact]
        public async Task When_object_is_matched_negatively_against_a_null_type_it_should_throw()
        {
            // Arrange
            int valueTypeObject = 42;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsNotExactly(null);
            };

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_object_type_is_value_type_and_doesnt_match_received_type_as_expected_should_not_fail_and_assert_correctly()
        {
            // Arrange
            int valueTypeObject = 42;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsNotExactly(typeof(double));
            };

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_null_object_is_matched_negatively_against_a_type_it_should_throw()
        {
            // Arrange
            int? valueTypeObject = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsNotExactly(typeof(int)).Because($"because we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_object_type_is_value_type_and_matches_received_type_not_as_expected_should_fail()
        {
            // Arrange
            int valueTypeObject = 42;
            var expectedType = typeof(int);

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(valueTypeObject).IsNotExactly(expectedType);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
        */
    }
}
