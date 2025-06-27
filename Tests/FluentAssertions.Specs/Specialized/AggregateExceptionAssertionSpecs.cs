using System;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Specialized;

public class AggregateExceptionAssertionSpecs
{
    /* TODO VAB
    [Fact]
    public async Task When_the_expected_exception_is_wrapped_it_should_succeed()
    {
        // Arrange
        var exception = new AggregateException(
            new InvalidOperationException("Ignored"),
            new XunitException("Background"));

        // Act
        Action act = () => throw exception;

        // Assert
        await Expect.That(act).Throws<XunitException>().WithRecursiveInnerExceptions<XunitException>(x => x);
    }
    */

    [Fact]
    public async Task When_the_expected_exception_was_not_thrown_it_should_report_the_actual_exceptions()
    {
        // Arrange
        Action throwingOperation = () =>
        {
            throw new AggregateException(
                new InvalidOperationException("You can't do this"),
                new NullReferenceException("Found a null"));
        };

        // Act
        Action act = () => Synchronously.Verify(That(throwingOperation).Throws<ArgumentNullException>());

        // Assert
        await That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_no_exception_was_expected_it_should_report_the_actual_exceptions()
    {
        // Arrange
        Action throwingOperation = () =>
        {
            throw new AggregateException(
                new InvalidOperationException("You can't do this"),
                new NullReferenceException("Found a null"));
        };

        // Act
        Action act = () => Synchronously.Verify(That(throwingOperation).DoesNotThrow());

        // Assert
        await That(act).Throws<XunitException>();
    }
}
