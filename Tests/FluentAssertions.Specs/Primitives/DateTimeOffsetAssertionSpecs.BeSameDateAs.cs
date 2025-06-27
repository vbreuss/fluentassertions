using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class BeSameDateAs
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_be_same_date_as_another_with_the_same_date_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_be_same_as_another_with_same_date_but_different_time_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31, 11, 15, 11), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_to_be_same_date_as_another_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_same_date_as_another_but_it_doesnt_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 30), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().BeSameDateAs(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public void Can_chain_follow_up_assertions()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);

            // Act / Assert
            subject.Should().BeSameDateAs(expectation).And.Be(subject);
        }
    }

    public class NotBeSameDateAs
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_be_same_date_as_another_with_the_same_date_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Can_chain_follow_up_assertions()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation).And.Be(subject);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_be_same_as_another_with_same_date_but_different_time_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 4, 5, 6), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31, 11, 15, 11), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_to_not_be_same_date_as_another_datetimeoffset_it_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            DateTimeOffset expectation = new(new DateTime(2009, 12, 31), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            await That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_same_date_as_another_but_it_doesnt_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31), TimeSpan.Zero);
            DateTimeOffset expectation = new(new DateTime(2009, 12, 30), TimeSpan.Zero);

            // Act
            Action act = () => subject.Should().NotBeSameDateAs(expectation);

            // Assert
            await That(act).DoesNotThrow();
        }
    }
}
