﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]ContainAll specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class ContainAll
    {
        [Fact]
        public async Task When_containment_of_all_strings_in_a_null_collection_is_asserted_it_should_throw_an_argument_exception()
        {
            // Act
            Action act = () => "a".Should().ContainAll(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_an_empty_collection_is_asserted_it_should_throw_an_argument_exception()
        {
            // Act
            Action act = () => "a".Should().ContainAll();

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_a_collection_is_asserted_and_all_strings_are_present_it_should_succeed()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            var testString = $"{red} {green} {yellow}";

            // Act
            Action act = () => testString.Should().ContainAll(red, green, yellow);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_a_collection_is_asserted_and_equivalent_but_not_exact_matches_exist_for_all_it_should_throw()
        {
            // Arrange
            const string redLowerCase = "red";
            const string redUpperCase = "RED";
            const string greenWithoutWhitespace = "green";
            const string greenWithWhitespace = "  green ";
            var testString = $"{redLowerCase} {greenWithoutWhitespace}";

            // Act
            Action act = () => testString.Should().ContainAll(redUpperCase, greenWithWhitespace);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_a_collection_is_asserted_and_none_of_the_strings_are_present_it_should_throw()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            const string blue = "blue";
            var testString = $"{red} {green}";

            // Act
            Action act = () => testString.Should().ContainAll(yellow, blue);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_a_collection_is_asserted_with_reason_and_assertion_fails_then_failure_message_should_contain_reason()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            const string blue = "blue";
            var testString = $"{red} {green}";

            // Act
            Action act = () => testString.Should().ContainAll([yellow, blue], "some {0} reason", "special");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_containment_of_all_strings_in_a_collection_is_asserted_and_only_some_of_the_strings_are_present_it_should_throw()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            const string blue = "blue";
            var testString = $"{red} {green} {yellow}";

            // Act
            Action act = () => testString.Should().ContainAll(red, blue, green);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotContainAll
    {
        [Fact]
        public async Task When_exclusion_of_all_strings_in_null_collection_is_asserted_it_should_throw_an_argument_exception()
        {
            // Act
            Action act = () => "a".Should().NotContainAll(null);

            // Assert
            await That(act).Throws<ArgumentNullException>();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_in_an_empty_collection_is_asserted_it_should_throw_an_argument_exception()
        {
            // Act
            Action act = () => "a".Should().NotContainAll();

            // Assert
            await That(act).Throws<ArgumentException>();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_in_a_collection_is_asserted_and_all_strings_in_collection_are_present_it_should_throw()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            var testString = $"{red} {green} {yellow}";

            // Act
            Action act = () => testString.Should().NotContainAll(red, green, yellow);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_is_asserted_with_reason_and_assertion_fails_then_error_message_contains_reason()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            var testString = $"{red} {green} {yellow}";

            // Act
            Action act = () => testString.Should().NotContainAll([red, green, yellow], "some {0} reason", "special");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_in_a_collection_is_asserted_and_only_some_of_the_strings_in_collection_are_present_it_should_succeed()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            const string purple = "purple";
            var testString = $"{red} {green} {yellow}";

            // Act
            Action act = () => testString.Should().NotContainAll(red, green, yellow, purple);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_in_a_collection_is_asserted_and_none_of_the_strings_in_the_collection_are_present_it_should_succeed()
        {
            // Arrange
            const string red = "red";
            const string green = "green";
            const string yellow = "yellow";
            const string purple = "purple";
            var testString = $"{red} {green}";

            // Act
            Action act = () => testString.Should().NotContainAll(yellow, purple);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_exclusion_of_all_strings_in_a_collection_is_asserted_and_equivalent_but_not_exact_strings_are_present_in_collection_it_should_succeed()
        {
            // Arrange
            const string redWithoutWhitespace = "red";
            const string redWithWhitespace = "  red ";
            const string lowerCaseGreen = "green";
            const string upperCaseGreen = "GREEN";
            var testString = $"{redWithoutWhitespace} {lowerCaseGreen}";

            // Act
            Action act = () => testString.Should().NotContainAll(redWithWhitespace, upperCaseGreen);

            // Assert
            await That(act).DoesNotThrow();
        }
    }
}
