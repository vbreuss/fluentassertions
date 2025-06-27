using System;
using System.Collections.Generic;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(value + 1.Days(), value + 4.Hours()));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_param_values_follow_up_assertions_works()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());

            // Act / Assert
            await That(value).IsOneOf(value, value + 1.Hours());
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_nullable_params_values_follow_up_assertions_works()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());

            // Act / Assert
            await That(value).IsOneOf(null, value, value + 1.Hours());
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_enumerable_values_follow_up_assertions_works()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());
            IEnumerable<DateTimeOffset> expected = [value, value + 1.Hours()];

            // Act / Assert
            await That(value).IsOneOf(expected);
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_nullable_enumerable_follow_up_assertions_works()
        {
            // Arrange
            var value = new DateTimeOffset(31.December(2016), 1.Hours());
            IEnumerable<DateTimeOffset?> expected = [null, value, value + 1.Hours()];

            // Act / Assert
            await That(value).IsOneOf(expected);
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            DateTimeOffset value = 31.December(2016).WithOffset(1.Hours());

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new[] { value + 1.Days(), value + 2.Days() }).Because("because it's true"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            DateTimeOffset value = new(2016, 12, 30, 23, 58, 57, TimeSpan.FromHours(4));

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.FromHours(2)), new DateTimeOffset(2016, 12, 30, 23, 58, 57, TimeSpan.FromHours(4))));

            // Assert
            await That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_null_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateTimeOffset? value = null;

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.FromHours(1)), new DateTimeOffset(2016, 2, 10, 2, 45, 7, TimeSpan.FromHours(2))));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed_when_datetimeoffset_is_null()
        {
            // Arrange
            DateTimeOffset? value = null;

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateTimeOffset(2216, 1, 30, 0, 5, 7, TimeSpan.Zero), null));

            // Assert
            await That(action).DoesNotThrow();
        }
    }
}
