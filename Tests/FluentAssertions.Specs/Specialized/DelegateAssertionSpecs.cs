using System;
using FluentAssertions.Execution;
using Xunit;

namespace FluentAssertions.Specs.Specialized;

public class DelegateAssertionSpecs
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
            await Expect.That(subject).Throws<Exception>();
        }
    }
}
