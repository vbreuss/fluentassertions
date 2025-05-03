using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeOnOrBefore
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_on_or_before_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_on_or_before_the_same_date_as_the_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_on_or_before_earlier_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeOnOrBefore
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_on_or_before_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_on_or_before_the_same_date_as_the_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_on_or_before_earlier_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
