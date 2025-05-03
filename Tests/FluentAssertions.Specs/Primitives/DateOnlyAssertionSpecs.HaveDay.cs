#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateOnlyAssertionSpecs
{
    public class HaveDay
    {
        [Fact]
        public void When_asserting_subject_dateonly_should_have_day_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2009, 12, 31);
            const int expectation = 31;

            // Act/Assert
            subject.Should().HaveDay(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_should_not_have_day_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateOnly subject = new(2009, 12, 31);
            const int expectation = 31;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_should_have_day_with_a_different_value_it_should_throw()
        {
            // Arrange
            DateOnly subject = new(2009, 12, 31);
            const int expectation = 30;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public void When_asserting_subject_dateonly_should_not_have_day_with_a_different_value_it_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2009, 12, 31);
            const int expectation = 30;

            // Act/Assert
            subject.Should().NotHaveDay(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_null_dateonly_should_have_day_should_throw()
        {
            // Arrange
            DateOnly? subject = null;
            const int expectation = 22;

            // Act
            Action act = () => subject.Should().HaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_dateonly_should_not_have_day_should_throw()
        {
            // Arrange
            DateOnly? subject = null;
            const int expectation = 22;

            // Act
            Action act = () => subject.Should().NotHaveDay(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}

#endif
