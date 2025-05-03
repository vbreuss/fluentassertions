using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeOnOrBefore
    {
        [Fact]
        public async Task When_asserting_subject_datetime_is_on_or_before_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_on_or_before_the_same_date_as_the_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_on_or_before_earlier_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 03);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeOnOrBefore
    {
        [Fact]
        public async Task When_asserting_subject_datetime_is_on_or_before_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_on_or_before_the_same_date_as_the_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_on_or_before_earlier_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 03);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
