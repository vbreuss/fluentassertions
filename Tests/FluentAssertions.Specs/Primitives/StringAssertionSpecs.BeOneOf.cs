using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

/// <content>
/// The BeOneOf specs.
/// </content>
public partial class StringAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            string value = "abc";

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf("def", "xyz"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            string value = "abc";

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf(["def", "xyz"], "because those are the valid values"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            string value = "abc";

            // Act
            Action action = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(value).IsOneOf("abc", "def", "xyz"));

            // Assert
            await Expect.That(action).DoesNotThrow();
        }
    }
}
