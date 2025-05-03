#if NET6_0_OR_GREATER
using System;
using System.IO;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Streams;

public class BufferedStreamAssertionSpecs
{
    public class HaveBufferSize
    {
        [Fact]
        public async Task When_a_stream_has_the_expected_buffer_size_it_should_succeed()
        {
            // Arrange
            using var stream = new BufferedStream(new MemoryStream(), 10);

            // Act
            Action act = () =>
                stream.Should().HaveBufferSize(10);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_stream_has_an_unexpected_buffer_size_should_fail()
        {
            // Arrange
            using var stream = new BufferedStream(new MemoryStream(), 1);

            // Act
            Action act = () =>
                stream.Should().HaveBufferSize(10, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_null_have_buffer_size_should_fail()
        {
            // Arrange
            BufferedStream stream = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                stream.Should().HaveBufferSize(10, "we want to test the failure {0}", "message");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }

    public class NotHaveBufferSize
    {
        [Fact]
        public async Task When_a_stream_does_not_have_an_unexpected_buffer_size_it_should_succeed()
        {
            // Arrange
            using var stream = new BufferedStream(new MemoryStream(), 1);

            // Act
            Action act = () =>
                stream.Should().NotHaveBufferSize(10);

            // Assert
            await Expect.That(act).DoesNotThrow();
        }

        [Fact]
        public async Task When_a_stream_does_have_the_unexpected_buffer_size_it_should_fail()
        {
            // Arrange
            using var stream = new BufferedStream(new MemoryStream(), 10);

            // Act
            Action act = () =>
                stream.Should().NotHaveBufferSize(10, "we want to test the failure {0}", "message");

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }

        [Fact]
        public async Task When_null_not_have_buffer_size_should_fail()
        {
            // Arrange
            BufferedStream stream = null;

            // Act
            Action act = () =>
            {
                using var _ = new AssertionScope();
                stream.Should().NotHaveBufferSize(10, "we want to test the failure {0}", "message");
            };

            // Assert
            await Expect.That(act).Throws<XunitException>();
        }
    }
}
#endif
