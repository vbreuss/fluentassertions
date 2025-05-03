using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeAfter
    {
        [Fact]
        public async Task When_asserting_subject_datetime_is_after_earlier_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 03);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsAfter(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_after_later_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsAfter(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_after_the_same_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsAfter(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeAfter
    {
        [Fact]
        public async Task When_asserting_subject_datetime_is_not_after_earlier_expected_datetime_should_throw()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 03);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotAfter(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_after_later_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotAfter(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_is_not_after_the_same_expected_datetime_should_succeed()
        {
            // Arrange
            DateTime subject = new(2016, 06, 04);
            DateTime expectation = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotAfter(expectation));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
