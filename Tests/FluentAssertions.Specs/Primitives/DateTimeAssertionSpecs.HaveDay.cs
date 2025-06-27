using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveDay
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_have_day_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_day_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_have_day_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveDay
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_day_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_day_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_not_have_day_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
