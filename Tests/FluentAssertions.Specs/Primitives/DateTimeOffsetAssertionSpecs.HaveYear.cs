using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveYear
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_year_with_the_same_value_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_year_with_a_different_value_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_have_year_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotHaveYear
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_year_with_the_same_value_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_year_with_a_different_value_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 06, 04), TimeSpan.Zero);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_not_have_year_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
