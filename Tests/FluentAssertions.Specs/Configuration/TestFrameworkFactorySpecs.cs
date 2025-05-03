using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;
using TestFramework = FluentAssertions.Configuration.TestFramework;

namespace FluentAssertions.Specs.Configuration;

public class TestFrameworkFactorySpecs
{
    [Fact]
    public async Task When_running_xunit_test_implicitly_it_should_be_detected()
    {
        // Arrange
        var testFramework = TestFrameworkFactory.GetFramework(null);

        // Act
        Action act = () => testFramework.Throw("MyMessage");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_running_xunit_test_explicitly_it_should_be_detected()
    {
        // Arrange
        var testFramework = TestFrameworkFactory.GetFramework(TestFramework.XUnit2);

        // Act
        Action act = () => testFramework.Throw("MyMessage");

        // Assert
        await Expect.That(act).Throws<XunitException>();
    }

    [Fact]
    public async Task When_running_test_with_unknown_test_framework_it_should_throw()
    {
        // Act
        Action act = () => TestFrameworkFactory.GetFramework((TestFramework)42);

        // Assert
        await Expect.That(act).Throws<InvalidOperationException>();
    }

    [Fact]
    public async Task When_running_test_with_late_bound_but_unavailable_test_framework_it_should_throw()
    {
        // Act
        Action act = () => TestFrameworkFactory.GetFramework(TestFramework.NUnit);

        await Expect.That(act).Throws<InvalidOperationException>();
    }
}
