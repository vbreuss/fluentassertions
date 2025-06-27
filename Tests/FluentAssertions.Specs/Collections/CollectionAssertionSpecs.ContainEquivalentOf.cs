using System;
using aweXpect.Equivalency;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]ContainEquivalentOf specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class ContainEquivalentOf
    {
        [Fact]
        public async Task When_collection_contains_object_equal_of_another_it_should_succeed()
        {
            // Arrange
            var item = new Customer { Name = "John" };
            Customer[] collection = [new Customer { Name = "Jane" }, item];

            // Act / Assert
            await That(collection).Contains(item).Equivalent();
        }

        [Fact]
        public async Task When_collection_contains_object_equivalent_of_another_it_should_succeed()
        {
            // Arrange
            Customer[] collection = [new Customer { Name = "Jane" }, new Customer { Name = "John" }];
            var item = new Customer { Name = "John" };

            // Act / Assert
            await Expect.That(collection).Contains(item).Equivalent();
        }

        [Fact]
        public async Task When_character_collection_does_contain_equivalent_it_should_succeed()
        {
            // Arrange
            char[] collection = "abc123ab".ToCharArray();
            char item = 'c';

            // Act / Assert
            await Expect.That(collection).Contains(item).Equivalent();
        }

        //[Fact]
        //public async Task Can_chain_a_successive_assertion_on_the_matching_item()
        //{
        //    // Arrange
        //    char[] collection = "abc123ab".ToCharArray();
        //    char item = 'c';
        //
        //    // Act
        //    var act = async () => await Expect.That(collection).HasSingle(item).Equivalent().Which.IsEqualTo('C');
        //
        //    // Assert
        //    await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection[2] to be equal to C, but found c.").AsWildcard();
        //}

        [Fact]
        public async Task When_collection_does_not_contain_object_equivalent_of_another_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            int item = 4;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(item).Equivalent());

            // Act / Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_contain_equivalent_but_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;
            int expectation = 1;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).Contains(expectation).Equivalent().Because("because we want to test the behaviour with a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_contains_equivalent_null_object_it_should_succeed()
        {
            // Arrange
            int?[] collection = [1, 2, 3, null];
            int? item = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(item).Equivalent());

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_collection_does_not_contain_equivalent_null_object_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            int? item = null;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(item).Equivalent());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_empty_collection_does_not_contain_equivalent_it_should_throw()
        {
            // Arrange
            int[] collection = [];
            int item = 1;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(item).Equivalent());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_does_not_contain_equivalent_because_of_second_property_it_should_throw()
        {
            // Arrange
            Customer[] subject =
            [
                new Customer
                {
                    Name = "John",
                    Age = 18
                },
                new Customer
                {
                    Name = "Jane",
                    Age = 18
                }
            ];

            var item = new Customer { Name = "John", Age = 20 };

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).Contains(item).Equivalent());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Tracing_should_be_included_in_the_assertion_output()
        {
            // Arrange
            Customer[] collection =
            [
                new Customer
                {
                    Name = "John",
                    Age = 18
                },
                new Customer
                {
                    Name = "Jane",
                    Age = 18
                }
            ];

            var item = new Customer { Name = "John", Age = 21 };

            // Act
            Func<Task> act = async () => await Expect.That(collection).Contains(item).Equivalent();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_contains_object_equivalent_of_boxed_object_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            object boxedValue = 2;

            // Act / Assert
            await Expect.That(collection).Contains(boxedValue).Equivalent();
        }
    }

    public class NotContainEquivalentOf
    {
        [Fact]
        public async Task When_collection_contains_object_equal_to_another_it_should_throw()
        {
            // Arrange
            var item = 1;
            int[] collection = [0, 1];

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain(item).Equivalent().Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_contains_several_objects_equal_to_another_it_should_throw()
        {
            // Arrange
            var item = 1;
            int[] collection = [0, 1, 1];

            // Act
            Func<Task> act = async () => await Expect.That(collection).DoesNotContain(item).Equivalent().Because($"because we want to test the failure {"message"}");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_to_contain_equivalent_but_collection_is_null_it_should_throw()
        {
            // Arrange
            var item = 1;
            int[] collection = null;

            // Act
            Func<Task> act = async () => await Expect.That(collection).DoesNotContain(item).Equivalent();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_injecting_a_null_config_to_NotContainEquivalentOf_it_should_throw()
        {
            // Arrange
            int[] collection = null;
            object item = null;

            // Act
            Func<Task> act = async () => await Expect.That(collection).DoesNotContain(item).Equivalent();

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_to_not_contain_equivalent_it_should_succeed()
        {
            // Arrange
            int[] collection = [];
            int item = 4;

            // Act / Assert
            await Expect.That(collection).DoesNotContain(item).Equivalent();
        }

        [Fact]
        public async Task When_asserting_a_null_collection_to_not_contain_equivalent_of__then_it_should_fail()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain(1).Equivalent();
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_does_not_contain_object_equivalent_of_unexpected_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            int item = 4;

            // Act / Assert
            await Expect.That(collection).DoesNotContain(item).Equivalent();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_contain_equivalent_it_should_respect_config()
        {
            // Arrange
            Customer[] collection =
            [
                new Customer
                {
                    Name = "John",
                    Age = 18
                },
                new Customer
                {
                    Name = "Jane",
                    Age = 18
                }
            ];

            var item = new Customer { Name = "John", Age = 20 };

            // Act
            Func<Task> act = async () => await Expect.That(collection).DoesNotContain(item).Equivalent();

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_contain_equivalent_it_should_allow_combining_inside_assertion_scope()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            int another = 3;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain(another).Equivalent().And.HasCount(4).Because($"because we want to test {"second message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
