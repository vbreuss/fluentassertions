using System;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeAtLeast
    {
        [Fact]
        public async Task When_date_is_not_at_least_one_day_before_another_it_should_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009), 0.Hours());
            DateTimeOffset subject = target - 23.Hours();

            // Act
            Action act = () => subject.Should().BeAtLeast(TimeSpan.FromDays(1)).Before(target, "we like {0}", "that");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_date_is_at_least_one_day_before_another_it_should_not_throw()
        {
            // Arrange
            var target = new DateTimeOffset(2.October(2009));
            DateTimeOffset subject = target - 24.Hours();

            // Act / Assert
            subject.Should().BeAtLeast(TimeSpan.FromDays(1)).Before(target);
        }

        [Theory]
        [InlineData(30, 20)] // edge case
        [InlineData(30, 15)]
        public async Task When_asserting_subject_be_at_least_10_seconds_after_target_but_subject_is_before_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeAtLeast(10.Seconds()).After(expectation);

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Theory]
        [InlineData(30, 40)] // edge case
        [InlineData(30, 45)]
        public async Task When_asserting_subject_be_at_least_10_seconds_before_target_but_subject_is_after_target_it_should_throw(
            int targetSeconds, int subjectSeconds)
        {
            // Arrange
            var expectation = 1.January(0001).At(0, 0, targetSeconds).WithOffset(0.Hours());
            var subject = 1.January(0001).At(0, 0, subjectSeconds).WithOffset(0.Hours());

            // Act
            Action action = () => subject.Should().BeAtLeast(10.Seconds()).Before(expectation);

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }
    }
}
