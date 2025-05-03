using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeBefore
    {
        [Fact]
        public async Task When_asserting_a_point_of_time_is_before_a_later_point_it_should_succeed()
        {
            // Arrange
            DateTime earlierDate = DateTime.SpecifyKind(new DateTime(2016, 06, 04), DateTimeKind.Unspecified);
            DateTime laterDate = DateTime.SpecifyKind(new DateTime(2016, 06, 04, 0, 5, 0), DateTimeKind.Utc);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(earlierDate).IsBefore(laterDate));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_is_before_earlier_expected_datetime_it_should_throw()
        {
            // Arrange
            DateTime expected = new(2016, 06, 03);
            DateTime subject = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsBefore(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_before_the_same_datetime_it_should_throw()
        {
            // Arrange
            DateTime expected = new(2016, 06, 04);
            DateTime subject = new(2016, 06, 04);

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
            DateTime earlierDate = DateTime.SpecifyKind(new DateTime(2016, 06, 04), DateTimeKind.Unspecified);
            DateTime laterDate = DateTime.SpecifyKind(new DateTime(2016, 06, 04, 0, 5, 0), DateTimeKind.Utc);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(earlierDate).IsNotBefore(laterDate));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_is_not_before_earlier_expected_datetime_it_should_succeed()
        {
            // Arrange
            DateTime expected = new(2016, 06, 03);
            DateTime subject = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotBefore(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_before_the_same_datetime_it_should_succeed()
        {
            // Arrange
            DateTime expected = new(2016, 06, 04);
            DateTime subject = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotBefore(expected));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
