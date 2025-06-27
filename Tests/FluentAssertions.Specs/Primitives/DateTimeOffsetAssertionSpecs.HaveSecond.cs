using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveSecond
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_seconds_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 0;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_seconds_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 1;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_have_second_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveSecond(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveSecond
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_seconds_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 0;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_seconds_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            int expectation = 1;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_not_have_second_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveSecond(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
