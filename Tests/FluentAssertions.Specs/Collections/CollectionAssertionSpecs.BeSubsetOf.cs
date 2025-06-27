using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeSubsetOf specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeSubsetOf
    {
        [Fact]
        public async Task When_collection_is_subset_of_a_specified_collection_it_should_not_throw()
        {
            // Arrange
            ImmutableArray<int> subset = [1, 2];
            int[] superset = [1, 3, 2];

            // Act / Assert
            await Expect.That(subset).IsContainedIn(superset).InAnyOrder();
        }

        [Fact]
        public async Task When_collection_is_not_a_subset_of_another_it_should_throw_with_the_reason()
        {
            // Arrange
            int[] subset = [1, 2, 3, 6];
            int[] superset = [1, 2, 4, 5];

            // Act
            Action act = () => Synchronously.Verify(That(subset).IsContainedIn(superset).Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_empty_collection_is_tested_against_a_superset_it_should_succeed()
        {
            // Arrange
            int[] subset = [];
            int[] superset = [1, 2, 4, 5];

            // Act
            Action act = () => Synchronously.Verify(That(subset).IsContainedIn(superset));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_subset_is_tested_against_a_null_superset_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            int[] subset = [1, 2, 3];
            int[] superset = null;

            // Act
            Action act = () => Synchronously.Verify(That(subset).IsContainedIn(superset));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("*<null>*").AsWildcard();
        }

        [Fact]
        public async Task When_a_set_is_expected_to_be_not_a_subset_it_should_succeed()
        {
            // Arrange
            int[] subject = [1, 2, 4];
            int[] otherSet = [1, 2, 3];

            // Act / Assert
            await Expect.That(subject).IsNotContainedIn(otherSet).InAnyOrder();
        }
    }

    public class NotBeSubsetOf
    {
        [Fact]
        public async Task When_an_empty_set_is_not_supposed_to_be_a_subset_of_another_set_it_should_throw()
        {
            // Arrange
            int[] subject = [];
            int[] otherSet = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotContainedIn(otherSet).InAnyOrder());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_when_asserting_collection_is_not_subset_of_a_superset_collection()
        {
            // Arrange
            int[] subject = [1, 2];
            int[] otherSet = [1, 2, 3];

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotContainedIn(otherSet).InAnyOrder().Because($"because I'm {"mistaken"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_be_subset_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection = null;
            int[] collection1 = [1, 2, 3];

            // Act
            Func<Task> act = async () =>
            {
                using var _ = new AssertionScope();
                await That(collection).IsContainedIn(collection1).Because("because we want to test the behaviour with a null subject");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_be_subset_against_same_collection_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];
            var collection1 = collection;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(collection).IsNotContainedIn(collection1).InAnyOrder().Because("because we want to test the behaviour with same objects"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_not_be_subset_against_null_collection_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await Expect.That(collection).IsNotContainedIn([1, 2, 3]).InAnyOrder().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
