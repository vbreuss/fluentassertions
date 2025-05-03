using System;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeWithin
    {
        [Fact]
        public async Task When_date_is_not_within_50_hours_before_another_date_it_should_throw()
        {
            // Arrange
            var target = new DateTime(2010, 4, 10, 12, 0, 0);
            DateTime subject = target - 50.Hours() - 1.Seconds();

            // Act
            Action act =
                () => subject.Should().BeWithin(TimeSpan.FromHours(50)).Before(target, "{0} hours is enough", 50);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_date_is_exactly_within_1d_before_another_date_it_should_not_throw()
        {
            // Arrange
            var target = new DateTime(2010, 4, 10);
            DateTime subject = target - 1.Days();

            // Act / Assert
            subject.Should().BeWithin(TimeSpan.FromHours(24)).Before(target);
        }

        [Fact]
        public void When_date_is_within_1d_before_another_date_it_should_not_throw()
        {
            // Arrange
            var target = new DateTime(2010, 4, 10);
            DateTime subject = target - 23.Hours();

            // Act / Assert
            subject.Should().BeWithin(TimeSpan.FromHours(24)).Before(target);
        }

        [Fact]
        public void When_a_utc_date_is_within_0s_before_itself_it_should_not_throw()
        {
            // Arrange
            var date = DateTime.UtcNow; // local timezone differs from UTC

            // Act / Assert
            date.Should().BeWithin(TimeSpan.Zero).Before(date);
        }

        [Fact]
        public void When_a_utc_date_is_within_0s_after_itself_it_should_not_throw()
        {
            // Arrange
            var date = DateTime.UtcNow; // local timezone differs from UTC

            // Act / Assert
            date.Should().BeWithin(TimeSpan.Zero).After(date);
        }

        [Theory]
        [InlineData(30, 20)] // edge case
        [InlineData(30, 25)]
        public async Task When_asserting_subject_be_within_10_seconds_after_target_but_subject_is_before_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds);
            var subject = 1.January(0001).At(0, 0, subjectSeconds);

            // Act
            Action action = () => subject.Should().BeWithin(10.Seconds()).After(expectation);

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Theory]
        [InlineData(30, 40)] // edge case
        [InlineData(30, 35)]
        public async Task When_asserting_subject_be_within_10_seconds_before_target_but_subject_is_after_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds);
            var subject = 1.January(0001).At(0, 0, subjectSeconds);

            // Act
            Action action = () => subject.Should().BeWithin(10.Seconds()).Before(expectation);

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_throw_because_of_assertion_failure_when_asserting_null_is_within_second_before_specific_date()
        {
            // Arrange
            DateTimeOffset? nullDateTime = null;
            DateTimeOffset target = new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero);

            // Act
            Action action = () =>
                nullDateTime.Should()
                    .BeWithin(TimeSpan.FromSeconds(1))
                    .Before(target);

            // Assert
            await Expect.That(action).Throws<Exception>();
        }

        [Fact]
        public async Task Should_throw_because_of_assertion_failure_when_asserting_null_is_within_second_after_specific_date()
        {
            // Arrange
            DateTimeOffset? nullDateTime = null;
            DateTimeOffset target = new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero);

            // Act
            Action action = () =>
                nullDateTime.Should()
                    .BeWithin(TimeSpan.FromSeconds(1))
                    .After(target);

            // Assert
            await Expect.That(action).Throws<Exception>();
        }
    }
}
