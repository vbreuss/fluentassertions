using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The AllBeAssignableTo specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class AllBeAssignableTo
    {
        [Fact]
        public async Task When_the_types_in_a_collection_is_matched_against_a_null_type_it_should_throw()
        {
            // Arrange
            int[] collection = [];

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().Are(null));

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task All_items_in_an_empty_collection_are_assignable_to_a_generic_type()
        {
            // Arrange
            int[] collection = [];

            // Act / Assert
            await That(collection).All().Are<int>();
        }

        [Fact]
        public async Task When_collection_is_null_then_all_be_assignable_to_should_fail()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).All().Are(typeof(object)).Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task All_items_in_an_empty_collection_are_assignable_to_a_type()
        {
            // Arrange
            int[] collection = [];

            // Act / Assert
            await That(collection).All().Are(typeof(int));
        }

        [Fact]
        public async Task When_all_of_the_types_in_a_collection_match_expected_type_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().Are(typeof(int));
        }

        [Fact]
        public async Task When_all_of_the_types_in_a_collection_match_expected_generic_type_it_should_succeed()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().Are<int>();
        }

        [Fact]
        public async Task When_matching_a_collection_against_a_type_it_should_return_the_casted_items()
        {
            // Arrange
            int[] collection = [1, 2, 3];

            // Act / Assert
            await That(collection).All().Are<int>();
        }

        [Fact]
        public async Task When_all_of_the_types_in_a_collection_match_the_type_or_subtype_it_should_succeed()
        {
            // Arrange
            var collection = new object[] { new Exception(), new ArgumentException("foo") };

            // Act / Assert
            await That(collection).All().Are<Exception>();
        }

        [Fact]
        public async Task When_one_of_the_types_does_not_match_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { 1, "2", 3 };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().Are(typeof(int)).Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_one_of_the_types_does_not_match_the_generic_type_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { 1, "2", 3 };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().Are<int>().Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/586")]
        public async Task When_one_of_the_elements_is_null_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            var collection = new object[] { 1, null, 3 };

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().Are<int>().Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to be \"System.Int32\" because they are of different type, but found a null element.").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_is_of_matching_types_it_should_succeed()
        {
            // Arrange
            object[] collection = [new Exception(), typeof(ArgumentException)];

            // Act / Assert
            await That(collection).All().Are<Exception>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_of_types_contains_one_type_that_does_not_match_it_should_throw_with_a_clear_explanation()
        {
            // Arrange
            Type[] collection = [typeof(int), typeof(string), typeof(int)];

            // Act
            Action act = () => Synchronously.Verify(That(collection).All().Are<int>().Because("because they are of different type"));

            // Assert
            await That(act).Throws<XunitException>().WithMessage("Expected type to be \"System.Int32\" because they are of different type, but found \"[System.Int32, System.String, System.Int32]\".").AsWildcard();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_of_types_and_objects_are_all_of_matching_types_it_should_succeed()
        {
            // Arrange
            var collection = new object[] { typeof(int), 2, typeof(int) };

            // Act / Assert
            await That(collection).All().Are<int>();
        }

        [Fact(Skip = "https://github.com/aweXpect/aweXpect/issues/573")]
        public async Task When_collection_of_different_types_and_objects_are_all_assignable_to_type_it_should_succeed()
        {
            // Arrange
            var collection = new object[] { typeof(Exception), new ArgumentException("foo") };

            // Act / Assert
            await That(collection).All().Are<Exception>();
        }

        [Fact]
        public async Task When_collection_is_null_then_all_be_assignable_toOfT_should_fail()
        {
            // Arrange
            IEnumerable<object> collection = null;

            // Act
            Func<Task> act = async () =>
            {
                await That(collection).All().Are<object>().Because($"we want to test the failure {"message"}");
            };

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
