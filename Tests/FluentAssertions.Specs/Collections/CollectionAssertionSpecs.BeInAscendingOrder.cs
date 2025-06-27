using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeInAscendingOrder specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeInAscendingOrder
    {
        [Fact]
        public async Task When_asserting_a_null_collection_to_be_in_ascending_order_it_should_throw()
        {
            // Arrange
            List<int> result = null;

            // Act

            Func<Task> act = async () =>
            {
                await That(result).IsInAscendingOrder();
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_ordered_ascending_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act / Assert
            await That(collection).IsInAscendingOrder();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_ordered_ascending_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act / Assert
            await That(collection).IsInAscendingOrder().Using(Comparer<int>.Default);
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_ascending_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 6, 12, 15, 12, 17, 26];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsInAscendingOrder().Because("because numbers are ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_ascending_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 6, 12, 15, 12, 17, 26];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsInAscendingOrder().Using(Comparer<int>.Default).Because("because numbers are ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Items_can_be_ordered_by_the_identity_function()
        {
            // Arrange
            int[] collection = [1, 2];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsInAscendingOrder(x => x));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_empty_collection_with_no_parameters_ordered_in_ascending_it_should_succeed()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_empty_collection_by_property_expression_ordered_in_ascending_it_should_succeed()
        {
            // Arrange
            IEnumerable<SomeClass> collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Number));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_with_no_parameters_ordered_in_ascending_it_should_succeed()
        {
            // Arrange
            int[] collection = [42];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_by_property_expression_ordered_in_ascending_it_should_succeed()
        {
            // Arrange
            var collection = new SomeClass[]
            {
                new() { Text = "a", Number = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Number));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Can_use_a_cast_expression_in_the_ordering_expression()
        {
            // Arrange
            var collection = new SomeClass[]
            {
                new() { Text = "a", Number = 1 }
            };

            // Act & Assert
            await That(collection).IsInAscendingOrder(o => (float)o.Number);
        }

        [Fact]
        public async Task Can_use_an_index_into_a_list_in_the_ordering_expression()
        {
            // Arrange
            List<SomeClass>[] collection =
            [
                [new() { Text = "a", Number = 1 }]
            ];

            // Act & Assert
            await That(collection).IsInAscendingOrder(o => o[0].Number);
        }

        [Fact]
        public async Task Can_use_an_index_into_an_array_in_the_ordering_expression()
        {
            // Arrange
            SomeClass[][] collection =
            [
                [new SomeClass { Text = "a", Number = 1 }]
            ];

            // Act & Assert
            await That(collection).IsInAscendingOrder(o => o[0].Number);
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_ascending_using_the_specified_property_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Text).Because("it should be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_ascending_using_the_specified_property_and_the_given_comparer_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () =>
Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase).Because("it should be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_ordered_ascending_using_the_specified_property_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Numeric));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_ordered_ascending_using_the_specified_property_and_the_given_comparer_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Numeric).Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_in_ascending_order_it_should_succeed()
        {
            // Arrange
            string[] strings = ["alpha", "beta", "theta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInAscendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_ascending_order_it_should_throw()
        {
            // Arrange
            string[] strings = ["theta", "alpha", "beta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInAscendingOrder().Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_are_in_ascending_order_according_to_a_custom_comparer_it_should_succeed()
        {
            // Arrange
            string[] strings = ["alpha", "beta", "theta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInAscendingOrder().Using(new ByLastCharacterComparer()));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_ascending_order_according_to_a_custom_comparer_it_should_throw()
        {
            // Arrange
            string[] strings = ["dennis", "roy", "thomas"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInAscendingOrder().Using(new ByLastCharacterComparer()).Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_in_ascending_order_according_to_a_custom_lambda_it_should_succeed()
        //{
        //    // Arrange
        //    string[] strings = ["alpha", "beta", "theta"];
        //
        //    // Act
        //    Action act = () => strings.Should().BeInAscendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]));
        //
        //    // Assert
        //    await That(act).DoesNotThrow();
        //}
        //
        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_not_in_ascending_order_according_to_a_custom_lambda_it_should_throw()
        //{
        //    // Arrange
        //    string[] strings = ["dennis", "roy", "thomas"];
        //
        //    // Act
        //    Action act = () =>
        //        strings.Should().BeInAscendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]), "of {0}", "reasons");
        //
        //    // Assert
        //    await That(act).Throws<XunitException>();
        //}

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_ordered_using_the_specified_property_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Text));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_ordered_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder().Using(Comparer<SomeClass>.Default));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_ordered_using_the_specified_property_and_the_given_comparer_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInAscendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeInAscendingOrder
    {
        [Fact]
        public async Task When_asserting_a_null_collection_to_not_be_in_ascending_order_it_should_throw()
        {
            // Arrange
            List<int> result = null;

            // Act
            Action act = () => Synchronously.Verify(That(result).IsNotInAscendingOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_not_in_ascending_order_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 5, 3];

            // Act / Assert
            await That(collection).IsNotInAscendingOrder();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_not_in_ascending_order_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 5, 3];

            // Act / Assert
            await That(collection).IsNotInAscendingOrder().Using(Comparer<int>.Default);
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_not_in_ascending_order_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder().Because("because numbers are not ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ascendingly_ordered_collection_are_not_in_ascending_order_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act
            Action action = () =>
Synchronously.Verify(That(collection).IsNotInAscendingOrder().Using(Comparer<int>.Default).Because("because numbers are not ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_by_property_expression_to_not_be_ordered_in_ascending_it_should_throw()
        {
            // Arrange
            IEnumerable<SomeClass> collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Number));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_with_no_parameters_not_be_ordered_in_ascending_it_should_throw()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder().Because($"because I say {"so"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_with_no_parameters_not_be_ordered_in_ascending_it_should_throw()
        {
            // Arrange
            int[] collection = [42];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_by_property_expression_to_not_be_ordered_in_ascending_it_should_throw()
        {
            // Arrange
            var collection = new SomeClass[]
            {
                new() { Text = "a", Number = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Number));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_ascending_ordered_collection_are_not_ordered_ascending_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder().Using(Comparer<int>.Default).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_ascendingly_ordered_collection_are_not_ordered_ascending_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            int[] collection = [3, 2, 1];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder().Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_ascending_ordered_collection_are_not_ordered_ascending_using_the_specified_property_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "a", Numeric = 3 },
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Text).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ordered_collection_are_not_ordered_ascending_using_the_specified_property_and_the_given_comparer_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "A", Numeric = 1 },
                new { Text = "b", Numeric = 2 },
                new { Text = "C", Numeric = 3 }
            };

            // Act
            Action act = () =>
Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_ascendingly_ordered_collection_are_not_ordered_ascending_using_the_specified_property_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 3 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Numeric));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_ascendingly_ordered_collection_are_not_ordered_ascending_using_the_specified_property_and_the_given_comparer_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 3 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Numeric).Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_ascending_order_it_should_succeed()
        {
            // Arrange
            string[] strings = ["beta", "alpha", "theta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInAscendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_in_ascending_order_unexpectedly_it_should_throw()
        {
            // Arrange
            string[] strings = ["alpha", "beta", "theta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInAscendingOrder().Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_are_not_in_ascending_order_according_to_a_custom_comparer_it_should_succeed()
        {
            // Arrange
            string[] strings = ["dennis", "roy", "barbara"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInAscendingOrder().Using(new ByLastCharacterComparer()));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_unexpectedly_in_ascending_order_according_to_a_custom_comparer_it_should_throw()
        {
            // Arrange
            string[] strings = ["dennis", "thomas", "roy"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInAscendingOrder().Using(new ByLastCharacterComparer()).Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_not_in_ascending_order_according_to_a_custom_lambda_it_should_succeed()
        //{
        //    // Arrange
        //    string[] strings = ["roy", "dennis", "thomas"];
        //
        //    // Act
        //    Action act = () => strings.Should().NotBeInAscendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]));
        //
        //    // Assert
        //    await That(act).DoesNotThrow();
        //}
        //
        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_unexpectedly_in_ascending_order_according_to_a_custom_lambda_it_should_throw()
        //{
        //    // Arrange
        //    string[] strings = ["barbara", "dennis", "roy"];
        //
        //    // Act
        //    Action act = () =>
        //        strings.Should().NotBeInAscendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]), "of {0}", "reasons");
        //
        //    // Assert
        //    await That(act).Throws<XunitException>();
        //}

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_not_ordered_using_the_specified_property_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                using var _ = new AssertionScope();
                await That(collection).IsNotInAscendingOrder(o => o.Text);
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_not_ordered_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                using var _ = new AssertionScope();
                await That(collection).IsNotInAscendingOrder().Using(Comparer<SomeClass>.Default);
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_null_collection_are_not_ordered_using_the_specified_property_and_the_given_comparer_it_should_throw()
        {
            // Arrange
            const IEnumerable<SomeClass> collection = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInAscendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
