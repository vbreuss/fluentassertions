using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveMonth
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_month_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_a_month_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_have_month_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveMonth
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_month_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_a_month_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_not_have_month_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
