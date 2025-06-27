using System;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeExactly
    {
        [Fact]
        public void Should_succeed_when_asserting_value_is_exactly_equal_to_the_same_value()
        {
            // Arrange
            DateTimeOffset dateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset sameDateTime = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act / Assert
            dateTime.Should().BeExactly(sameDateTime);
        }

        [Fact]
        public void Should_succeed_when_asserting_value_is_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 4.June(2016).ToDateTimeOffset();
            DateTimeOffset? sameDateTime = 4.June(2016).ToDateTimeOffset();

            // Act / Assert
            dateTime.Should().BeExactly(sameDateTime);
        }

        [Fact]
        public async Task Should_fail_when_asserting_value_is_exactly_equal_to_a_different_value()
        {
            // Arrange
            var dateTime = 10.March(2012).WithOffset(1.Hours());
            var otherDateTime = dateTime.ToUniversalTime();

            // Act
            Action act = () => dateTime.Should().BeExactly(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_when_asserting_value_is_exactly_equal_to_a_different_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset? otherDateTime = dateTime.ToUniversalTime();

            // Act
            Action act = () => dateTime.Should().BeExactly(otherDateTime, "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_value_is_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 04).ToDateTimeOffset();

            // Act / Assert
            nullableDateTimeA.Should().BeExactly(nullableDateTimeB);
        }

        [Fact]
        public void Should_succeed_when_asserting_nullable_null_value_exactly_equals_null()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = null;
            DateTimeOffset? nullableDateTimeB = null;

            // Act / Assert
            nullableDateTimeA.Should().BeExactly(nullableDateTimeB);
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_value_exactly_equals_a_different_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTimeA = new DateTime(2016, 06, 04).ToDateTimeOffset();
            DateTimeOffset? nullableDateTimeB = new DateTime(2016, 06, 06).ToDateTimeOffset();

            // Act
            Action action = () =>
                nullableDateTimeA.Should().BeExactly(nullableDateTimeB);

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_null_value_is_exactly_equal_to_another_value()
        {
            // Arrange
            DateTimeOffset? nullableDateTime = null;
            DateTimeOffset expectation = 27.March(2016).ToDateTimeOffset(1.Hours());

            // Act
            Action action = () =>
                nullableDateTime.Should().BeExactly(expectation, "because we want to test the failure {0}", "message");

            // Assert
            await That(action).Throws<XunitException>();
        }
    }

    public class NotBeExactly
    {
        [Fact]
        public void Should_succeed_when_asserting_value_is_not_exactly_equal_to_a_different_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset otherDateTime = dateTime.ToUniversalTime();

            // Act / Assert
            dateTime.Should().NotBeExactly(otherDateTime);
        }

        [Fact]
        public void Should_succeed_when_asserting_value_is_not_exactly_equal_to_a_different_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = 10.March(2012).WithOffset(1.Hours());
            DateTimeOffset? otherDateTime = dateTime.ToUniversalTime();

            // Act / Assert
            dateTime.Should().NotBeExactly(otherDateTime);
        }

        [Fact]
        public async Task Should_fail_when_asserting_value_is_not_exactly_equal_to_the_same_value()
        {
            // Arrange
            var dateTime = new DateTimeOffset(10.March(2012), 1.Hours());
            var sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBeExactly(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_when_asserting_value_is_not_exactly_equal_to_the_same_nullable_value()
        {
            // Arrange
            DateTimeOffset dateTime = new(10.March(2012), 1.Hours());
            DateTimeOffset? sameDateTime = new DateTimeOffset(10.March(2012), 1.Hours());

            // Act
            Action act =
                () => dateTime.Should().NotBeExactly(sameDateTime, "because we want to test the failure {0}", "message");

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_time_is_not_at_exactly_20_minutes_before_another_time_it_should_throw()
        {
            // Arrange
            DateTimeOffset target = 1.January(0001).At(12, 55).ToDateTimeOffset();
            DateTimeOffset subject = 1.January(0001).At(12, 36).ToDateTimeOffset();

            // Act
            Action act =
                () => subject.Should().BeExactly(TimeSpan.FromMinutes(20)).Before(target, "{0} minutes is enough", 20);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_time_is_exactly_90_seconds_before_another_time_it_should_not_throw()
        {
            // Arrange
            DateTimeOffset target = 1.January(0001).At(12, 55).ToDateTimeOffset();
            DateTimeOffset subject = 1.January(0001).At(12, 53, 30).ToDateTimeOffset();

            // Act / Assert
            subject.Should().BeExactly(TimeSpan.FromSeconds(90)).Before(target);
        }

        [Fact]
        public async Task When_asserting_subject_be_exactly_10_seconds_after_target_but_subject_is_before_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 20).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeExactly(10.Seconds()).After(expectation);

            // Assert
            await That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_be_exactly_10_seconds_before_target_but_subject_is_after_target_it_should_throw()
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, 30).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, 40).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeExactly(10.Seconds()).Before(expectation);

            // Assert
            await That(action).Throws<XunitException>();
        }
    }
}
