using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeNullOrEmpty specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeNullOrEmpty
    {
        [Fact]
        public async Task When_a_null_string_is_expected_to_be_null_or_empty_it_should_not_throw()
        {
            // Arrange
            string str = null;

            // Act / Assert
            await That(str).IsNullOrEmpty();
        }

        [Fact]
        public async Task When_an_empty_string_is_expected_to_be_null_or_empty_it_should_not_throw()
        {
            // Arrange
            string str = "";

            // Act / Assert
            await That(str).IsNullOrEmpty();
        }

        [Fact]
        public async Task When_a_valid_string_is_expected_to_be_null_or_empty_it_should_throw()
        {
            // Arrange
            string str = "hello";

            // Act
            Action act = () => Synchronously.Verify(That(str).IsNullOrEmpty().Because($"it was not initialized {"yet"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeNullOrEmpty
    {
        [Fact]
        public async Task When_a_valid_string_is_expected_to_be_not_null_or_empty_it_should_not_throw()
        {
            // Arrange
            string str = "Hello World";

            // Act / Assert
            await That(str).IsNotNullOrEmpty();
        }

        [Fact]
        public async Task When_an_empty_string_is_not_expected_to_be_null_or_empty_it_should_throw()
        {
            // Arrange
            string str = "";

            // Act
            Action act = () => Synchronously.Verify(That(str).IsNotNullOrEmpty().Because($"a valid string is expected for {"str"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_null_string_is_not_expected_to_be_null_or_empty_it_should_throw()
        {
            // Arrange
            string str = null;

            // Act
            Action act = () => Synchronously.Verify(That(str).IsNotNullOrEmpty().Because($"a valid string is expected for {"str"}"));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
