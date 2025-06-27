using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]BeNull specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class BeNull
    {
        [Fact]
        public async Task When_collection_is_expected_to_be_null_and_it_is_it_should_not_throw()
        {
            // Arrange
            IEnumerable<string> someCollection = null;

            // Act / Assert
            await That(someCollection).IsNull();
        }

        [Fact]
        public async Task When_collection_is_expected_to_be_null_and_it_isnt_it_should_throw()
        {
            // Arrange
            IEnumerable<string> someCollection = new string[0];

            // Act
            Action act = () => Synchronously.Verify(That(someCollection).IsNull().Because($"because {"null"} is valid"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNull
    {
        [Fact]
        public async Task When_collection_is_not_expected_to_be_null_and_it_isnt_it_should_not_throw()
        {
            // Arrange
            IEnumerable<string> someCollection = new string[0];

            // Act / Assert
            await That(someCollection).IsNotNull();
        }

        [Fact]
        public async Task When_collection_is_not_expected_to_be_null_and_it_is_it_should_throw()
        {
            // Arrange
            IEnumerable<string> someCollection = null;

            // Act
            Action act = () => Synchronously.Verify(That(someCollection).IsNotNull().Because($"because {"someCollection"} should not"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
