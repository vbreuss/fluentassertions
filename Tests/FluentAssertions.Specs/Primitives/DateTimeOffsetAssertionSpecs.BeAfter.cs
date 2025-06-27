using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeAfter
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_after_earlier_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_after_later_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_after_the_same_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }
    }

    public class NotBeAfter
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_after_earlier_expected_datetimeoffset_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 03), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_after_later_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 05), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotAfter(expectation));

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_is_not_after_the_same_expected_datetimeoffset_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2016, 06, 04), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2016, 06, 04), TimeSpan.Zero);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotAfter(expectation));

            // Assert
            await That(act).DoesNotThrow();
        }
    }
}
