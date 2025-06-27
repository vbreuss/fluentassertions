using System;
using Xunit;

namespace FluentAssertions.Specs.Specialized;

public class ActionAssertionSpecs
{
    public class Throw
    {
        [Fact]
        public async Task Allow_additional_assertions_on_return_value()
        {
            // Arrange
            var exception = new Exception("foo");
            Action subject = () => throw exception;

            // Act / Assert
            await That(subject).Throws<Exception>();
        }
    }

    public class NotThrow
    {
        [Fact]
        public async Task Allow_additional_assertions_on_return_value()
        {
            // Arrange
            Action subject = () => { };

            // Act / Assert
            await That(subject).DoesNotThrow();
        }
    }
}
