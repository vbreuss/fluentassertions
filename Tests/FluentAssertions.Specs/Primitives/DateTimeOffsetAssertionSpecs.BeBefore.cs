using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeBefore
    {
        [Fact]
        public async Task When_asserting_a_point_of_time_is_before_a_later_point_it_should_succeed()
        {
            // Arrange
            DateTimeOffset earlierDate = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset laterDate = new(new DateTime(2016, 06, 04, 0, 5, 0), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(earlierDate).IsBefore(laterDate));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_is_before_earlier_expected_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 03), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsBefore(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_before_the_same_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsBefore(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeBefore
    {
        [Fact]
        public async Task When_asserting_a_point_of_time_is_not_before_another_it_should_throw()
        {
            // Arrange
            DateTimeOffset earlierDate = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset laterDate = new(new DateTime(2016, 06, 04, 0, 5, 0), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(earlierDate).IsNotBefore(laterDate));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_is_not_before_earlier_expected_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 03), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotBefore(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_before_the_same_datetimeoffset_it_should_succeed()
        {
            // Arrange
            DateTimeOffset expected = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotBefore(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
