using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeUpperCased specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeUpperCased
    {
        [Fact]
        public void Upper_case_characters_are_okay()
        {
            // Arrange
            string actual = "ABC";

            // Act / Assert
            actual.Should().BeUpperCased();
        }

        [Fact]
        public void The_empty_string_is_okay()
        {
            // Arrange
            string actual = "";

            // Act / Assert
            actual.Should().BeUpperCased();
        }

        [Fact]
        public async Task A_lower_case_string_is_not_okay()
        {
            // Arrange
            string actual = "abc";

            // Act
            Action act = () => actual.Should().BeUpperCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Upper_case_and_caseless_characters_are_ok()
        {
            // Arrange
            string actual = "A1!";

            // Act / Assert
            actual.Should().BeUpperCased();
        }

        [Fact]
        public void Caseless_characters_are_okay()
        {
            // Arrange
            string actual = "1!漢字";

            // Act / Assert
            actual.Should().BeUpperCased();
        }

        [Fact]
        public async Task The_assertion_fails_with_a_descriptive_message()
        {
            // Arrange
            string actual = "abc";

            // Act
            Action act = () => actual.Should().BeUpperCased("because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_null_string_is_not_okay()
        {
            // Arrange
            string nullString = null;

            // Act
            Action act = () => nullString.Should().BeUpperCased("because strings should never be {0}", "null");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeUpperCased
    {
        [Fact]
        public void A_mixed_case_string_is_okay()
        {
            // Arrange
            string actual = "aBc";

            // Act / Assert
            actual.Should().NotBeUpperCased();
        }

        [Fact]
        public void The_null_string_is_okay()
        {
            // Arrange
            string actual = null;

            // Act / Assert
            actual.Should().NotBeUpperCased();
        }

        [Fact]
        public void The_empty_string_is_okay()
        {
            // Arrange
            string actual = "";

            // Act / Assert
            actual.Should().NotBeUpperCased();
        }

        [Fact]
        public async Task A_string_of_all_upper_case_characters_is_not_okay()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => actual.Should().NotBeUpperCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Upper_case_characters_with_lower_case_characters_are_okay()
        {
            // Arrange
            string actual = "Ab1!";

            // Act / Assert
            actual.Should().NotBeUpperCased();
        }

        [Fact]
        public async Task All_cased_characters_being_upper_case_is_not_okay()
        {
            // Arrange
            string actual = "A1B!";

            // Act
            Action act = () => actual.Should().NotBeUpperCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Caseless_characters_are_okay()
        {
            // Arrange
            string actual = "1!漢字";

            // Act / Assert
            actual.Should().NotBeUpperCased();
        }

        [Fact]
        public async Task The_assertion_fails_with_a_descriptive_message()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => actual.Should().NotBeUpperCased("because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
