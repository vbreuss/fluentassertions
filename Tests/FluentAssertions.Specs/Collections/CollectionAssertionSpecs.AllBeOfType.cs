using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Specialized;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The AllBeOfType specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class AllBeOfType
    {
        [Fact]
        public async Task When_the_types_in_a_collection_is_matched_against_a_null_type_exactly_it_should_throw()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().AreExactly(null));

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task All_items_in_an_empty_collection_are_of_a_generic_type()
        {
            // Arrange
            int[] collection = [];

            // Act / Assert
            await That(collection).All().AreExactly<int>();
        }

        [Fact]
        public async Task All_items_in_an_empty_collection_are_of_a_type()
        {
            // Arrange
            int[] collection = [];

            // Act / Assert
            await That(collection).All().AreExactly(typeof(int));
        }

        [Fact]
        public async Task When_collection_is_null_then_all_be_of_type_should_fail()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).All().AreExactly(typeof(object)).Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_all_of_the_types_in_a_collection_match_expected_type_exactly_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().AreExactly(typeof(int));
        }

        [Fact]
        public async Task When_all_of_the_types_in_a_collection_match_expected_generic_type_exactly_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().AreExactly<int>();
        }

        [Fact]
        public async Task When_matching_a_collection_against_an_exact_type_it_should_return_the_casted_items()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().AreExactly<int>();
        }

        [Fact]
        public async Task When_one_of_the_types_does_not_match_exactly_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { new Exception(), new ArgumentException("foo") };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().AreExactly(typeof(Exception)).Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_one_of_the_types_does_not_match_exactly_the_generic_type_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { new Exception(), new ArgumentException("foo") };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().AreExactly<Exception>().Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/586")]
        public async Task When_one_of_the_elements_is_null_for_an_exact_match_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { 1, null, 3 };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().AreExactly<int>().Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to be \"System.Int32\" because they are of different type, but found a null element.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_of_types_match_expected_type_exactly_it_should_succeed()
        {
            // Arrange
            Type[] collection = [typeof(int), typeof(int), typeof(int)];

            // Act / Assert
            await That(collection).All().AreExactly<int>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_of_types_and_objects_match_type_exactly_it_should_succeed()
        {
            // Arrange
            var collection = new object[] { typeof(ArgumentException), new ArgumentException("foo") };

            // Act / Assert
            await That(collection).All().AreExactly<ArgumentException>();
        }

        [Fact]
        public async Task When_collection_of_types_and_objects_do_not_match_type_exactly_it_should_throw()
        {
            // Arrange
            var collection = new object[] { typeof(Exception), new ArgumentException("foo") };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().AreExactly<ArgumentException>());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_collection_is_null_then_all_be_of_typeOfT_should_fail()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).All().AreExactly<object>().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
