using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeOffsetAssertionSpecs
{
    public class HaveOffset
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_offset_with_the_same_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.FromHours(7));
            TimeSpan expectation = TimeSpan.FromHours(7);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_have_offset_with_different_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 10), TimeSpan.Zero);
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_have_offset_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().HaveOffset(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveOffset
    {
        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_offset_with_the_same_value_it_should_throw()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.FromHours(7));
            TimeSpan expectation = TimeSpan.FromHours(7);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_asserting_subject_datetimeoffset_should_not_have_offset_with_different_value_it_should_succeed()
        {
            // Arrange
            DateTimeOffset subject = new(new DateTime(2009, 12, 31, 23, 59, 00), TimeSpan.Zero);
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_asserting_subject_null_datetimeoffset_should_not_have_offset_should_throw()
        {
            // Arrange
            DateTimeOffset? subject = null;
            TimeSpan expectation = TimeSpan.FromHours(3);

            // Act
            Action act = () => subject.Should().NotHaveOffset(expectation);

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
