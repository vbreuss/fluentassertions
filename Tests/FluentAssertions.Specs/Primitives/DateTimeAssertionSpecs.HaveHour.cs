using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveHour
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_have_hour_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 23;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_hour_with_different_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_have_hour_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveHour(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveHour
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_hour_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 23;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_hour_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31, 23, 59, 00);
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_not_have_hour_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveHour(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
