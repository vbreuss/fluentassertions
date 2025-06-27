using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveMonth
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_have_month_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_a_month_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().HaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_have_month_should_throw()
        {
            // Arrange
            DateTime? subject = null;
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
        public async Task When_asserting_subject_datetime_should_not_have_month_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_a_month_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 11;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_not_have_month_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMonth(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
