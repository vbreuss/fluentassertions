﻿using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class HaveYear
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_have_year_with_the_same_value_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_year_with_a_different_value_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().HaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_have_year_should_throw()
        {
            // Arrange
            DateTime? subject = null;
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
        public async Task When_asserting_subject_datetime_should_not_have_year_with_the_same_value_should_throw()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2009;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_year_with_a_different_value_should_succeed()
        {
            // Arrange
            DateTime subject = new(2009, 12, 31);
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_should_not_have_year_should_throw()
        {
            // Arrange
            DateTime? subject = null;
            int expectation = 2008;

            // Act
            Action act = () => subject.Should().NotHaveYear(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }
    }
}
