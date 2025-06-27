using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Xunit;

namespace FluentAssertions.Specs.Primitives;

public partial class ObjectAssertionSpecs
{
    public class Miscellaneous
    {
        [Fact]
        public async Task Should_support_chaining_constraints_with_and()
        {
            // Arrange
            var someObject = new Exception();

            // Act / Assert
            await That(someObject).IsExactly<Exception>();
        }

        [Fact]
        public async Task Should_throw_a_helpful_error_when_accidentally_using_equals()
        {
            // Arrange
            var someObject = new Exception();

            // Act
            var action = () => someObject.Should().Equals(null);

            // Assert
            await That(action).Throws<NotSupportedException>();
        }
    }

    internal class DumbObjectEqualityComparer : IEqualityComparer<object>
    {
        // ReSharper disable once MemberHidesStaticFromOuterClass
        public new bool Equals(object x, object y)
        {
            return (x == y) || (x is not null && y is not null && x.Equals(y));
        }

        public int GetHashCode(object obj) => obj.GetHashCode();
    }
}

internal class DummyBaseClass;

internal sealed class DummyImplementingClass : DummyBaseClass, IDisposable
{
    public void Dispose()
    {
        // Ignore
    }
}

internal class SomeClass
{
    public SomeClass(int key)
    {
        Key = key;
    }

    public int Key { get; }

    public override string ToString() => $"SomeClass({Key})";
}

internal class SomeClassEqualityComparer : IEqualityComparer<SomeClass>, IEqualityComparer<object>
{
    public bool Equals(SomeClass x, SomeClass y)
    {
        return (x == y) || (x is not null && y is not null && x.Key.Equals(y.Key));
    }

    public new bool Equals(object x, object y) => Equals(x as SomeClass, y as SomeClass);
    public int GetHashCode(SomeClass obj) => obj.Key;
    public int GetHashCode([DisallowNull] object obj) => GetHashCode(obj as SomeClass);
}

internal class SomeClassAssertions : ObjectAssertions<SomeClass, SomeClassAssertions>
{
    public SomeClassAssertions(SomeClass value)
        : base(value, AssertionChain.GetOrCreate())
    {
    }
}

internal static class AssertionExtensions
{
    public static SomeClassAssertions Should(this SomeClass value) => new(value);
}
