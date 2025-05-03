using System;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using FluentAssertions.Primitives;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Primitives;

public class SimpleTimeSpanAssertionSpecs
{
    [Fact]
    public async Task When_asserting_positive_value_to_be_positive_it_should_succeed()
    {
        // Arrange
        TimeSpan timeSpan = 1.Seconds();

        // Act / Assert
        await Expect.That(timeSpan).IsPositive();
    }

    [Fact]
    public async Task When_asserting_negative_value_to_be_positive_it_should_fail()
    {
        // Arrange
        TimeSpan negatedTimeSpan = 1.Seconds().Negate();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(negatedTimeSpan).IsPositive());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_zero_value_to_be_positive_it_should_fail()
    {
        // Arrange
        TimeSpan negatedTimeSpan = 0.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(negatedTimeSpan).IsPositive());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_positive_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsPositive().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_negative_value_to_be_positive_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan timeSpan = 1.Seconds().Negate();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(timeSpan).IsPositive().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_negative_value_to_be_negative_it_should_succeed()
    {
        // Arrange
        TimeSpan timeSpan = 1.Seconds().Negate();

        // Act / Assert
        await Expect.That(timeSpan).IsNegative();
    }

    [Fact]
    public async Task When_asserting_positive_value_to_be_negative_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNegative());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_zero_value_to_be_negative_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 0.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsNegative());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_negative_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsNegative().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_positive_value_to_be_negative_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan timeSpan = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(timeSpan).IsNegative().Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_equal_to_same_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        var expected = TimeSpan.FromSeconds(1);

        // Act / Assert
        await Expect.That(actual).IsEqualTo(expected);
    }

    [Fact]
    public async Task When_asserting_value_to_be_equal_to_different_value_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan expected = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsEqualTo(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task A_null_is_not_equal_to_another_value()
    {
        // Arrange
        var subject = new SimpleTimeSpanAssertions(null, AssertionChain.GetOrCreate());
        TimeSpan expected = 2.Seconds();

        // Act
        Action act = () => subject.Be(expected);

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_equal_to_different_value_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsEqualTo(expected).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_equal_to_different_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan timeSpan = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(timeSpan).IsEqualTo(2.Seconds()).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_not_equal_to_different_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan unexpected = 2.Seconds();

        // Act / Assert
        await Expect.That(actual).IsNotEqualTo(unexpected);
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_not_equal_to_different_value_it_should_succeed()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act / Assert
        await Expect.That(nullTimeSpan).IsNotEqualTo(expected);
    }

    [Fact]
    public async Task When_asserting_value_to_be_not_equal_to_the_same_value_it_should_fail()
    {
        // Arrange
        var oneSecond = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(oneSecond).IsNotEqualTo(oneSecond));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_not_equal_to_the_same_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        var oneSecond = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(oneSecond).IsNotEqualTo(oneSecond).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_smaller_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();
        TimeSpan smaller = 1.Seconds();

        // Act / Assert
        await Expect.That(actual).IsGreaterThan(smaller);
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_greater_value_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan expected = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsGreaterThan(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_greater_than_other_value_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsGreaterThan(expected).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_same_value_it_should_fail()
    {
        // Arrange
        var twoSeconds = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(twoSeconds).IsGreaterThan(twoSeconds));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_greater_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsGreaterThan(2.Seconds()).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_or_equal_to_smaller_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();
        TimeSpan smaller = 1.Seconds();

        // Act / Assert
        await Expect.That(actual).IsGreaterThanOrEqualTo(smaller);
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_greater_than_or_equal_to_other_value_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsGreaterThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_or_equal_to_same_value_it_should_succeed()
    {
        // Arrange
        var twoSeconds = 2.Seconds();

        // Act / Assert
        await Expect.That(twoSeconds).IsGreaterThanOrEqualTo(twoSeconds);
    }

    [Fact]
    public async Task Chaining_after_one_assertion_1()
    {
        // Arrange
        var twoSeconds = 2.Seconds();

        // Act / Assert
        await Expect.That(twoSeconds).IsGreaterThanOrEqualTo(twoSeconds);
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_or_equal_to_greater_value_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan expected = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsGreaterThanOrEqualTo(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_greater_than_or_equal_to_greater_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsGreaterThanOrEqualTo(2.Seconds()).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_greater_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan greater = 2.Seconds();

        // Act / Assert
        await Expect.That(actual).IsLessThan(greater);
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_smaller_value_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsLessThan(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_less_than_other_value_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsLessThan(expected).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_same_value_it_should_fail()
    {
        // Arrange
        var twoSeconds = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(twoSeconds).IsLessThan(twoSeconds));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_smaller_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsLessThan(1.Seconds()).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_or_equal_to_greater_value_it_should_succeed()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan greater = 2.Seconds();

        // Act / Assert
        await Expect.That(actual).IsLessThanOrEqualTo(greater);
    }

    [Fact]
    public async Task Chaining_after_one_assertion_2()
    {
        // Arrange
        TimeSpan actual = 1.Seconds();
        TimeSpan greater = 2.Seconds();

        // Act / Assert
        await Expect.That(actual).IsLessThanOrEqualTo(greater);
    }

    [Fact]
    public async Task When_asserting_null_value_to_be_less_than_or_equal_to_other_value_it_should_fail()
    {
        // Arrange
        TimeSpan? nullTimeSpan = null;
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () =>
aweXpect.Synchronous.Synchronously.Verify(Expect.That(nullTimeSpan).IsLessThanOrEqualTo(expected).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_or_equal_to_same_value_it_should_succeed()
    {
        // Arrange
        var twoSeconds = 2.Seconds();

        // Act / Assert
        await Expect.That(twoSeconds).IsLessThanOrEqualTo(twoSeconds);
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_or_equal_to_smaller_value_it_should_fail()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();
        TimeSpan expected = 1.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsLessThanOrEqualTo(expected));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_value_to_be_less_than_or_equal_to_smaller_value_it_should_fail_with_descriptive_message()
    {
        // Arrange
        TimeSpan actual = 2.Seconds();

        // Act
        Action act = () => aweXpect.Synchronous.Synchronously.Verify(Expect.That(actual).IsLessThanOrEqualTo(1.Seconds()).Because($"because we want to test the failure {"message"}"));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_accidentally_using_equals_it_should_throw_a_helpful_error()
    {
        // Arrange
        TimeSpan someTimeSpan = 2.Seconds();

        // Act
        Action act = () => someTimeSpan.Should().Equals(someTimeSpan);

        // Assert
        await Expect.That(act).Throws<NotSupportedException>();
    }

    #region Be Close To

    [Fact]
    public async Task When_asserting_that_time_is_close_to_a_negative_precision_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 980);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, -1.Ticks());

        // Assert
        await Expect.That(act).Throws<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task When_time_is_less_then_but_close_to_another_value_it_should_succeed()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 980);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_time_is_greater_then_but_close_to_another_value_it_should_succeed()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 020);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_time_is_less_then_and_not_close_to_another_value_it_should_throw_with_descriptive_message()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 979);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds(), "we want to test the error message");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_time_is_greater_then_and_not_close_to_another_value_it_should_throw_with_descriptive_message()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 021);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 20.Milliseconds(), "we want to test the error message");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_time_is_within_specified_number_of_milliseconds_from_another_value_it_should_succeed()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 035);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_a_null_time_is_asserted_to_be_close_to_another_it_should_throw()
    {
        // Arrange
        TimeSpan? time = null;
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().BeCloseTo(nearbyTime, 35.Milliseconds());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_time_away_from_another_value_it_should_throw_with_descriptive_message()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 979);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () =>
            time.Should().BeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20), "we want to test the error message");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    #endregion

    #region Not Be Close To

    [Fact]
    public async Task When_asserting_that_time_is_not_close_to_a_negative_precision_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 980);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, -1.Ticks());

        // Assert
        await Expect.That(act).Throws<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_a_later_time_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 980);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_an_earlier_time_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 020);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_an_earlier_time_by_a_20ms_timespan_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 020);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(20));

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_another_value_that_is_later_by_more_than_20ms_it_should_succeed()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 30, 979);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_another_value_that_is_earlier_by_more_than_20ms_it_should_succeed()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 021);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 20.Milliseconds());

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    [Fact]
    public async Task When_asserting_subject_time_is_not_close_to_an_earlier_time_by_35ms_it_should_throw()
    {
        // Arrange
        var time = new TimeSpan(1, 12, 15, 31, 035);
        var nearbyTime = new TimeSpan(1, 12, 15, 31, 000);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_asserting_subject_null_time_is_not_close_to_another_it_should_throw()
    {
        // Arrange
        TimeSpan? time = null;
        TimeSpan nearbyTime = TimeSpan.FromHours(1);

        // Act
        Action act = () => time.Should().NotBeCloseTo(nearbyTime, 35.Milliseconds());

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    #endregion
}
