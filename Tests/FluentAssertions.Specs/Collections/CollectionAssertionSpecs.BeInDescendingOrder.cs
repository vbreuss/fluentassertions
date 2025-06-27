using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeInDescendingOrder specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeInDescendingOrder
    {
        [Fact]
        public async Task When_asserting_the_items_in_an_descendingly_ordered_collection_are_ordered_descending_it_should_succeed()
        {
            // Arrange
            string[] collection = ["z", "y", "x"];

            // Act / Assert
            await That(collection).IsInDescendingOrder();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_descending_it_should_throw()
        {
            // Arrange
            string[] collection = ["z", "x", "y"];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsInDescendingOrder().Because("because letters are ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_by_property_expression_ordered_in_descending_it_should_succeed()
        {
            // Arrange
            IEnumerable<SomeClass> collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Number));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_empty_collection_with_no_parameters_ordered_in_descending_it_should_succeed()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_with_no_parameters_ordered_in_descending_it_should_succeed()
        {
            // Arrange
            int[] collection = [42];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_by_property_expression_ordered_in_descending_it_should_succeed()
        {
            // Arrange
            var collection = new SomeClass[]
            {
                new() { Text = "a", Number = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Number));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_descending_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            string[] collection = ["z", "x", "y"];

            // Act
            Action action = () =>
Synchronously.Verify(That(collection).IsInDescendingOrder().Using(Comparer<object>.Default).Because("because letters are ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_descendingly_ordered_collection_are_ordered_descending_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            string[] collection = ["z", "y", "x"];

            // Act / Assert
            await That(collection).IsInDescendingOrder().Using(Comparer<object>.Default);
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_descending_using_the_specified_property_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Text).Because("it should be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_ordered_descending_using_the_specified_property_and_the_given_comparer_it_should_throw()
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
Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase).Because("it should be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_descendingly_ordered_collection_are_ordered_descending_using_the_specified_property_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 3 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Numeric));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_descendingly_ordered_collection_are_ordered_descending_using_the_specified_property_and_the_given_comparer_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 3 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsInDescendingOrder(o => o.Numeric).Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_in_descending_order_it_should_succeed()
        {
            // Arrange
            string[] strings = ["theta", "beta", "alpha"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInDescendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_descending_order_it_should_throw()
        {
            // Arrange
            string[] strings = ["theta", "alpha", "beta"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInDescendingOrder().Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_are_in_descending_order_based_on_a_custom_comparer_it_should_succeed()
        {
            // Arrange
            string[] strings = ["roy", "dennis", "barbara"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInDescendingOrder().Using(new ByLastCharacterComparer()));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_descending_order_based_on_a_custom_comparer_it_should_throw()
        {
            // Arrange
            string[] strings = ["dennis", "roy", "barbara"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsInDescendingOrder().Using(new ByLastCharacterComparer()).Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_in_descending_order_based_on_a_custom_lambda_it_should_succeed()
        //{
        //    // Arrange
        //    string[] strings = ["roy", "dennis", "barbara"];
        //
        //    // Act
        //    Action act = () => strings.Should().BeInDescendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]));
        //
        //    // Assert
        //    await That(act).DoesNotThrow();
        //}
        //
        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_not_in_descending_order_based_on_a_custom_lambda_it_should_throw()
        //{
        //    // Arrange
        //    string[] strings = ["dennis", "roy", "barbara"];
        //
        //    // Act
        //    Action act = () =>
        //        strings.Should().BeInDescendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]), "of {0}", "reasons");
        //
        //    // Assert
        //    await That(act).Throws<XunitException>();
        //}
    }

    public class NotBeInDescendingOrder
    {
        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_not_in_descending_order_it_should_succeed()
        {
            // Arrange
            string[] collection = ["x", "y", "x"];

            // Act / Assert
            await That(collection).IsNotInDescendingOrder();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_unordered_collection_are_not_in_descending_order_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            string[] collection = ["x", "y", "x"];

            // Act / Assert
            await That(collection).IsNotInDescendingOrder().Using(Comparer<object>.Default);
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_descending_ordered_collection_are_not_in_descending_order_it_should_throw()
        {
            // Arrange
            string[] collection = ["c", "b", "a"];

            // Act
            Action action = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder().Because("because numbers are not ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_descending_ordered_collection_are_not_in_descending_order_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            string[] collection = ["c", "b", "a"];

            // Act
            Action action = () =>
Synchronously.Verify(That(collection).IsNotInDescendingOrder().Using(Comparer<object>.Default).Because("because numbers are not ordered"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_by_property_expression_to_not_be_ordered_in_descending_it_should_throw()
        {
            // Arrange
            IEnumerable<SomeClass> collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Number));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_empty_collection_with_no_parameters_not_be_ordered_in_descending_it_should_throw()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder().Because($"because I say {"so"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_with_no_parameters_not_be_ordered_in_descending_it_should_throw()
        {
            // Arrange
            int[] collection = [42];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_single_element_collection_by_property_expression_to_not_be_ordered_in_descending_it_should_throw()
        {
            // Arrange
            var collection = new SomeClass[]
            {
                new() { Text = "a", Number = 1 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Number));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_descending_ordered_collection_are_not_ordered_descending_using_the_given_comparer_it_should_throw()
        {
            // Arrange
            int[] collection = [3, 2, 1];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder().Using(Comparer<int>.Default).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_descendingly_ordered_collection_are_not_ordered_descending_using_the_given_comparer_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder().Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_in_a_descending_ordered_collection_are_not_ordered_descending_using_the_specified_property_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "c", Numeric = 3 },
                new { Text = "b", Numeric = 1 },
                new { Text = "a", Numeric = 2 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Text).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_in_an_ordered_collection_are_not_ordered_descending_using_the_specified_property_and_the_given_comparer_it_should_throw()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "C", Numeric = 1 },
                new { Text = "b", Numeric = 2 },
                new { Text = "A", Numeric = 3 }
            };

            // Act
            Action act = () =>
Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Text).Using(StringComparer.OrdinalIgnoreCase).Because("it should not be sorted"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_descendingly_ordered_collection_are_not_ordered_descending_using_the_specified_property_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Numeric));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_the_items_not_in_an_descendingly_ordered_collection_are_not_ordered_descending_using_the_specified_property_and_the_given_comparer_it_should_succeed()
        {
            // Arrange
            var collection = new[]
            {
                new { Text = "b", Numeric = 1 },
                new { Text = "c", Numeric = 2 },
                new { Text = "a", Numeric = 3 }
            };

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotInDescendingOrder(o => o.Numeric).Using(Comparer<int>.Default));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_not_in_descending_order_it_should_succeed()
        {
            // Arrange
            string[] strings = ["beta", "theta", "alpha"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInDescendingOrder());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_unexpectedly_in_descending_order_it_should_throw()
        {
            // Arrange
            string[] strings = ["theta", "beta", "alpha"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInDescendingOrder().Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_strings_are_not_in_descending_order_based_on_a_custom_comparer_it_should_succeed()
        {
            // Arrange
            string[] strings = ["roy", "barbara", "dennis"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInDescendingOrder().Using(new ByLastCharacterComparer()));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_strings_are_unexpectedly_in_descending_order_based_on_a_custom_comparer_it_should_throw()
        {
            // Arrange
            string[] strings = ["roy", "dennis", "barbara"];

            // Act
            Action act = () => Synchronously.Verify(That(strings).IsNotInDescendingOrder().Using(new ByLastCharacterComparer()).Because($"of {"reasons"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_not_in_descending_order_based_on_a_custom_lambda_it_should_succeed()
        //{
        //    // Arrange
        //    string[] strings = ["dennis", "roy", "barbara"];
        //
        //    // Act
        //    Action act = () => strings.Should().NotBeInDescendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]));
        //
        //    // Assert
        //    await That(act).DoesNotThrow();
        //}
        //
        //[Fact(Skip = "TODO VAB: Unsupported syntax")]
        //public async Task When_strings_are_unexpectedly_in_descending_order_based_on_a_custom_lambda_it_should_throw()
        //{
        //    // Arrange
        //    string[] strings = ["roy", "dennis", "barbara"];
        //
        //    // Act
        //    Action act = () =>
        //        strings.Should().NotBeInDescendingOrder((sut, exp) => sut[^1].CompareTo(exp[^1]), "of {0}", "reasons");
        //
        //    // Assert
        //    await That(act).Throws<XunitException>();
        //}
    }
}
