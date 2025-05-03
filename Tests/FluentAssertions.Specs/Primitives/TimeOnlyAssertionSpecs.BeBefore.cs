#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class TimeOnlyAssertionSpecs
{
    public class BeBefore
    {
        [Fact]
        public async Task When_asserting_subject_is_not_before_earlier_expected_timeonly_it_should_succeed()
        {
            // Arrange
            TimeOnly expected = new(15, 06, 03);
            TimeOnly subject = new(15, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsNotBefore(expected);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_before_the_same_timeonly_it_should_throw()
        {
            // Arrange
            TimeOnly expected = new(15, 06, 04);
            TimeOnly subject = new(15, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsBefore(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_before_the_same_timeonly_it_should_succeed()
        {
            // Arrange
            TimeOnly expected = new(15, 06, 04);
            TimeOnly subject = new(15, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsNotBefore(expected);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_before_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 175);
            TimeOnly expectation = new(15, 06, 05, 23);

            // Act/Assert
            await Expect.That(subject).IsOnOrBefore(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_before_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 150);
            TimeOnly expectation = new(15, 06, 05, 340);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_before_the_same_time_as_the_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsOnOrBefore(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_on_or_before_the_same_time_as_the_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04, 123);
            TimeOnly expectation = new(15, 06, 04, 123);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_on_or_before_earlier_expected_timeonly_should_throw()
        {
            // Arrange
            TimeOnly subject = new(15, 07);
            TimeOnly expectation = new(15, 06);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_timeonly_is_not_on_or_before_earlier_expected_timeonly_should_succeed()
        {
            // Arrange
            TimeOnly subject = new(15, 06, 04);
            TimeOnly expectation = new(15, 06, 03);

            // Act/Assert
            await Expect.That(subject).IsNotOnOrBefore(expectation);
        }
    }
}

#endif
