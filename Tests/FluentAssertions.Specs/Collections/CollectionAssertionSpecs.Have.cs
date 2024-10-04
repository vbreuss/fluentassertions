using System;
using FluentAssertions.Execution;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Specs.Collections;

/// <content>
/// The [Not]HaveCount specs.
/// </content>
public partial class CollectionAssertionSpecs
{
    public class Have
    {
        [Fact]
        public void T1()
        {
            // Arrange
            int[] collection = [1, 2];

            // Act / Assert
            collection.Should().HaveAtLeast(3).ItemsOfTypeMatching<Exception>(e => e.Message == "foo");
        }

        [Fact]
        public void T2()
        {
            // Arrange
            int[] collection = [1, 2];

            // Act / Assert
            collection.Should().Have(3).ItemsMatching(x => x < 2);
        }

        [Fact]
        public void T4()
        {
            // Arrange
            int[] collection = [1, 2, 3, 4];

            // Act / Assert
            collection.Should().HaveAtMost(3).ItemsOfType<int>();
        }
    }
}
