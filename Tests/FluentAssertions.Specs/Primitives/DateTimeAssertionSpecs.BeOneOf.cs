using System;
using aweXpect;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateTime value = new(2016, 12, 30, 23, 58, 57);

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(value + 1.Days(), value + 1.Milliseconds()));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            DateTime value = new(2016, 12, 30, 23, 58, 57);

            // Act
            Action action = () =>
Synchronously.Verify(That(value).IsOneOf(new[] { value + 1.Days(), value + 1.Milliseconds() }).Because("it's true"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            DateTime value = new(2016, 12, 30, 23, 58, 57);

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTime(2216, 1, 30, 0, 5, 7), new DateTime(2016, 12, 30, 23, 58, 57), new DateTime(2012, 3, 3)));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_null_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateTime? value = null;

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTime(2216, 1, 30, 0, 5, 7), new DateTime(1116, 4, 10, 2, 45, 7)));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed_when_datetime_is_null()
        {
            // Arrange
            DateTime? value = null;

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTime(2216, 1, 30, 0, 5, 7), null));

            // Assert
            await That(action).DoesNotThrow();
        }
    }
}
