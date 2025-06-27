using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]Contain specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class Contain
    {
        [Fact]
        public async Task Should_succeed_when_asserting_collection_contains_an_item_from_the_collection()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).Contains(1);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_collection_contains_multiple_items_from_the_collection_in_any_order()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).Contains([2, 1]).InAnyOrder();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_single_item_it_should_throw_with_clear_explanation()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(4).Because($"because {"we do"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_does_contain_item_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).Contains(1).Because("because we want to test the behaviour with a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_another_collection_it_should_throw_with_clear_explanation()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([3, 4, 5]).InAnyOrder().Because($"because {"we do"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_a_single_element_collection_it_should_throw_with_clear_explanation()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([4]).InAnyOrder().Because($"because {"we do"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_other_collection_with_assertion_scope_it_should_throw_with_clear_explanation()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).Contains([4]).InAnyOrder().And.Contains([5, 6]).InAnyOrder();
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/643")]
        public async Task When_the_contents_of_a_collection_are_checked_against_an_empty_collection_it_should_throw_clear_explanation()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains([]).InAnyOrder());

            // Assert
            await Expect.That(act).Throws<ArgumentException>().WithMessage("Cannot verify containment against an empty collection*").AsWildcard();
        }

        [Fact]
        public async Task When_asserting_collection_does_contain_a_list_of_items_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).Contains([1, 2]).InAnyOrder().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_Contain_it_should_throw()
        {
            // Arrange
            IEnumerable<int> collection = [];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(predicate: null));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_collection_does_not_contain_an_expected_item_matching_a_predicate_it_should_throw()
        {
            // Arrange
            IEnumerable<int> collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(item => item > 3).Because($"at least {1} item should be larger than 3"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_does_contain_an_expected_item_matching_a_predicate_it_should_not_throw()
        {
            // Arrange
            IEnumerable<int> collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).Contains(item => item == 2);
        }

        [Fact]
        public async Task When_a_collection_of_strings_contains_the_expected_string_it_should_not_throw()
        {
            // Arrange
            IEnumerable<string> strings = ["string1", "string2", "string3"];

            // Act / Assert
            await Expect.That(strings).Contains("string2");
        }

        [Fact]
        public async Task When_a_collection_of_strings_does_not_contain_the_expected_string_it_should_throw()
        {
            // Arrange
            IEnumerable<string> strings = ["string1", "string2", "string3"];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(strings).Contains("string4").Because($"because {"4"} is required"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_contains_some_values_but_collection_is_null_it_should_throw()
        {
            // Arrange
            const IEnumerable<string> strings = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(strings).Contains("string4").Because("because we're checking how it reacts to a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_contains_values_according_to_predicate_but_collection_is_null_it_should_throw()
        {
            // Arrange
            const IEnumerable<string> strings = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(strings).Contains(x => x == "xxx").Because("because we're checking how it reacts to a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotContain
    {
        [Fact]
        public async Task Should_succeed_when_asserting_collection_does_not_contain_an_item_that_is_not_in_the_collection()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).DoesNotContain(4);
        }

        [Fact]
        public async Task Should_succeed_when_asserting_collection_does_not_contain_any_items_that_is_not_in_the_collection()
        {
            // Arrange
            IEnumerable<int> collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).DoesNotContain([4, 5]);
        }

        [Fact]
        public async Task When_collection_contains_an_unexpected_item_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain(1).Because($"because we {"don't"} like it, but found it anyhow"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_injecting_a_null_predicate_into_NotContain_it_should_throw()
        {
            // Arrange
            IEnumerable<int> collection = [];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain(predicate: null));

            // Assert
            await Expect.That(act).ThrowsExactly<ArgumentNullException>();
        }

        [Fact]
        public async Task When_collection_does_contain_an_unexpected_item_matching_a_predicate_it_should_throw()
        {
            // Arrange
            IEnumerable<int> collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain(item => item == 2).Because($"because {2}s are evil"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_does_not_contain_an_unexpected_item_matching_a_predicate_it_should_not_throw()
        {
            // Arrange
            IEnumerable<int> collection = [1, 2, 3];

            // Act / Assert
            await Expect.That(collection).DoesNotContain(item => item == 4);
        }

        [Fact]
        public async Task When_asserting_collection_does_not_contain_item_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain(1).Because("because we want to test the behaviour with a null subject");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_contains_unexpected_item_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain([2]).Because($"because we {"don't"} like them"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_contains_unexpected_items_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain([1, 2, 4]).InAnyOrder().Because($"because we {"don't"} like them"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Assertion_scopes_do_not_affect_chained_calls()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain([1, 2]).And.DoesNotContain([3]);
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_contain_an_empty_collection_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain([]));

            // Assert
            await Expect.That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_asserting_collection_does_not_contain_predicate_item_against_null_collection_it_should_fail()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain(item => item == 4).Because($"we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_does_not_contain_a_list_of_items_against_null_collection_it_should_fail()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).DoesNotContain([1, 2, 4]).Because($"we want to test the failure {"message"}");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_doesnt_contain_values_according_to_predicate_but_collection_is_null_it_should_throw()
        {
            // Arrange
            const IEnumerable<string> strings = null;

            // Act
            Func<Task> act = async ()
                => await Expect.That(strings).DoesNotContain(x => x == "xxx").Because("because we're checking how it reacts to a null subject");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_does_not_contain_the_expected_item_it_should_not_be_enumerated_twice()
        {
            // Arrange
            var collection = new OneTimeEnumerable<int>(1, 2, 3);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).Contains(4));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_collection_contains_the_unexpected_item_it_should_not_be_enumerated_twice()
        {
            // Arrange
            var collection = new OneTimeEnumerable<int>(1, 2, 3);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).DoesNotContain(2));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
