#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    public class BeAfter
    {
        [Fact]
        public async Task When_asserting_subject_timeonly_is_after_earlier_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 123);
            TimeOnly expectation = new(15, 06, 03, 45);

            // Act/Assert
            await That(subject).IsAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_after_earlier_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 03);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_after_later_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 05);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_after_later_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 05);

            // Act/Assert
            await That(subject).IsNotAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_after_the_same_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 145);
            TimeOnly expectation = new(15, 06, 04, 145);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_after_the_same_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 123);
            TimeOnly expectation = new(15, 06, 04, 123);

            // Act/Assert
            await That(subject).IsNotAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_after_earlier_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 07);
            TimeOnly expectation = new(15, 06);

            // Act/Assert
            await That(subject).IsOnOrAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_on_or_after_earlier_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 03);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_after_the_same_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 04);

            // Act/Assert
            await That(subject).IsOnOrAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_on_or_after_the_same_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06);
            TimeOnly expectation = new(15, 06);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_after_later_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 05);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_on_or_after_later_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 05);

            // Act/Assert
            await That(subject).IsNotOnOrAfter(expectation);
        }
    }
}

#endif
