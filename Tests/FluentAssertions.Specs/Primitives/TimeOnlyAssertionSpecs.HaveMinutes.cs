#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    public class HaveMinutes
    {
        [Fact]
        public void When_asserting_subject_timeonly_should_have_minutes_with_the_same_value_it_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(21, 12, 31);
            const int expectation = 12;

            // Act/Assert
            subject.Should().HaveMinutes(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_should_not_have_minutes_with_the_same_value_it_should_throw()
        {
            // Arrange
            TimeOnly subject = new(21, 12, 31);
            const int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMinutes(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_should_have_a_minute_with_a_different_value_it_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 12, 31);
            const int expectation = 11;

            // Act
            Action act = () => subject.Should().HaveMinutes(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_asserting_subject_timeonly_should_not_have_a_minute_with_a_different_value_it_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 12, 31);
            const int expectation = 11;

            // Act/Assert
            subject.Should().NotHaveMinutes(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_null_timeonly_should_have_minutes_should_throw()
        {
            // Arrange
            TimeOnly? subject = null;
            const int expectation = 12;

            // Act
            Action act = () => subject.Should().HaveMinutes(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_timeonly_should_not_have_minutes_should_throw()
        {
            // Arrange
            TimeOnly? subject = null;
            const int expectation = 12;

            // Act
            Action act = () => subject.Should().NotHaveMinutes(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}

#endif
