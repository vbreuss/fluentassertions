using System;
using System.Collections.Immutable;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeEquivalentTo specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeEquivalentTo
    {
        [Fact]
        public async Task When_two_collections_contain_the_same_elements_it_should_treat_them_as_equivalent()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [3, 1, 2];

            // Act / Assert
            await That(collection1).IsEqualTo(collection2).InAnyOrder();
        }

        [Fact]
        public async Task When_a_collection_contains_same_elements_it_should_treat_it_as_equivalent()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).IsEqualTo([3, 1, 2]).InAnyOrder();
        }

        [Fact]
        public async Task When_character_collections_are_equivalent_it_should_not_throw()
        {
            // Arrange
            char[] list1 = "abc123ab".ToCharArray();
            char[] list2 = "abc123ab".ToCharArray();

            // Act / Assert
            await That(list1).IsEqualTo(list2);
        }

        [Fact]
        public async Task When_collections_are_not_equivalent_it_should_throw()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [1, 2];

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsEqualTo(collection2).InAnyOrder().Because($"we treat {"all"} alike"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collections_with_duplicates_are_not_equivalent_it_should_throw()
        {
            // Arrange
            int[] collection1 = [1, 2, 3, 1];
            int[] collection2 = [1, 2, 3, 3];

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsEqualTo(collection2).InAnyOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_testing_for_equivalence_against_empty_collection_it_should_throw()
        {
            // Arrange
            int[] subject = [1, 2, 3];
            int[] otherCollection = [];

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsEqualTo(otherCollection).InAnyOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_two_collections_are_both_empty_it_should_treat_them_as_equivalent()
        {
            // Arrange
            int[] subject = [];
            int[] otherCollection = [];

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsEqualTo(otherCollection));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_testing_for_equivalence_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsEqualTo(collection2));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collections_to_be_equivalent_but_subject_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;
            int[] collection1 = [1, 2, 3];

            // Act
            Action act =
                () => Synchronously.Verify(That(collection).IsEqualTo(collection1).Because("because we want to test the behaviour with a null subject"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Default_immutable_arrays_should_be_equivalent()
        {
            // Arrange
            ImmutableArray<string> collection = default;
            ImmutableArray<string> collection1 = default;

            // Act / Assert
            await That(collection).IsEqualTo(collection1);
        }

        [Fact]
        public async Task Default_immutable_lists_should_be_equivalent()
        {
            // Arrange
            ImmutableList<string> collection = default;
            ImmutableList<string> collection1 = default;

            // Act / Assert
            await That(collection).IsEqualTo(collection1);
        }

        [Fact]
        public async Task Can_ignore_casing_while_comparing_collections_of_strings()
        {
            // Arrange
            var actual = new[] { "first", "test", "last" };
            var expectation = new[] { "first", "TEST", "last" };

            // Act / Assert
            await That(actual).IsEqualTo(expectation).IgnoringCase();
        }

        [Fact]
        public async Task Can_ignore_leading_whitespace_while_comparing_collections_of_strings()
        {
            // Arrange
            var actual = new[] { "first", "  test", "last" };
            var expectation = new[] { "first", "test", "last" };

            // Act / Assert
            await That(actual).IsEqualTo(expectation).IgnoringLeadingWhiteSpace();
        }

        [Fact]
        public async Task Can_ignore_trailing_whitespace_while_comparing_collections_of_strings()
        {
            // Arrange
            var actual = new[] { "first", "test  ", "last" };
            var expectation = new[] { "first", "test", "last" };

            // Act / Assert
            await That(actual).IsEqualTo(expectation).IgnoringTrailingWhiteSpace();
        }

        [Fact]
        public async Task Can_ignore_newline_style_while_comparing_collections_of_strings()
        {
            // Arrange
            var actual = new[] { "first", "A\nB\r\nC", "last" };
            var expectation = new[] { "first", "A\r\nB\nC", "last" };

            // Act / Assert
            await That(actual).IsEqualTo(expectation).IgnoringNewlineStyle();
        }
    }

    public class NotBeEquivalentTo
    {
        [Fact]
        public async Task When_collection_is_not_equivalent_to_another_smaller_collection_it_should_succeed()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [3, 1];

            // Act / Assert
            await That(collection1).IsNotEqualTo(collection2);
        }

        [Fact]
        public async Task When_large_collection_is_equivalent_to_another_equally_size_collection_it_should_throw()
        {
            // Arrange
            var collection1 = Enumerable.Repeat(1, 10000);
            var collection2 = Enumerable.Repeat(1, 10000);

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsNotEqualTo(collection2));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_is_not_equivalent_to_another_equally_sized_collection_it_should_succeed()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [3, 1, 4];

            // Act / Assert
            await That(collection1).IsNotEqualTo(collection2);
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/595")]
        public async Task When_collections_are_unexpectedly_equivalent_it_should_throw()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [3, 1, 2];

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsNotEqualTo(collection2));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected collection1 {1, 2, 3} not*equivalent*{3, 1, 2}.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_asserting_collections_not_to_be_equivalent_but_subject_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] actual = null;
            int[] expectation = [1, 2, 3];

            // Act

            Func<Task> act = async () =>
            {
                await That(actual).IsNotEqualTo(expectation).Because("because we want to test the behaviour with a null subject");
            };

            // Assert
            await That(act).Throws<XunitException>().WithMessage("*be equivalent because we want to test the behaviour with a null subject, but found <null>*").AsWildcard();
        }

        [Fact]
        public async Task When_non_empty_collection_is_not_expected_to_be_equivalent_to_an_empty_collection_it_should_succeed()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsNotEqualTo(collection2));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact(Skip = "TODO VAB")]
        public async Task When_testing_collections_not_to_be_equivalent_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection1 = [1, 2, 3];
            int[] collection2 = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection1).IsNotEqualTo(collection2));

            // Assert
            await That(act).Throws<ArgumentNullException>().WithMessage("Cannot verify inequivalence against a <null> collection.*").AsWildcard();
        }

        [Fact(Skip = "TODO VAB")]
        public async Task When_testing_collections_not_to_be_equivalent_against_same_collection_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            var collection1 = collection;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotEqualTo(collection1).Because("because we want to test the behaviour with same objects"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("*not to be equivalent*because we want to test the behaviour with same objects*but they both reference the same object.").AsWildcard();
        }

        [Fact]
        public async Task Default_immutable_array_should_not_be_equivalent_to_initialized_immutable_array()
        {
            // Arrange
            ImmutableArray<string> subject = default;
            ImmutableArray<string> expectation = ImmutableArray.Create("a", "b", "c");

            // Act / Assert
            await That(subject).IsNotEqualTo(expectation);
        }

        [Fact]
        public async Task Immutable_array_should_not_be_equivalent_to_default_immutable_array()
        {
            // Arrange
            ImmutableArray<string> collection = ImmutableArray.Create("a", "b", "c");
            ImmutableArray<string> collection1 = default;

            // Act / Assert
            await That(collection).IsNotEqualTo(collection1);
        }
    }
}
