#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateOnlyAssertionSpecs
{
    public class BeOneOf
    {
        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateOnly value = new(2016, 12, 20);

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(value.AddDays(1), value.AddMonths(-1)));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_not_one_of_the_specified_values_it_should_throw_with_descriptive_message()
        {
            // Arrange
            DateOnly value = new(2016, 12, 20);

            // Act
            Action action = () =>
Synchronously.Verify(That(value).IsOneOf(new[] { value.AddDays(1), value.AddDays(2) }).Because("because it's true"));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed()
        {
            // Arrange
            DateOnly value = new(2016, 12, 30);

            // Act/Assert
            await That(value).IsOneOf(new DateOnly(2216, 1, 30), new DateOnly(2016, 12, 30));
        }

        [Fact]
        public async Task When_a_null_value_is_not_one_of_the_specified_values_it_should_throw()
        {
            // Arrange
            DateOnly? value = null;

            // Act
            Action action = () => Synchronously.Verify(That(value).IsOneOf(new DateOnly(2216, 1, 30), new DateOnly(1116, 4, 10)));

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_value_is_one_of_the_specified_values_it_should_succeed_when_dateonly_is_null()
        {
            // Arrange
            DateOnly? value = null;

            // Act/Assert
            await That(value).IsOneOf(new DateOnly(2216, 1, 30), null);
        }
    }
}

#endif
