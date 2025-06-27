using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]ContainInOrder specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class ContainInConsecutiveOrder
    {
        [Fact]
        public async Task When_the_first_collection_contains_a_duplicate_item_without_affecting_the_explicit_order_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3, 2];

            // Act / Assert
            await Expect.That(collection).Contains([1, 2, 3]);
        }

        [Fact]
        public async Task When_the_second_collection_contains_just_1_item_included_in_the_first_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3, 2];

            // Act / Assert
            await Expect.That(collection).Contains(2);
        }

        [Fact]
        public async Task When_the_first_collection_contains_a_partial_duplicate_sequence_at_the_start_without_affecting_the_explicit_order_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 3, 2];

            // Act / Assert
            await Expect.That(collection).Contains([1, 2, 3]);
        }

        [Fact]
        public async Task When_two_collections_contain_the_same_duplicate_items_in_the_same_explicit_order_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 12, 2, 2];

            // Act / Assert
            await Expect.That(collection).Contains([1, 2, 1, 2, 12, 2, 2]);
        }

        [Fact]
        public async Task When_checking_for_an_empty_list_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 12, 2, 2];

            // Act / Assert
            await Expect.That(collection).Contains([]);
        }

        [Fact]
        public async Task When_collection_contains_null_value_it_should_not_throw()
        {
            // Arrange
            var collection = new object[] { 1, null, 2, "string" };

            // Act / Assert
            await Expect.That(collection).Contains([1, null, 2, "string"]);
        }

        [Fact]
        public async Task When_two_collections_contain_the_same_items_but_not_in_the_same_explicit_order_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act / Assert
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([1, 2, 3]));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_the_second_collection_contains_just_1_item_not_included_in_the_first_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 2, 3];

            // Act / Assert
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(4));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_end_of_first_collection_is_a_partial_match_of_second_at_end_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 3, 1, 2];

            // Act / Assert
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([1, 2, 3]));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_a_range_twice_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 3, 12, 2, 2];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([1, 2, 1, 1, 2]));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_collections_contain_the_same_items_but_in_different_order_it_should_throw_with_a_clear_explanation()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(new[] { 1, 2, 3 }).Contains([3, 1]).Because("because we said so"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_an_ordered_item_it_should_throw_with_a_clear_explanation()
        {
            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(new[] { 1, 2, 3 }).Contains([4, 1]).Because("we failed"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_contains_some_values_in_order_but_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).Contains([4]).Because("because we're checking how it reacts to a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotContainInConsecutiveOrder
    {
        [Fact]
        public void When_two_collections_contain_the_same_items_but_in_different_order_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder(2, 1);
        }

        [Fact]
        public void When_the_second_collection_contains_just_1_item_not_included_in_the_first_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder(4);
        }

        [Fact]
        public void When_a_collection_does_not_contain_an_ordered_item_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder(4, 1);
        }

        [Fact]
        public void When_checking_for_an_empty_list_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder();
        }

        [Fact]
        public void When_a_collection_contains_less_items_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder(1, 2, 3);
        }

        [Fact]
        public void When_a_collection_does_not_contain_a_range_twice_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 3, 12, 2, 2];

            // Act / Assert
            collection.Should().NotContainInConsecutiveOrder(1, 2, 1, 1, 2);
        }

        [Fact]
        public void When_two_collections_contain_the_same_items_not_in_the_same_explicit_order_it_should_not_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 2, 3];

            // Act
            collection.Should().NotContainInConsecutiveOrder([1, 2, 3], "that's what we expect");
        }

        [Fact]
        public async Task When_asserting_collection_does_not_contain_some_values_in_order_but_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(4);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Cannot verify absence of ordered containment in a <null> collection.").AsWildcard();
        }

        [Fact]
        public async Task When_collection_is_null_then_not_contain_in_order_should_fail()
        {
            // Arrange
            int[] collection = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                collection.Should().NotContainInConsecutiveOrder([1, 2, 3], "we want to test the failure {0}", "message");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_and_contains_contain_the_same_items_in_the_same_order_with_null_value_it_should_throw()
        {
            // Arrange
            var collection = new object[] { 1, null, 2, "string" };

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(1, null, 2, "string");

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection {1, <null>, 2, \"string\"} to not contain items {1, <null>, 2, \"string\"} in consecutive order, " +
                "but items appeared in order ending at index 3.").AsWildcard();
        }

        [Fact]
        public async Task When_the_second_collection_contains_just_1_item_included_in_the_first_it_should_throw()
        {
            // Arrange
            var collection = new object[] { 1, null, 2, "string" };

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(2);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection {1, <null>, 2, \"string\"} to not contain items {2} in consecutive order, " +
                "but items appeared in order ending at index 2.").AsWildcard();
        }

        [Fact]
        public async Task When_the_first_collection_contains_a_duplicate_item_without_affecting_the_order_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3, 2];

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(1, 2, 3);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection {1, 2, 3, 2} to not contain items {1, 2, 3} in consecutive order, " +
                "but items appeared in order ending at index 2.").AsWildcard();
        }

        [Fact]
        public async Task When_the_first_collection_contains_a_duplicate_item_not_at_start_without_affecting_the_order_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 3, 4, 5, 1, 2];

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(1, 2, 3);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection {1, 2, 1, 2, 3, 4, 5, 1, 2} to not contain items {1, 2, 3} in consecutive order, " +
                "but items appeared in order ending at index 4.").AsWildcard();
        }

        [Fact]
        public async Task When_two_collections_contain_the_same_duplicate_items_in_the_same_order_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 1, 2, 12, 2, 2];

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(1, 2, 1, 2, 12, 2, 2);

            // Assert
            await Expect.That(act).Throws<XunitException>().WithMessage("Expected collection {1, 2, 1, 2, 12, 2, 2} to not contain items {1, 2, 1, 2, 12, 2, 2} in consecutive order, " +
                "but items appeared in order ending at index 6.").AsWildcard();
        }

        [Fact]
        public async Task When_passing_in_null_while_checking_for_absence_of_ordered_containment_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => collection.Should().NotContainInConsecutiveOrder(null);

            // Assert
            await Expect.That(act).Throws<ArgumentNullException>().WithMessage("Cannot verify absence of ordered containment against a <null> collection.*").AsWildcard();
        }
    }
}
