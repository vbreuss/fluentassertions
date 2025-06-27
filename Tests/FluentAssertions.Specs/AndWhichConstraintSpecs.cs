using System;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs;

public class AndWhichConstraintSpecs
{
    [Fact]
    public async Task When_many_objects_are_provided_accessing_which_should_throw_a_descriptive_exception()
    {
        // Arrange
        var continuation = new AndWhichConstraint<StringCollectionAssertions, string>(null, ["hello", "world"], AssertionChain.GetOrCreate());

        // Act
        Action act = () => _ = continuation.Which;

        // Assert
        await That(act).Throws<XunitException>();
    }
}
