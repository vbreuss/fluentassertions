using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeEmpty specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeEmpty
    {
        [Fact]
        public async Task When_collection_is_empty_as_expected_it_should_not_throw()
        {
            // Arrange
            int[] collection = [];

            // Act / Assert
            await That(collection).IsEmpty();
        }

        [Fact]
        public async Task When_collection_is_not_empty_unexpectedly_it_should_throw()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsEmpty().Because("that's what we expect"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_with_items_is_not_empty_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).IsNotEmpty();
        }

        [Fact]
        public async Task When_asserting_collection_with_items_is_not_empty_it_should_enumerate_the_collection_only_once()
        {
            // Arrange
            var trackingEnumerable = new TrackingTestEnumerable(1, 2, 3);

            // Act
            await That(trackingEnumerable).IsNotEmpty();

            // Assert
            await That(trackingEnumerable.Enumerator.LoopCount).IsEqualTo(1);
        }

        [Fact]
        public async Task When_asserting_collection_without_items_is_not_empty_it_should_fail()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotEmpty());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_without_items_is_not_empty_it_should_fail_with_descriptive_message_()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotEmpty().Because($"because we want to test the failure {"message"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_be_empty_but_collection_is_null_it_should_throw()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).IsEmpty().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_be_empty_it_should_enumerate_only_once()
        {
            // Arrange
            var collection = new CountingGenericEnumerable<int>([]);

            // Act
            await That(collection).IsEmpty();

            // Assert
            await That(collection.GetEnumeratorCallCount).IsEqualTo(1);
        }

        [Fact]
        public async Task When_asserting_non_empty_collection_is_empty_it_should_enumerate_only_once()
        {
            // Arrange
            var collection = new CountingGenericEnumerable<int>([1, 2, 3]);

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsEmpty());

            // Assert
            await That(act).Throws<XunitException>();
            await That(collection.GetEnumeratorCallCount).IsEqualTo(1);
        }

        [Fact]
        public async Task When_asserting_collection_to_not_be_empty_but_collection_is_null_it_should_throw()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).IsNotEmpty().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_an_infinite_collection_to_be_empty_it_should_throw_correctly()
        {
            // Arrange
            var collection = new InfiniteEnumerable();

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsEmpty());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeEmpty
    {
        [Fact]
        public async Task When_asserting_collection_to_be_not_empty_but_collection_is_null_it_should_throw()
        {
            // Arrange
            int[] collection = null;

            // Act
            Action act = () => Synchronously.Verify(That(collection).IsNotEmpty().Because("because we want to test the behaviour with a null subject"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_collection_to_be_not_empty_it_should_enumerate_only_once()
        {
            // Arrange
            var collection = new CountingGenericEnumerable<int>([42]);

            // Act
            await That(collection).IsNotEmpty();

            // Assert
            await That(collection.GetEnumeratorCallCount).IsEqualTo(1);
        }
    }

    private sealed class InfiniteEnumerable : IEnumerable<object>
    {
        public IEnumerator<object> GetEnumerator() => new InfiniteEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private sealed class InfiniteEnumerator : IEnumerator<object>
    {
        public bool MoveNext() => true;

        public void Reset() { }

        public object Current => new();

        object IEnumerator.Current => Current;

        public void Dispose() { }
    }
}
