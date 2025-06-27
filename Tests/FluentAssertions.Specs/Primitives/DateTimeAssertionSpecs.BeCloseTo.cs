﻿using System;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeCloseTo
    {
        [Fact]
        public async Task When_asserting_that_time_is_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, -1.Ticks());

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_later_datetime_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_an_earlier_datetime_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks + 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_MinValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTime.MinValue;
            var actual = new DateTime(dateTime.Ticks + 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_MaxValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTime.MaxValue;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_a_later_datetime_it_should_succeed()
        {
            // Arrange
            DateTime time = DateTime.SpecifyKind(new DateTime(2016, 06, 04).At(12, 15, 30, 980), DateTimeKind.Unspecified);
            DateTime nearbyTime = DateTime.SpecifyKind(new DateTime(2016, 06, 04).At(12, 15, 31), DateTimeKind.Utc);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_an_earlier_datetime_it_should_succeed()
        {
            // Arrange
            DateTime time = new DateTime(2016, 06, 04).At(12, 15, 31, 020);
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_another_value_that_is_later_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTime time = 13.March(2012).At(12, 15, 30, 979);
            DateTime nearbyTime = 13.March(2012).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_another_value_that_is_later_by_more_than_a_20ms_timespan_it_should_throw()
        {
            // Arrange
            DateTime time = 13.March(2012).At(12, 15, 30, 979);
            DateTime nearbyTime = 13.March(2012).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTime time = 13.March(2012).At(12, 15, 31, 021);
            DateTime nearbyTime = 13.March(2012).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_an_earlier_datetime_by_35ms_it_should_succeed()
        {
            // Arrange
            DateTime time = new DateTime(2016, 06, 04).At(12, 15, 31, 035);
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_is_close_to_another_it_should_throw()
        {
            // Arrange
            DateTime? time = null;
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_the_minimum_datetime_it_should_succeed()
        {
            // Arrange
            DateTime time = DateTime.MinValue + 50.Milliseconds();
            DateTime nearbyTime = DateTime.MinValue;

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_close_to_the_maximum_datetime_it_should_succeed()
        {
            // Arrange
            DateTime time = DateTime.MaxValue - 50.Milliseconds();
            DateTime nearbyTime = DateTime.MaxValue;

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }
    }

    public class NotBeCloseTo
    {
        [Fact]
        public async Task When_asserting_that_time_is_not_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, -1.Ticks());

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_later_datetime_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_an_earlier_datetime_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTime.UtcNow;
            var actual = new DateTime(dateTime.Ticks + 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_MinValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTime.MinValue;
            var actual = new DateTime(dateTime.Ticks + 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetime_is_close_to_a_MaxValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTime.MaxValue;
            var actual = new DateTime(dateTime.Ticks - 1);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_a_later_datetime_it_should_throw()
        {
            // Arrange
            DateTime time = DateTime.SpecifyKind(new DateTime(2016, 06, 04).At(12, 15, 30, 980), DateTimeKind.Unspecified);
            DateTime nearbyTime = DateTime.SpecifyKind(new DateTime(2016, 06, 04).At(12, 15, 31), DateTimeKind.Utc);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_an_earlier_datetime_it_should_throw()
        {
            // Arrange
            DateTime time = new DateTime(2016, 06, 04).At(12, 15, 31, 020);
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_an_earlier_datetime_by_a_20ms_timespan_it_should_throw()
        {
            // Arrange
            DateTime time = new DateTime(2016, 06, 04).At(12, 15, 31, 020);
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_another_value_that_is_later_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTime time = 13.March(2012).At(12, 15, 30, 979);
            DateTime nearbyTime = 13.March(2012).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTime time = 13.March(2012).At(12, 15, 31, 021);
            DateTime nearbyTime = 13.March(2012).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_an_earlier_datetime_by_35ms_it_should_throw()
        {
            // Arrange
            DateTime time = new DateTime(2016, 06, 04).At(12, 15, 31, 035);
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_is_not_close_to_another_it_should_throw()
        {
            // Arrange
            DateTime? time = null;
            DateTime nearbyTime = new DateTime(2016, 06, 04).At(12, 15, 31);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_the_minimum_datetime_it_should_throw()
        {
            // Arrange
            DateTime time = DateTime.MinValue + 50.Milliseconds();
            DateTime nearbyTime = DateTime.MinValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_close_to_the_maximum_datetime_it_should_throw()
        {
            // Arrange
            DateTime time = DateTime.MaxValue - 50.Milliseconds();
            DateTime nearbyTime = DateTime.MaxValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
