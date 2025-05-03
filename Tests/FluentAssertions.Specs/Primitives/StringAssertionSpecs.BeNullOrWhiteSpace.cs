using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The [Not]BeNullOrWhiteSpace specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeNullOrWhitespace
    {
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n\r")]
        [Theory]
        public async Task When_correctly_asserting_null_or_whitespace_it_should_not_throw(string actual)
        {
            // Assert
            await Expect.That(actual).IsNullOrWhiteSpace();
        }

        [InlineData("a")]
        [InlineData(" a ")]
        [Theory]
        public async Task When_correctly_asserting_not_null_or_whitespace_it_should_not_throw(string actual)
        {
            // Assert
            await Expect.That(actual).IsNotNullOrWhiteSpace();
        }

        [Fact]
        public async Task When_a_valid_string_is_expected_to_be_null_or_whitespace_it_should_throw()
        {
            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(" abc  ").IsNullOrWhiteSpace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeNullOrWhitespace
    {
        [Fact]
        public async Task When_a_null_string_is_expected_to_not_be_null_or_whitespace_it_should_throw()
        {
            // Arrange
            string nullString = null;

            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullString).IsNotNullOrWhiteSpace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_an_empty_string_is_expected_to_not_be_null_or_whitespace_it_should_throw()
        {
            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That("").IsNotNullOrWhiteSpace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_whitespace_string_is_expected_to_not_be_null_or_whitespace_it_should_throw()
        {
            // Act
            Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That("   ").IsNotNullOrWhiteSpace());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
