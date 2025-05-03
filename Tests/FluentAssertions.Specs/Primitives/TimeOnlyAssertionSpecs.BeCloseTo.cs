#if NET6_0_OR_GREATER
using System;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    public class BeCloseTo
    {
        [Fact]
        public async Task When_time_is_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks - 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(time, -1.Ticks());

            // Assert
            await Expect.That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void When_a_time_is_close_to_a_later_time_by_one_tick_it_should_succeed()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks - 1);

            // Act / Assert
            actual.Should().BeCloseTo(time, TimeSpan.FromTicks(1));
        }

        [Fact]
        public void When_a_time_is_close_to_an_earlier_time_by_one_tick_it_should_succeed()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks + 1);

            // Act / Assert
            actual.Should().BeCloseTo(time, TimeSpan.FromTicks(1));
        }

        [Fact]
        public void When_subject_time_is_close_to_the_minimum_time_it_should_succeed()
        {
            // Arrange
            TimeOnly time = TimeOnly.MinValue.Add(50.Milliseconds());
            TimeOnly nearbyTime = TimeOnly.MinValue;

            // Act / Assert
            time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());
        }

        [Fact]
        public void When_subject_time_is_close_to_the_maximum_time_it_should_succeed()
        {
            // Arrange
            TimeOnly time = TimeOnly.MaxValue.Add(-50.Milliseconds());
            TimeOnly nearbyTime = TimeOnly.MaxValue;

            // Act / Assert
            time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());
        }

        [Fact]
        public async Task When_subject_time_is_close_to_another_value_that_is_later_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            TimeOnly time = new(12, 15, 30, 979);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_time_is_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 021);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_subject_time_is_close_to_an_earlier_time_by_35ms_it_should_succeed()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 035);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act / Assert
            time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());
        }

        [Fact]
        public void A_time_is_close_to_a_later_time_when_passing_midnight()
        {
            // Arrange
            TimeOnly time = new(23, 59, 0);
            TimeOnly nearbyTime = new(0, 1, 0);

            // Act / Assert
            time.Should().BeCloseTo(nearbyTime, 2.Minutes());
        }

        [Fact]
        public void A_time_is_close_to_an_earlier_time_when_passing_midnight()
        {
            // Arrange
            TimeOnly time = new(0, 1, 0);
            TimeOnly nearbyTime = new(23, 59, 0);

            // Act / Assert
            time.Should().BeCloseTo(nearbyTime, 2.Minutes());
        }

        [Fact]
        public async Task A_time_outside_of_the_precision_to_a_later_time_when_passing_midnight_fails()
        {
            // Arrange
            TimeOnly time = new(23, 58, 59);
            TimeOnly nearbyTime = new(0, 1, 0);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 2.Minutes());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_time_outside_of_the_precision_to_an_earlier_time_when_passing_midnight_fails()
        {
            // Arrange
            TimeOnly time = new(0, 1, 0);
            TimeOnly nearbyTime = new(23, 58, 59);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 2.Minutes());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_subject_nulltime_is_close_to_another_it_should_throw()
        {
            // Arrange
            TimeOnly? time = null;
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_null_time_inside_an_assertion_scope_fails()
        {
            // Arrange
            TimeOnly? time = null;
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeCloseTo
    {
        [Fact]
        public async Task A_null_time_is_never_unclose_to_an_other_time()
        {
            // Arrange
            TimeOnly? time = null;
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_null_time_inside_an_assertion_scope_is_never_unclose_to_an_other_time()
        {
            // Arrange
            TimeOnly? time = null;
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_time_is_not_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(time, -1.Ticks());

            // Assert
            await Expect.That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_a_time_is_close_to_a_later_time_by_one_tick_it_should_fail()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(time, TimeSpan.FromTicks(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_time_is_close_to_an_earlier_time_by_one_tick_it_should_fail()
        {
            // Arrange
            var time = TimeOnly.FromDateTime(DateTime.UtcNow);
            var actual = new TimeOnly(time.Ticks + 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(time, TimeSpan.FromTicks(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_time_is_close_to_a_min_value_by_one_tick_it_should_fail()
        {
            // Arrange
            var time = TimeOnly.MinValue;
            var actual = new TimeOnly(time.Ticks + 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(time, TimeSpan.FromTicks(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_time_is_close_to_a_max_value_by_one_tick_it_should_fail()
        {
            // Arrange
            var time = TimeOnly.MaxValue;
            var actual = new TimeOnly(time.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(time, TimeSpan.FromTicks(1));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_time_is_not_close_to_an_earlier_time_it_should_throw()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 020);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_time_is_not_close_to_an_earlier_time_by_a_20ms_timespan_it_should_throw()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 020);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_asserting_subject_time_is_not_close_to_another_value_that_is_later_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            TimeOnly time = new(12, 15, 30, 979);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act / Assert
            time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());
        }

        [Fact]
        public void
            When_asserting_subject_time_is_not_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 021);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act / Assert
            time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_an_earlier_datetime_by_35ms_it_should_throw()
        {
            // Arrange
            TimeOnly time = new(12, 15, 31, 035);
            TimeOnly nearbyTime = new(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_time_is_not_close_to_the_minimum_time_it_should_throw()
        {
            // Arrange
            TimeOnly time = TimeOnly.MinValue.Add(50.Milliseconds());
            TimeOnly nearbyTime = TimeOnly.MinValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_time_is_not_close_to_the_maximum_time_it_should_throw()
        {
            // Arrange
            TimeOnly time = TimeOnly.MaxValue.Add(-50.Milliseconds());
            TimeOnly nearbyTime = TimeOnly.MaxValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void A_time_is_not_close_to_a_later_time_when_passing_midnight()
        {
            // Arrange
            TimeOnly time = new(23, 58, 0);
            TimeOnly nearbyTime = new(0, 1, 0);

            // Act / Assert
            time.Should().NotBeCloseTo(nearbyTime, 2.Minutes());
        }

        [Fact]
        public void A_time_is_not_close_to_an_earlier_time_when_passing_midnight()
        {
            // Arrange
            TimeOnly time = new(0, 2, 0);
            TimeOnly nearbyTime = new(23, 59, 0);

            // Act / Assert
            time.Should().NotBeCloseTo(nearbyTime, 2.Minutes());
        }

        [Fact]
        public async Task A_time_inside_of_the_precision_to_a_later_time_when_passing_midnight_fails()
        {
            // Arrange
            TimeOnly time = new(23, 59, 0);
            TimeOnly nearbyTime = new(0, 1, 0);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 2.Minutes());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task A_time_inside_of_the_precision_to_an_earlier_time_when_passing_midnight_fails()
        {
            // Arrange
            TimeOnly time = new(0, 1, 0);
            TimeOnly nearbyTime = new(23, 59, 0);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 2.Minutes());

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}

#endif
