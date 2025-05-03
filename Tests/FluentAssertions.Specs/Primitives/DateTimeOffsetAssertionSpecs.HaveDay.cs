﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveDay
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_day_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_day_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_have_day_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveDay
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_day_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 31;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_day_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            int expectation = 30;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_not_have_day_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
