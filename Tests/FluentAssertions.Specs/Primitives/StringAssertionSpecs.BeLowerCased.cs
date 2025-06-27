﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeLowerCased specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeLowerCased
    {
        [Fact]
        public void Lower_case_characters_are_okay()
        {
            // Arrange
            string actual = "abc";

            // Act / Assert
            actual.Should().BeLowerCased();
        }

        [Fact]
        public void The_empty_string_is_okay()
        {
            // Arrange
            string actual = "";

            // Act / Assert
            actual.Should().BeLowerCased();
        }

        [Fact]
        public async Task Upper_case_characters_are_not_okay()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => actual.Should().BeLowerCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_mixed_case_string_is_not_okay()
        {
            // Arrange
            string actual = "AbC";

            // Act
            Action act = () => actual.Should().BeLowerCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Lower_case_and_caseless_characters_are_okay()
        {
            // Arrange
            string actual = "a1!";

            // Act / Assert
            actual.Should().BeLowerCased();
        }

        [Fact]
        public void Caseless_characters_are_okay()
        {
            // Arrange
            string actual = "1!漢字";

            // Act / Assert
            actual.Should().BeLowerCased();
        }

        [Fact]
        public async Task The_assertion_fails_with_a_descriptive_message()
        {
            // Arrange
            string actual = "ABC";

            // Act
            Action act = () => actual.Should().BeLowerCased("because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task The_null_string_is_not_okay()
        {
            // Arrange
            string nullString = null;

            // Act
            Action act = () => nullString.Should().BeLowerCased("because strings should never be {0}", "null");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeLowerCased
    {
        [Fact]
        public void A_mixed_case_string_is_okay()
        {
            // Arrange
            string actual = "AbC";

            // Act / Assert
            actual.Should().NotBeLowerCased();
        }

        [Fact]
        public void The_null_string_is_okay()
        {
            // Arrange
            string actual = null;

            // Act / Assert
            actual.Should().NotBeLowerCased();
        }

        [Fact]
        public void The_empty_string_is_okay()
        {
            // Arrange
            string actual = "";

            // Act / Assert
            actual.Should().NotBeLowerCased();
        }

        [Fact]
        public async Task A_lower_case_string_is_not_okay()
        {
            // Arrange
            string actual = "abc";

            // Act
            Action act = () => actual.Should().NotBeLowerCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Lower_case_characters_with_upper_case_characters_are_okay()
        {
            // Arrange
            string actual = "Ab1!";

            // Act / Assert
            actual.Should().NotBeLowerCased();
        }

        [Fact]
        public async Task All_cased_characters_being_lower_case_is_not_okay()
        {
            // Arrange
            string actual = "a1b!";

            // Act
            Action act = () => actual.Should().NotBeLowerCased();

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Caseless_characters_are_okay()
        {
            // Arrange
            string actual = "1!漢字";

            // Act / Assert
            actual.Should().NotBeLowerCased();
        }

        [Fact]
        public async Task The_assertion_fails_with_a_descriptive_message()
        {
            // Arrange
            string actual = "abc";

            // Act
            Action act = () => actual.Should().NotBeLowerCased("because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
