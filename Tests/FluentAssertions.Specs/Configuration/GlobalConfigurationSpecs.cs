using System;
using System.Threading.Tasks;
using FluentAssertions.Configuration;
using FluentAssertions.Execution;
using Xunit;

namespace FluentAssertions.Specs.Configuration;

[Collection("ConfigurationSpecs")]
public sealed class GlobalConfigurationSpecs : IDisposable
{
    [Fact]
    public async Task Concurrently_accessing_the_configuration_is_safe()
    {
        // Act
        Action act = () => Parallel.For(
            0,
            10000,
            new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            },
            __ =>
            {
                AssertionConfiguration.Current.Formatting.ValueFormatterAssembly = string.Empty;
                _ = AssertionConfiguration.Current.Formatting.ValueFormatterDetectionMode;
            }
        );

        // Assert
        await Expect.That(act).DoesNotThrow();
    }

    private class NotImplementedTestFramework : ITestFramework
    {
        public bool IsAvailable => true;

        public void Throw(string message) => throw new NotImplementedException();
    }

    public void Dispose() => AssertionEngine.ResetToDefaults();
}
