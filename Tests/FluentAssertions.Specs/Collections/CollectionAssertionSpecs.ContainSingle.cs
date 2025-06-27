using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The ContainSingle specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    [Fact]
    public async Task When_injecting_a_null_predicate_into_ContainSingle_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(predicate: null));

        // Assert
        await That(act).ThrowsExactly<ArgumentNullException>();
    }

    [Fact]
    public async Task When_a_collection_contains_a_single_item_matching_a_predicate_it_should_succeed()
    {
        // Arrange
        IEnumerable<int> collection = [1, 2, 3];
        Func<int, bool> expression = item => item == 2;

        // Act / Assert
        await That(collection).HasSingle().Matching(expression);
    }

    [Fact]
    public async Task When_asserting_an_empty_collection_contains_a_single_item_matching_a_predicate_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [];
        Func<int, bool> expression = item => item == 2;

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(expression));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_null_collection_contains_a_single_item_matching_a_predicate_it_should_throw()
    {
        // Arrange
        const IEnumerable<int> collection = null;
        Func<int, bool> expression = item => item == 2;

        // Act
        Func<Task> act = async () =>
        {
            await That(collection).HasSingle().Matching(expression);
        };

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_non_empty_collection_does_not_contain_a_single_item_matching_a_predicate_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [1, 3];
        Func<int, bool> expression = item => item == 2;

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(expression));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_non_empty_collection_contains_more_than_a_single_item_matching_a_predicate_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [1, 2, 2, 2, 3];
        Func<int, bool> expression = item => item == 2;

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(expression));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_single_item_matching_a_predicate_is_found_it_should_allow_continuation()
    {
        // Arrange
        IEnumerable<int> collection = [1, 2, 3];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(item => item == 2).Which.IsGreaterThan(4));

        // Assert
        await That(act).Throws<XunitException>().WithMessage("*item => item == 2*greater than 4*").AsWildcard();
    }

    [Fact]
    public async Task Chained_assertions_are_never_called_when_the_initial_assertion_failed()
    {
        // Arrange
        IEnumerable<int> collection = [1, 2, 3];

        // Act
        Func<Task> act = async () =>
        {
            await That(collection).HasSingle().Matching(item => item == 4);
        };

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_single_item_contains_brackets_it_should_format_them_properly()
    {
        // Arrange
        IEnumerable<string> collection = [""];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(item => item == "{123}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_single_item_contains_string_interpolation_it_should_format_brackets_properly()
    {
        // Arrange
        IEnumerable<string> collection = [""];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(item => item == $"{123}"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_a_collection_contains_a_single_item_it_should_succeed()
    {
        // Arrange
        IEnumerable<int> collection = [1];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle());

        // Assert
        await That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_an_empty_collection_contains_a_single_item_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Because("more is not allowed"));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_a_null_collection_contains_a_single_item_it_should_throw()
    {
        // Arrange
        const IEnumerable<int> collection = null;

        // Act
        Func<Task> act = async () =>
        {
            await That(collection).HasSingle().Because("more is not allowed");
        };

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/591")]
    public async Task When_non_empty_collection_does_not_contain_a_single_item_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [1, 3];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle());

        // Assert
        const string expectedMessage = "1, 3";

        await That(act).Throws<XunitException>().WithMessage(expectedMessage).AsWildcard();
    }

    [Fact]
    public async Task When_non_empty_collection_contains_more_than_a_single_item_it_should_throw()
    {
        // Arrange
        IEnumerable<int> collection = [1, 2];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle());

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_single_item_is_found_it_should_allow_continuation()
    {
        // Arrange
        IEnumerable<int> collection = [3];

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Which.IsGreaterThan(4));

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_collection_is_IEnumerable_it_should_be_evaluated_only_once_with_predicate()
    {
        // Arrange
        IEnumerable<int> collection = new OneTimeEnumerable<int>(1);

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle().Matching(_ => true));

        // Assert
        await That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_collection_is_IEnumerable_it_should_be_evaluated_only_once()
    {
        // Arrange
        IEnumerable<int> collection = new OneTimeEnumerable<int>(1);

        // Act
        Action act = () => Synchronously.Verify(That(collection).HasSingle());

        // Assert
        await That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_an_assertion_fails_on_ContainSingle_succeeding_message_should_be_included()
    {
        // Act

        Func<Task> act = async () =>
        {
            var values = new List<int>();
            await That(values).HasSingle();
            await That(values).HasSingle();
        };

        // Assert
        await That(act).Throws<XunitException>();
    }
}
