using System;
using FluentAssertions.Extensions;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public partial class DateTimeAssertionSpecs
{
    public class Be
    {
        [Fact]
        public async Task Should_succeed_when_asserting_datetime_value_is_equal_to_the_same_value()
        {
            // Arrange
            DateTime dateTime = new(2016, 06, 04);
            DateTime sameDateTime = new(2016, 06, 04);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(sameDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_datetime_value_is_equal_to_the_same_nullable_value_be_should_succeed()
        {
            // Arrange
            DateTime dateTime = 4.June(2016);
            DateTime? sameDateTime = 4.June(2016);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(sameDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_both_values_are_at_their_minimum_then_it_should_succeed()
        {
            // Arrange
            DateTime dateTime = DateTime.MinValue;
            DateTime sameDateTime = DateTime.MinValue;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(sameDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_both_values_are_at_their_maximum_then_it_should_succeed()
        {
            // Arrange
            DateTime dateTime = DateTime.MaxValue;
            DateTime sameDateTime = DateTime.MaxValue;

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(sameDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_datetime_value_is_equal_to_the_different_value()
        {
            // Arrange
            var dateTime = new DateTime(2012, 03, 10);
            var otherDateTime = new DateTime(2012, 03, 11);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(otherDateTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_datetime_value_is_equal_to_the_different_nullable_value_be_should_failed()
        {
            // Arrange
            DateTime dateTime = 10.March(2012);
            DateTime? otherDateTime = 11.March(2012);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsEqualTo(otherDateTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_value_equals_the_same_value()
        {
            // Arrange
            DateTime? nullableDateTimeA = new DateTime(2016, 06, 04);
            DateTime? nullableDateTimeB = new DateTime(2016, 06, 04);

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTimeA).IsEqualTo(nullableDateTimeB));

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_nullable_date_time_is_equal_to_a_normal_date_time_but_the_kinds_differ_it_should_still_succeed()
        {
            // Arrange
            DateTime? nullableDateTime = new DateTime(2014, 4, 20, 9, 11, 0, DateTimeKind.Unspecified);
            DateTime normalDateTime = new(2014, 4, 20, 9, 11, 0, DateTimeKind.Utc);

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsEqualTo(normalDateTime));

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task When_two_date_times_are_equal_but_the_kinds_differ_it_should_still_succeed()
        {
            // Arrange
            DateTime dateTimeA = new(2014, 4, 20, 9, 11, 0, DateTimeKind.Unspecified);
            DateTime dateTimeB = new(2014, 4, 20, 9, 11, 0, DateTimeKind.Utc);

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTimeA).IsEqualTo(dateTimeB));

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_succeed_when_asserting_nullable_numeric_null_value_equals_null()
        {
            // Arrange
            DateTime? nullableDateTimeA = null;
            DateTime? nullableDateTimeB = null;

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTimeA).IsEqualTo(nullableDateTimeB));

            // Assert
            await Expect.That(action).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_nullable_numeric_value_equals_a_different_value()
        {
            // Arrange
            DateTime? nullableDateTimeA = new DateTime(2016, 06, 04);
            DateTime? nullableDateTimeB = new DateTime(2016, 06, 06);

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTimeA).IsEqualTo(nullableDateTimeB));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }

        [Fact]
        public async Task Should_fail_with_descriptive_message_when_asserting_datetime_null_value_is_equal_to_another_value()
        {
            // Arrange
            DateTime? nullableDateTime = null;

            // Act
            Action action = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullableDateTime).IsEqualTo(new DateTime(2016, 06, 04)).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(action).Throws<XunitException>();
        }
    }

    public class NotBe
    {
        [Fact]
        public async Task Should_succeed_when_asserting_datetime_value_is_not_equal_to_a_different_value()
        {
            // Arrange
            DateTime dateTime = new(2016, 06, 04);
            DateTime otherDateTime = new(2016, 06, 05);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsNotEqualTo(otherDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_datetime_value_is_not_equal_to_a_different_nullable_value_notbe_should_succeed()
        {
            // Arrange
            DateTime dateTime = 4.June(2016);
            DateTime? otherDateTime = 5.June(2016);

            // Act
            Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsNotEqualTo(otherDateTime));

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task Should_fail_when_asserting_datetime_value_is_not_equal_to_the_same_value()
        {
            // Arrange
            var dateTime = DateTime.SpecifyKind(10.March(2012).At(10, 00), DateTimeKind.Local);
            var sameDateTime = DateTime.SpecifyKind(10.March(2012).At(10, 00), DateTimeKind.Local);

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsNotEqualTo(sameDateTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_datetime_value_is_not_equal_to_the_same_nullable_value_notbe_should_failed()
        {
            // Arrange
            DateTime dateTime = DateTime.SpecifyKind(10.March(2012).At(10, 00), DateTimeKind.Local);
            DateTime? sameDateTime = DateTime.SpecifyKind(10.March(2012).At(10, 00), DateTimeKind.Local);

            // Act
            Action act =
                () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(dateTime).IsNotEqualTo(sameDateTime).Because($"because we want to test the failure {"message"}"));

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
