#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateOnlyAssertionSpecs
{
    public class BeAfter
    {
        [Fact]
        public async Task When_asserting_subject_dateonly_is_after_earlier_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act/Assert
            await That(subject).IsAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_after_earlier_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_after_later_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_after_later_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act/Assert
            await That(subject).IsNotAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_after_the_same_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_after_the_same_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act/Assert
            await That(subject).IsNotAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_after_earlier_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act/Assert
            await That(subject).IsOnOrAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_on_or_after_earlier_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_after_the_same_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act/Assert
            await That(subject).IsOnOrAfter(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_on_or_after_the_same_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsNotOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_after_later_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act
            Action act = () => Synchronously.Verify(That(subject).IsOnOrAfter(expectation));

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_on_or_after_later_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act/Assert
            await That(subject).IsNotOnOrAfter(expectation);
        }
    }
}

#endif
