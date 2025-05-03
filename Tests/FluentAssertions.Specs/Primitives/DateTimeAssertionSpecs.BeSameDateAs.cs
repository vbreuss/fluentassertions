using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class BeSameDateAs
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_be_same_date_as_another_with_the_same_date_it_should_succeed()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31, 4, 5, 6);

            // Act
            Action act = () => subject.Should().BeSameDateAs(new DateTime(2009, 12, 31));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_be_same_as_another_with_same_date_but_different_time_it_should_succeed()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31, 4, 5, 6);

            // Act
            Action act = () => subject.Should().BeSameDateAs(new DateTime(2009, 12, 31, 11, 15, 11));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_to_be_same_date_as_another_datetime_it_should_throw()
        {
            // Arrange
            DateTime? subject = null;

            // Act
            Action act = () => subject.Should().BeSameDateAs(new DateTime(2009, 12, 31));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_have_same_date_as_another_but_it_doesnt_it_should_throw()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31);

            // Act
            Action act = () => subject.Should().BeSameDateAs(new DateTime(2009, 12, 30));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotBeSameDateAs
    {
        [Fact]
        public async Task When_asserting_subject_datetime_should_not_be_same_date_as_another_with_the_same_date_it_should_throw()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31, 4, 5, 6);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(new DateTime(2009, 12, 31));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_be_same_as_another_with_same_date_but_different_time_it_should_throw()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31, 4, 5, 6);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(new DateTime(2009, 12, 31, 11, 15, 11));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetime_to_not_be_same_date_as_another_datetime_it_should_throw()
        {
            // Arrange
            DateTime? subject = null;

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(new DateTime(2009, 12, 31));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetime_should_not_have_same_date_as_another_but_it_doesnt_it_should_succeed()
        {
            // Arrange
            var subject = new DateTime(2009, 12, 31);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(new DateTime(2009, 12, 30));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }
    }
}
