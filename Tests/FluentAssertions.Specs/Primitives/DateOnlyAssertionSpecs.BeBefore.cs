#if NET6_0_OR_GREATER
using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateOnlyAssertionSpecs
{
    public class BeBefore
    {
        [Fact]
        public async Task When_asserting_subject_is_not_before_earlier_expected_dateonly_it_should_succeed()
        {
            // Arrange
            DateOnly expected = new(2016, 06, 03);
            DateOnly subject = new(2016, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsNotBefore(expected);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_before_the_same_dateonly_it_should_throw()
        {
            // Arrange
            DateOnly expected = new(2016, 06, 04);
            DateOnly subject = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsBefore(expected));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_before_the_same_dateonly_it_should_succeed()
        {
            // Arrange
            DateOnly expected = new(2016, 06, 04);
            DateOnly subject = new(2016, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsNotBefore(expected);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_before_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act/Assert
            await Expect.That(subject).IsOnOrBefore(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_before_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_before_the_same_date_as_the_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act/Assert
            await Expect.That(subject).IsOnOrBefore(expectation);
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_on_or_before_the_same_date_as_the_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsNotOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_on_or_before_earlier_expected_dateonly_should_throw()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(subject).IsOnOrBefore(expectation));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_dateonly_is_not_on_or_before_earlier_expected_dateonly_should_succeed()
        {
            // Arrange
            DateOnly subject = new(2016, 06, 04);
            DateOnly expectation = new(2016, 06, 03);

            // Act/Assert
            await Expect.That(subject).IsNotOnOrBefore(expectation);
        }
    }
}

#endif
