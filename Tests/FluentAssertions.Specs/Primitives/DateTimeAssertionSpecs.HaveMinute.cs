using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveMinute
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_have_minutes_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 59;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_minutes_with_different_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 58;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_have_minute_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveMinute(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveMinute
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_minutes_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 59;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_minutes_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 58;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_not_have_minute_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveMinute(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
