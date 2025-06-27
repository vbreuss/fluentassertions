using System;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeCloseTo
    {
        [Fact]
        public async Task When_asserting_that_time_is_close_to_a_negative_precision_it_should_throw()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, -1.Ticks());

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_later_datetimeoffset_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_MinValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.MinValue;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_MaxValue_by_one_tick_it_should_succeed()
        {
            // Arrange
            var dateTime = DateTimeOffset.MaxValue;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().BeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_a_later_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_an_earlier_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 31, 020, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_later_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 30, 979).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 021).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_another_value_that_is_earlier_by_more_than_a_35ms_timespan_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 036).WithOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).WithOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(35));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_35ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 035).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_is_close_to_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset? time = null;
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(5.Hours());

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_the_maximum_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MaxValue - 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MaxValue;

            // Act
            Action act = () => time.Should().BeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_close_to_the_minimum_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MinValue + 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MinValue;

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
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, -1.Ticks());

            // Assert
            await That(act).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_later_datetimeoffset_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_an_earlier_datetimeoffset_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.UtcNow;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_MinValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.MinValue;
            var actual = new DateTimeOffset(dateTime.Ticks + 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_a_datetimeoffset_is_close_to_a_MaxValue_by_one_tick_it_should_fail()
        {
            // Arrange
            var dateTime = DateTimeOffset.MaxValue;
            var actual = new DateTimeOffset(dateTime.Ticks - 1, TimeSpan.Zero);

            // Act
            Action act = () => actual.Should().NotBeCloseTo(dateTime, TimeSpan.FromTicks(1));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_a_later_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_a_later_datetimeoffset_by_a_20ms_timespan_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 30, 980, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_an_earlier_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = new(2016, 06, 04, 12, 15, 31, 020, TimeSpan.Zero);
            DateTimeOffset nearbyTime = new(2016, 06, 04, 12, 15, 31, 0, TimeSpan.Zero);

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_another_value_that_is_later_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 30, 979).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_succeed()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 021).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_an_earlier_datetimeoffset_by_35ms_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = 13.March(2012).At(12, 15, 31, 035).ToDateTimeOffset(1.Hours());
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(1.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_is_not_close_to_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset? time = null;
            DateTimeOffset nearbyTime = 13.March(2012).At(12, 15, 31).ToDateTimeOffset(5.Hours());

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_the_minimum_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MinValue + 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MinValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_close_to_the_maximum_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset time = DateTimeOffset.MaxValue - 50.Milliseconds();
            DateTimeOffset nearbyTime = DateTimeOffset.MaxValue;

            // Act
            Action act = () => time.Should().NotBeCloseTo(nearbyTime, 100.Milliseconds());

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
